using Cinema.DataLayer.DBLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Windows;
using System.Data.Entity;
using System.Windows.Controls;

namespace Cinema.WPF.ViewModel
{
    class ScheduleViewModel : INotifyPropertyChanged, IDisposable
    {
        private CinemaContext datacontext;
        public ObservableCollection<Film> Films { get; set; }
        public ObservableCollection<SessionsDate> sesd { get; set; }
        public ObservableCollection<Hall> halls { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string SearchCriteria { get; set; }
        public string SelIt2 { get; set; }
        public string SelIt3 { get; set; }
        public DateTime SelDate { get; set; }
        private Film selIt;
        public int hours { get; set; }
        public int min { get; set; }
        
        public Film SelIt
        {
            get { return selIt; }
            set
            {
                selIt = value;
                // Delete.IsExecutable = _selectedEmployee != null && !_selectedEmployee.EmpPromotions.Any();
                //EmpPromotionCmd.IsExecutable = _selectedEmployee != null && _selectedEmployee.EmpPromotions.Any();
                RaisePropertyChanged("SelIt");
            }
        }
       
        public ActionCommand Save { get; set; }
        public ActionCommand Search { get; set; }
        public ActionCommand ADD { get; set; }
        public ScheduleViewModel()
        {
            
            datacontext = new CinemaContext();
            Films = new ObservableCollection<Film>(datacontext.Films.Include(x => x.Photos));
            Film f = Films.Single(x=>x.film_id==7);
            halls = new ObservableCollection<Hall>(datacontext.Halls.Include(x=>x.Statuss));
            sesd = new ObservableCollection<SessionsDate>(datacontext.SessionsDates.Include(y=>y.Film));
            Search = new ActionCommand(SearchFilm) { IsExecutable = true };
            Save = new ActionCommand(SaveFilm) { IsExecutable = true };
            ADD = new ActionCommand(AddSession) { IsExecutable = true };
        }
        private void AddSession()
        {
            
                if (hours <= 24 && min <= 60)
                {
                if (SelIt2 != null && SelIt3 != null)
                {
                    DateTime md = new DateTime(SelDate.Year, SelDate.Month, SelDate.Day, hours, min, 00);
                    int hid = 0;
                    int fid = 0;
                    foreach (var item in datacontext.Films.Where(x => x.title.Contains(SelIt2)))
                    {
                        fid = item.film_id;
                    }
                    foreach (var item in datacontext.Halls.Where(x => x.name.Contains(SelIt3)))
                    {
                        hid = item.hall_id;
                    }
                    SessionsDate ses = new SessionsDate() { film_id = fid, hall_id = hid, sesDate = md };
                    sesd.Add(ses);
                   
                }
                else
                {
                    MessageBox.Show("Fill all fields");
                }   
                }
                else
                {
                    MessageBox.Show("Wrong time");
                }
           


            //Film f = new Film() { title = "-", about = " ", starring = " ", director = " " };

            //Films.Add(f);

        }
        private void SaveFilm()
        {
            foreach (var item in sesd.Where(ses => ses.ses_id == 0))
            {
                datacontext.SessionsDates.AddOrUpdate(item);
            }
            datacontext.SaveChanges();

        }
        private void SearchFilm()
        {
            sesd.Clear();

            foreach (var seminar in datacontext.SessionsDates.Where(ses => ses.Film.title.Contains(SearchCriteria)))
            {
                sesd.Add(seminar);
            }

            
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
       

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
