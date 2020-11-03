using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    
    class SmsMessage : IncomingMessage
    {
        [DataMember]
        protected int maxTextInput { get; set; }
        public SmsMessage(string id,string sender,string body)
        {
            messageId = id;
            this.sender = sender;
            messageBody = body;
            maxTextInput = 140;
        }



        public string toStringAll()
        {
            return maxTextInput.ToString() + "\n" + toString();
        }
    }
  
    
}
