using Cinema.WPF.ViewModel;
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

namespace Cinema.WPF
{
    /// <summary>
    /// Interaction logic for Pics.xaml
    /// </summary>
    public partial class Pics : Window
    {
        public int filmidM { get; set; }
        public Pics()
        {
            InitializeComponent();
            PicsViewModel pvm = new PicsViewModel();
            pvm.filmid = filmidM;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
