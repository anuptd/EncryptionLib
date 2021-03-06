﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Networking.Connectivity;

using EncryptionLibrary;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StringEncryptionUAPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private async void testbutton_Click(object sender, RoutedEventArgs e)
        {
            DateTimeGenerator myDTG;
            DateTime TheNetworkTime;
            DateTime TheLocalTime;
            TimeSpan span;

            myDTG = DateTimeGenerator.Instance;

            TheLocalTime = DateTime.UtcNow;
            TheNetworkTime = await myDTG.GetNTPTime();

            span = TheNetworkTime.Subtract(TheLocalTime);

            textBox1.Text = TheLocalTime.ToString();
            textBox2.Text = TheNetworkTime.ToString();

            textBox3.Text = span.ToString();
        }
    }
}
