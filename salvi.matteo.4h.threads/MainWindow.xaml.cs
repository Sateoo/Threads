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

namespace salvi.matteo._4h.threads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int _Counter = 0; //RMW read modify write non è atomica, l'atomicità permette ad un solo thread alla volta di modifacare l'istruzione
        const int NGIRI = 1500;
        object obj = new object(); //creo un oggetto
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(Incrementa); //creo un nuovo thread
            t.Start();
        }


        void Incrementa()
        {
            for (int i = 0; i < NGIRI; i++)
            {
                lock(obj)// rendo counter atomico
                {
                    _Counter++; 
                }
                

                Dispatcher.Invoke //serve a far prendere a un altro thread quello che gli serve nel thread, in questo caso, della GUI; ogni volta aggiorna
                (
                    () => //lambda expression introdotte in c# 3.0 perchè possono utilizzare più CPU
                    { 
                        txtCounter1.Text = _Counter.ToString();
                    }
                );
                
                Thread.Sleep(1);
            }
        }
    }
}
