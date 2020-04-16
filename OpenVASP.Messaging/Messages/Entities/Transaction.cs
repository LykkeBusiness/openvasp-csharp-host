﻿using System;
using Newtonsoft.Json;

namespace OpenVASP.Messaging.Messages.Entities
{
    public class Transaction
    {
        public Transaction(string transactionId, DateTime dateTime, string sendingAddress)
        {
            TransactionId = transactionId;
            DateTime = dateTime;
            SendingAddress = sendingAddress;
        }

        [JsonProperty("txid")]
        public string TransactionId { get; private set; }

        [JsonProperty("datetime")]
        public DateTime DateTime { get; private set; }

        [JsonProperty("sendingadr")]
        public string SendingAddress { get; private set; }
    }
}