/*
 * Copyright (c) 2013 - 2017 MasterCard International Incorporated
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are 
 * permitted provided that the following conditions are met:
 * 
 * Redistributions of source code must retain the above copyright notice, this list of 
 * conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright notice, this list of 
 * conditions and the following disclaimer in the documentation and/or other materials 
 * provided with the distribution.
 * Neither the name of the MasterCard International Incorporated nor the names of its 
 * contributors may be used to endorse or promote products derived from this software 
 * without specific prior written permission.
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY 
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES 
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
 * SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
 * TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
 * OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER 
 * IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING 
 * IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF 
 * SUCH DAMAGE.
 */


using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimplifyCommerce.Payments {
    public class FraudCheck {

        [JsonProperty("amount")]
        public long? Amount { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("dateCreated")]
        public long? DateCreated { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fraudResult")]
        public FraudResult FraudResult { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("integratorAuthCode")]
        public string IntegratorAuthCode { get; set; }

        [JsonProperty("integratorAvsAddressResponse")]
        public string IntegratorAvsAddressResponse { get; set; }

        [JsonProperty("integratorAvsZipResponse")]
        public string IntegratorAvsZipResponse { get; set; }

        [JsonProperty("integratorCvcResponse")]
        public string IntegratorCvcResponse { get; set; }

        [JsonProperty("integratorDeclineReason")]
        public string IntegratorDeclineReason { get; set; }

        [JsonProperty("integratorTransactionRef")]
        public string IntegratorTransactionRef { get; set; }

        [JsonProperty("integratorTransactionStatus")]
        public string IntegratorTransactionStatus { get; set; }

        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("lastUpdated")]
        public long? LastUpdated { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("transaction")]
        public AbstractTransaction Transaction { get; set; }


        public FraudCheck ()
        {
        }

        public FraudCheck (string Id)
        {
            this.Id = Id;
        }
    }
}
