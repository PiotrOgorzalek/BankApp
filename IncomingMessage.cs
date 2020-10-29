using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp
{
    [DataContract]
    abstract class IncomingMessage
    {
       [DataMember]
        protected string messageId { get; set; }
        [DataMember]
        protected string messageBody { get; set; }
        [DataMember]
        protected string sender { get; set; }

        public IncomingMessage() 
        {
            messageId = "dummmy header";
            messageBody = "Something dummy";
            sender = "dummy sender";
        
        }
        public string  toString() 
        {
            return messageId + "\n" + messageBody + "\n" + sender;
        }
    }
}
