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
using Microsoft.Win32;

namespace Cinema.WPF.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        private CinemaContext datacontext;
        public ObservableCollection<Film> Films { get; set; }
        public ObservableCollection<Photo> Photoes { get; set; }
        private Photo selP;
        public event PropertyChangedEventHandler PropertyChanged;
        private Film selIt;
        public string pp { get; set; }
        public int myid;
        public Photo SelP
        {
            get { return selP; }
            set
            {
                selP = value;
                // Delete.IsExecutable = _selectedEmployee != null && !_selectedEmployee.EmpPromotions.Any();
                //EmpPromotionCmd.IsExecutable = _selectedEmployee != null && _selectedEmployee.EmpPromotions.Any();
                RaisePropertyChanged("SelP");
                pp = selP.pathPhoto;
            }
        }
        public Film SelIt
        {
            get { return selIt; }
            set { selIt = value;
                myid = selIt.film_id;
               // Delete.IsExecutable = _selectedEmployee != null && !_selectedEmployee.EmpPromotions.Any();
                //EmpPromotionCmd.IsExecutable = _selectedEmployee != null && _selectedEmployee.EmpPromotions.Any();
                RaisePropertyChanged("SelIt");
               
            }
        }
        public ActionCommand Enter { get; set; }
        public ActionCommand Picsq { get; set; }
        public ActionCommand Clear { get; set; }
        public ActionCommand Delete { get; set; }
        public ActionCommand Save { get; set; }
        public ActionCommand ADD { get; set; }
        public ActionCommand AddPhoto { get; set; }
        public ActionCommand DelPhoto { get; set; }
        public MainWindowViewModel()
        {
            //myid = 7;
            datacontext = new CinemaContext();
            Films = new ObservableCollection<Film>(datacontext.Films.Include(x=>x.Photos));

            Enter = new ActionCommand(EditFilm) { IsExecutable = true };
            Clear = new ActionCommand(ClearFilm) { IsExecutable = true };
            ADD = new ActionCommand(AddFilm) { IsExecutable = true };
            AddPhoto = new ActionCommand(AddP) { IsExecutable = true };
            DelPhoto = new ActionCommand(DeletePhoto) { IsExecutable = true };
            Picsq = new ActionCommand(Pictures) { IsExecutable = true };
            Save = new ActionCommand(SaveFilm) { IsExecutable = true };
            //  Delete = new ActionCommand(DeleteEmployee);
            Photoes = new ObservableCollection<Photo>(datacontext.Photos.Include(x => x.Film));
            //DisplayedImagePath = Photoes.Select(x => x.pathPhoto)


            Delete = new ActionCommand(DeleteFilm) { IsExecutable = true };

        }
        private void DeletePhoto()
        {
            MessageBoxResult res = MessageBox.Show("Delete ?", SelP.pathPhoto,
               MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                datacontext.Photos.Remove(selP);
                datacontext.SaveChanges();
                Photoes.Remove(selP);
            }

        }
        private void AddP()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            Photo p = new Photo() { pathPhoto = open.FileName, isMain = true, film_id=selIt.film_id };
            Photoes.Add(p);
            selP = p;
            RaisePropertyChanged("SelP");
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        private void Pictures()
        {
            
           
            Pics window = new Pics();
            window.Show();

        }

        private void SaveFilm()
        {
            foreach (var film in Films.Where(film => film.film_id == 0))
            {
                datacontext.Films.AddOrUpdate(film);
            }
            datacontext.SaveChanges();

        }
        private void AddFilm()
        {
            
            Film f = new Film() { title = "-", about = " ", starring = " ", director = " " };
            
            Films.Add(f);
            selIt = f;
            RaisePropertyChanged("SelIt");
        }
        private void EditFilm()
        {
            Film f = new Film();
            Films.Add(f);
            datacontext.Films.AddOrUpdate(f);
        }
        private void ClearFilm()
        {
            Film f = new Film() { title = " ", about = " ", starring = " ", director = " " };
            Films.Add(f);
            selIt = f;
            RaisePropertyChanged("SelIt");
        }
        private void DeleteFilm()
        {
            MessageBoxResult res = MessageBox.Show("Delete ?", SelIt.title,
               MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                datacontext.Films.Remove(SelIt);
                datacontext.SaveChanges();
                Films.Remove(selIt);
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
