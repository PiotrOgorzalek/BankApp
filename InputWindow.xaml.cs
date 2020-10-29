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
        Controller myController;
        string messageId;
        string userMessage;
        Dictionary<string, string> abbreviations;
        public InputWindow(Controller cont)
        {
            myController = cont;
            InitializeComponent();
            abbreviations = myController.CreateAbbrievationDict(); 


        }
        // when button clicked controller will check and open relevant screen

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myController.CheckInput(myController,txtMessageId.Text,this);
            userMessage = txtMessage.Text;
            txtMessage.Clear();
            var result = string.Join(" ", userMessage.Split(' ').Select(i => abbreviations.ContainsKey(i) ? i + "<" + abbreviations[i] + ">" : i));
            txtMessage.MaxLength = result.Length;
            txtMessage.IsEnabled = false;
            txtMessage.Text = result;

            //   MessageBox.Show(txtMessageId.Text);
            //myController.OpenRelevant(myController,txtMessageId.Text,this);
        }
      

        private void txtMessageId_LostFocus(object sender, RoutedEventArgs e)
        {
            myController.CheckInput(myController, txtMessageId.Text, this);
        }

        public void ShowError(string errorMessage) 
        { 
            MessageBox.Show(errorMessage);
        }
    }
}


