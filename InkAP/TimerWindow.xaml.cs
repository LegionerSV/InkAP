using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading.Tasks;
using Hotkeys;

namespace InkAP
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timerwindow : Window
    {
        private bool IsTiming;
        private TimeSpan tim1; 
        private TimeSpan tim2;
        private int NowTiming;
        System.Timers.Timer myT;

        delegate void Handle(object o, KeyEventArgs e);

        public Timerwindow()
        {
            InitializeComponent();
            IsTiming = false;
            tim1 = new TimeSpan(6, 0, 0);
            label2.Content = tim1;
            tim2 = new TimeSpan(0, 0, 0);
            label3.Content = tim2;
            NowTiming = 1;
            myT = new System.Timers.Timer(1000);
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTiming)
            {
                IsTiming = true;
                button1.Content = "Переключить";
                myT.Enabled = true;
                myT.Elapsed+= new System.Timers.ElapsedEventHandler(myT_Elapsed);
                
            }
            else
            {
                if (NowTiming == 1) NowTiming = 2;
                else NowTiming = 1;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            tim1 = new TimeSpan(6, 0, 0);
            label2.Content = tim1;
            tim2 = new TimeSpan(0, 0, 0);
            label3.Content = tim2;
            button1.Content = "Пуск";
            button2.Content = "Стоп";
            myT.Enabled = false;
        }

        private void myT_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            if (NowTiming == 1)
            {
                tim1 = tim1.Subtract(new TimeSpan(0, 0, 1));
                this.Dispatcher.Invoke(new Action(() =>
                    {
                        this.label2.Content = tim1;
                        //this.UpdateLayout();
                    }));
            }
            else
            {
                tim2 = tim2.Add(new TimeSpan(0, 0, 1));
                this.Dispatcher.Invoke(new Action(() =>
                {
                    this.label3.Content = tim2;
                    //this.UpdateLayout();
                }));
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (myT.Enabled)
            {
                myT.Enabled = false;
                button2.Content = "Запуск";
            }
            else
            {
                myT.Enabled = true;
                button2.Content = "Пауза";
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                button1_Click(sender, e);
            }
        }
    }
}
