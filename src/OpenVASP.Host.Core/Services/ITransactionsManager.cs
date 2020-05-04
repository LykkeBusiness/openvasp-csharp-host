﻿using OpenVASP.Messaging.Messages;
using OpenVASP.Messaging.Messages.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Transaction = OpenVASP.Host.Core.Models.Transaction;

namespace OpenVASP.Host.Core.Services
{
    public interface ITransactionsManager
    {
        Task<ReadOnlyCollection<Transaction>> GetOutgoingTransactionsAsync();

        Task<ReadOnlyCollection<Transaction>> GetIncomingTransactionsAsync();

        Task SendSessionReplyAsync(string id, SessionReplyMessage.SessionReplyMessageCode code);

        Task<Transaction> RegisterOutgoingTransactionAsync(
            Transaction transaction,
            Originator originator,
            VirtualAssetsAccountNumber virtualAssetsAccountNumber);

        Task SendTransferReplyAsync(
            string id,
            string destinationAddress,
            TransferReplyMessage.TransferReplyMessageCode code);

        Task SendTransferConfirmAsync(string id);

        Task SendTransferDispatchAsync(
            string id,
            string sendingAddress,
            string transactionHash);
    }
}