﻿using System;
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
    /// Interaction logic for SmsWindow.xaml
    /// </summary>
    public partial class SmsWindow : Window
    {
        Controller myController;
        string messageId;
        public SmsWindow(Controller cont,string messageId)
        {
            myController = cont;
            this.messageId = messageId;
            InitializeComponent();
            lblMsgId.Content = messageId;
        }
    }
}