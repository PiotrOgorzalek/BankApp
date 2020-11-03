using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        private Controller myController;
        private string messageId;
        private string userMessage;
        private Dictionary<string, string> abbreviations;
        private List<string> quarantinneList = new List<string>();
        private List<string> mentionsList = new List<string>();
        public InputWindow(Controller cont)
        {
            myController = cont;
            InitializeComponent();
            abbreviations = myController.CreateAbbrievationDict(); 


        }
        // when button clicked controller will check and open relevant screen

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char type = txtMessage.Text[0];

            
            //   MessageBox.Show(txtMessageId.Text);
            //myController.OpenRelevant(myController,txtMessageId.Text,this);
        }
      

        private void  txtMessageId_LostFocus(object sender, RoutedEventArgs e)
        {
            myController.CheckInput(myController, txtMessageId.Text, this);
            
        }

        public void ShowError(string errorMessage) 
        { 
            MessageBox.Show(errorMessage);
        }

        private void CreateObjectsAndSave() 
        {
            char typeOfMessage = txtMessageId.Text[0];
            switch (char.ToUpper(typeOfMessage))
            {
                case 'S':
                    userMessage = txtMessage.Text;
                    txtMessage.Clear();
                    var result = string.Join(" ", userMessage.Split(' ').Select(i => abbreviations.ContainsKey(i) ? i + "<" + abbreviations[i] + ">" : i));
                    txtMessage.MaxLength = result.Length;
                    txtMessage.IsEnabled = false;
                    txtMessage.Text = result;
                    SmsMessage one = new SmsMessage(txtMessageId.Text, txtSender.Text, txtMessage.Text);
                    myController.SaveDataAsJson(one, "user.json");
                    break;
                case 'T':
                    break;
                case 'E':
                    getRegexForEmail(txtMessage.Text);
                    break;


            }
        
        }
        private string getRegexForEmail(string input) 
        {
            
            string pattern = @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)";
            MatchCollection machList = Regex.Matches(input, pattern);
            var list = machList.Cast<Match>().Select(match => match.Value).ToList();
            input = Regex.Replace(input, @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", "< URL QUARNTINNED >");
           //REMEMBER !!! ADDING URL TO QUARANTINNE LIST
            for (int i = 0; i < list.Count; i++)
            {
                quarantinneList.Add(list[i]);
            }
            return input;
        }

    }
}


