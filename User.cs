using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    //dummy user class 
    public class User
    {
        private string name;
        private string password;

        public User(string name,string password)
        {
            this.name = name;
            this.password = password;
        }
        public string GetPass() 
        {
            return password;
        }
        public string GetName()
        {
            return name;
        }
    }
}
