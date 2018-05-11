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
            const int MINUTE = 60;
            const int SECOND = 60;
            const int MILISECOND = 1000;
            try
            {
                int startTime = (int.Parse(hourTimeStartTextBox.Text) * MINUTE * SECOND * MILISECOND) + (int.Parse(minuteTimeStartTextBox.Text) * SECOND * MILISECOND) + (int.Parse(secondTimeStartTextBox.Text) * MILISECOND);
                int intervalTime = (int.Parse(hourTimeIntervalTextBox.Text) * MINUTE * SECOND * MILISECOND) + (int.Parse(minuteTimeIntervalTextBox.Text) * SECOND * MILISECOND) + (int.Parse(secondTimeIntervalTextBox.Text) * MILISECOND);
                _timer = new Timer(new TimerCallback(ShowMessage), messageTextBox, startTime, intervalTime);
            }
            catch
            {
                MessageBox.Show("Не правильно задано время");
            }
        }

        private void IsOnUnchecked(object sender, RoutedEventArgs e)
        {
            _timer.Dispose();
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
        }
    }

}
