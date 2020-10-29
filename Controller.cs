using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

// class that behave like data base and cotroller
namespace BankApp
{
    public class Controller
    {
        //will hold csv file for text abbrievations
        private static List<string> abbrievations;
        //dummy user
        public List<User> usersList = new List<User> { new User("1111", "2222"), new User("3333", "4444") };

        //check for user password if correct let MainWindow window to open INput screen
        public bool ValidateInput(string name, string password)
        {
            foreach (User user in usersList)
            {
                if ((String.Equals(user.GetPass(), password)) && String.Equals(user.GetName(), name))
                {
                    return true;
                }

            }
            return false;
        }

        // adding user to dropBox
        public List<String> ReturnUsers()
        {
            List<String> userNames = new List<String>();
            foreach (User user in usersList)
            {
                userNames.Add(user.GetName());
            }
            return userNames;
        }
        // opening relevant screen using string header 
        // NEED TO ADD SIZE VALIDATION
        public void CheckInput(Controller myController, string messageId, InputWindow window)
        {
            if ((messageId.Equals("")) || (messageId.Length < 10) || (messageId.Length > 10))
            {
                window.ShowError("header input not valid");
            }
            else if (messageId.Length == 10)
            {
                string forCheck = messageId.Substring(1, 9);
                Regex regex = new Regex("^[0-9]+$");
                if (!(regex.IsMatch(forCheck)))
                {
                    window.ShowError("Header need to contain letter and 9 numbers");
                }
                else
                {
                    //getting first char to check 
                    char firstLetter = messageId[0];

                    switch (Char.ToUpper(firstLetter))
                    {
                        case 'S':
                            // DELETE MESSAGGES
                            MessageBox.Show("s entered");
                            window.lblSender.Content = "Telephone number";
                            window.txtMessage.MaxLength = 140;
                            break;
                        case 'T':
                            MessageBox.Show("t enetered");

                            break;
                        case 'E':
                            MessageBox.Show("email entered");
                            window.grpEmail.Visibility = Visibility.Visible;
                            break;
                        default:
                            MessageBox.Show("First letter not recognized" + "\n" + "S for SMS" + "\n" + "T for Twitter" + "\n" + "E for Email");
                            break;
                    }
                }

            }


        }
        public Dictionary<string, string> CreateAbbrievationDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            using (StreamReader reader = new StreamReader("textwords.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    dict.Add(parts[0], parts[1]);
                }

            }
            return dict;
        }
    }
    
}
