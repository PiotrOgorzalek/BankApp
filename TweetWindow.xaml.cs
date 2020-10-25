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
    /// opening screen using information from construct in this case label and changing it depending 
    //o input window text box text
    /// </summary>
    public partial class TweetWindow : Window
    {
        Controller myController;
        string messageId;
        public TweetWindow(Controller cont,string messageId)
        {
            myController = cont;
            this.messageId = messageId;
            InitializeComponent();
            lblMsgId.Content = messageId;
        }
    }
}
