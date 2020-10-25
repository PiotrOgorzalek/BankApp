using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp
{
    public class Controller
    {
        private static List<string> abbrievations;
        public List<User> usersList = new List<User> {new User("1111", "2222"),new User("3333", "4444")};

       
        //check for user password if correct let them in 
        public bool ValidateInput(string name, string password) 
        {
            foreach (User user in usersList) 
            { 
                    if ((String.Equals(user.GetPass(),password)) && String.Equals(user.GetName(), name))
                    {
                        return true;
                    }
                 
            }
            return false;
        }

        public List<String> ReturnUsers()
        {
            List<String> userNames = new List<String>();
            foreach (User user in usersList) 
            {
                userNames.Add(user.GetName());
            }
            return userNames;
        }
        public void OpenRelevant(Controller myController,string messageId,InputWindow window)
        {
            char firstLetter = messageId[0];
            
            switch (Char.ToUpper(firstLetter)) 
            {
                case 'S':
                    MessageBox.Show("s entered");
                    SmsWindow sms = new SmsWindow(myController,messageId);
                    sms.Show();
                    window.Hide();
                    break;
                case 'T':
                    MessageBox.Show("t enetered");
                    TweetWindow twitter = new TweetWindow(myController,messageId);
                    twitter.Show();
                    window.Hide();
                    break;
                case 'E':
                    MessageBox.Show("email entered");
                    Email email = new Email(myController,messageId);
                    email.Show();
                    window.Hide();
                    break;
                default:
                    MessageBox.Show("upps something went wrong");
                    break;
            }
        
        }
    }
}
