using Cinema.DataLayer.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.Entity;
using Cinema.Repository.Repositories;

namespace Cinema.WPF
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
      
        private CinemaContext datacontext;
        List<Film> films ;
        List<SessionsDate> sd;
        public Schedule()
        {
           
            InitializeComponent();
            films = new List<Film>();
            sd = new List<SessionsDate>();
            //add.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //datacontext = new CinemaContext();
            //films = new List<Film>(datacontext.Films.Include(x => x.Photos));
            //sd = new List<SessionsDate>(datacontext.SessionsDates.Include(i=>i.Film));
            //int count = 8;
            //int dayscount = 0;
            //int cols = 6;
            //int rows = 14;

            //List<string> days = new List<string> {"Sun","Mon", "Tue", "Wed", "Thu", "Sat" };

            //for (int c = 0; c < cols; c++)
            //{
            //    myTable.Columns.Add(new TableColumn());
            //}


            //for (int r = 0; r < rows; r++)
            //{
            //    TableRow tr = new TableRow();

            //    for (int c = 0; c < cols; c++)
            //    {

            //        if (c == 0 && r == 0)
            //        {
            //            tr.Cells.Add(new TableCell(new Paragraph(new Run("    /"))));
            //            //tr.Cells[c].BorderBrush = Brushes.Black;
            //            //tr.Cells[c].BorderThickness = new Thickness(0, 2, 1, 2);
            //        }
            //        else if (c == 0)
            //        {
            //            tr.Cells.Add(new TableCell(new Paragraph(new Run(count++.ToString()))));

            //        }

            //        if (r == 0)
            //        {
            //            tr.Cells.Add(new TableCell(new Paragraph(new Run(days[dayscount++].ToString()))));
            //            //tr.Cells[c].BorderBrush = Brushes.Black;
            //            //tr.Cells[c].BorderThickness = new Thickness(0, 2, 1, 2);
            //        }
            //        if (r == 1)
            //        {
            //            tr.Cells.Add(new TableCell(new Paragraph(new Run(films[0].ToString()))));
            //            //tr.Cells[c].BorderBrush = Brushes.Black;
            //            //tr.Cells[c].BorderThickness = new Thickness(0, 2, 1, 2);
            //        }
            //        else {

            //        }
            //    }



            //    TableRowGroup trg = new TableRowGroup();
            //    trg.Rows.Add(tr);
            //    myTable.RowGroups.Add(trg);
            //}
        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

           
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            dp.SelectedDate = DateTime.Now;
           
            //Rectangle exampleRectangle = new Rectangle();
            //exampleRectangle.Width = 150;
            //exampleRectangle.Height = 150;
            //// Create a SolidColorBrush and use it to
            //// paint the rectangle.
            //SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
            //exampleRectangle.Stroke = Brushes.Red;
            //exampleRectangle.StrokeThickness = 4;
            //exampleRectangle.Fill = myBrush;
            //canvas.Children.Insert(0, exampleRectangle);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
           
        }

        private void change_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
