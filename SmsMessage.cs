using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    [DataContract]
    class SmsMessage : IncomingMessage
    {
        [DataMember]
        protected int maxTextInput { get; set; }
        public SmsMessage(string id,string body,string sender)
        {
            messageId = id;
            messageBody = body;
            this.sender = sender;
            
            maxTextInput = 140;
        }



        public string toStringAll()
        {
            return maxTextInput.ToString() + "\n" + toString();
        }
    }
  
    
}
