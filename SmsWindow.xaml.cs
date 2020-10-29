using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for SmsWindow.xaml
    /// </summary>
    public partial class SmsWindow : Window
    {
        Controller myController;
        string messageId;
        string userMessage;
        Dictionary<string, string> abbreviations;
        public SmsWindow(Controller cont,string messageId)
        {
            myController = cont;
            this.messageId = messageId;
            InitializeComponent();
            lblMsgId.Content = messageId;
            abbreviations = myController.CreateAbbrievationDict();
        }

       

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            userMessage = txtMessage.Text;
            txtMessage.Clear();
            var result = string.Join(" ", userMessage.Split(' ').Select(i => abbreviations.ContainsKey(i) ?  i +"<" + abbreviations[i]+ ">" : i));
            txtMessage.MaxLength = result.Length;
            txtMessage.IsEnabled = false;
;            txtMessage.Text = result;
        }
    }
}
