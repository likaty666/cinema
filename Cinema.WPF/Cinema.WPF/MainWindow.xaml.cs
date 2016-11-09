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

namespace Cinema.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool flag { get; set; }
        public MainWindow()
        {
            if (flag == true)
            {
                Schedule win2 = new Schedule();
                win2.Show();
                this.Close();
            }
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Schedule win2 = new Schedule();
            win2.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //Pics p = new Pics();
            //p.Show();
            
        }
    }
}
