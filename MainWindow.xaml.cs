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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller myController;

        public MainWindow()
        {
            
            InitializeComponent();
            myController = new Controller();
            foreach (String name in (myController.ReturnUsers()))
            {
                cmbName.Items.Add(name);
            }
        }

        
        //after butotn clicked controller will check data
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string empNo = cmbName.SelectedItem.ToString();
            if (txtPass.Text.Equals(""))
            {
                MessageBox.Show("need to input data");
            }
            else if  (myController.ValidateInput(empNo, txtPass.Text))
            {
                InputWindow input = new InputWindow(myController);
                input.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Wrong Password");
            }
        }

       
    }
}
