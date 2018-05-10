using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace TimerRemind
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer _timer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void IsOnChecked(object sender, RoutedEventArgs e)
        {
            _timer = new Timer(new TimerCallback(ShowMessage), messageTextBox, iMilliseconds, int.Parse(intervalTextBox.Text) * 60000);
        }

        private void IsOnUnchecked(object sender, RoutedEventArgs e)
        {
            _timer = null;
        }

        private void ShowMessage(object obj)
        {
            TextBox message = (TextBox)obj;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate ()
                {
                    if (message.Text == "")
                    {
                        MessageBox.Show("Уже пора!");
                    }
                    else
                    {
                        MessageBox.Show(message.Text);
                    }
                }
            );
            //if (message.Text == "")
            //{
            //    MessageBox.Show("Уже пора!");
            //}
            //else
            //{
            //    MessageBox.Show(message.Text);
            //}
        }
    }

}
