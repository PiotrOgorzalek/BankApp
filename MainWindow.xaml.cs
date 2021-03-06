﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ubiety.Dns.Core;

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

           // string empNo = cmbName.SelectedItem.ToString();
           // if (txtPass.Text.Equals(""))
           // {
          //      MessageBox.Show("need to input data");
          //  }
           // else if  (myController.ValidateInput(empNo, txtPass.Text))
         //   {
                InputWindow input = new InputWindow(myController);
                input.Show();
                this.Hide();
          //  }
          //  else 
          //  {
          //      MessageBox.Show("Wrong Password");
           // }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string msg = "www.wp.pl something something ola ola www.google.com ";
            string pattern = @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)";
            MatchCollection machList = Regex.Matches(msg, pattern);
            var list = machList.Cast<Match>().Select(match => match.Value).ToList();
            msg = Regex.Replace(msg, @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", "< URL QUARNTINNED >");
            for (int i = 0; i < list.Count; i++)
            {
                MessageBox.Show(list[i]);
            }
            //var msg = "Something www.wp.pl something";
            //msg = Regex.Replace(msg, @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", "< URL QUARNTINNED >");
            //MessageBox.Show(msg);
        }

    }
}
