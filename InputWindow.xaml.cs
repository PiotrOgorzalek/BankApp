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
        public InputWindow(Controller cont)
        {
            myController = cont;
            InitializeComponent();
            

            
        }
        // when button clicked controller will check and open relevant screen

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtMessageId.Text);
            myController.OpenRelevant(myController,txtMessageId.Text,this);
        }
    }
}
