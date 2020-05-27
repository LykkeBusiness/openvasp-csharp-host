pipeline {
  agent any
  stages {
    stage('Dotnet Build') {
      steps {
        sh 'dotnet build --configuration Release src/${ServiceName}/${ServiceName}.csproj'
      }
    }

    stage('Dotnet Publish') {
      steps {
        sh 'dotnet publish src/${ServiceName}/${ServiceName}.csproj --configuration Release --output ./docker/service --no-restore'
      }
    }

    stage('Docker Build') {
      steps {
        sh '''
        docker build --tag openvasporg/${DockerName}:0.${BUILD_ID} ./docker/service
        docker tag openvasporg/${DockerName}:0.${BUILD_ID} openvasporg/${DockerName}:latest
        docker login -u=$REGISTRY_AUTH_USR -p=$REGISTRY_AUTH_PSW
        docker push openvasporg/${DockerName}:0.${BUILD_ID}
        docker push openvasporg/${DockerName}:latest'''
      }
    }

    stage('Prepare Yamls') {
      parallel {
        stage('Namespace Check') {
          steps {
            sh '''
            Namespace=$(cat kubernetes/namespace.yaml | grep name |awk \'{print $2}\')
            NSK=$(kubectl --kubeconfig=/kube/dev get namespace "$Namespace" -o jsonpath={.metadata.name})
            if [ $NSK ]; then
            echo  Namsespace "$Namespace" Exists
            else
            echo no Namespace $Namespace in cluster found - creating
            fi'''
          }
        }

        stage('Ingress Check') {
          steps {
            sh '''
            Ingress=$(cat kubernetes/ingress.yaml | grep name |awk \'{print $2}\')
            Namespace=$(cat kubernetes/namespace.yaml | grep name |awk \'{print $2}\')
            ING=$(kubectl --kubeconfig=/kube/dev get ingress $Ingress -n "$Namespace" -o jsonpath={.metadata.name} &> /dev/null)
            if [ $ING ]; then
            echo  Ingress "$Ingress" Exists
            else
            echo no Ingress $Ingress in cluster found - creating
            fi'''
          }
        }

        stage('Substitute Yamls') {
          steps {
            sh '''Image=${DockerName}:0.${BUILD_ID}
sed -i -e \'s/$dockerImage/\'"$Image"\'/g\' kubernetes/deployment.yaml
cat kubernetes/deployment.yaml
'''
          }
        }

      }
    }

  }
  environment {
    RepoName = 'openvasp-csharp-host'
    ServiceName = 'OpenVASP.Host'
    DockerName = 'csharp-host'
    REGISTRY_AUTH = credentials('dockerhub')
  }
}