using Cinema.DataLayer.DBLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using Microsoft.Win32;

namespace Cinema.WPF.ViewModel
{
   public class PicsViewModel : INotifyPropertyChanged, IDisposable
    {
        private CinemaContext datacontext;
        public ObservableCollection<Film> Films { get; set; }
        public ObservableCollection<Photo> Photoes { get; set; }
        private Photo selP;
        public string pp { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public int filmid { get; set; }
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
        public ActionCommand Delete { get; set; }
        public ActionCommand Add { get; set; }

        public PicsViewModel()
        {
           
            datacontext = new CinemaContext();
            Films = new ObservableCollection<Film>(datacontext.Films.Include(x => x.Photos));
            Photoes = new ObservableCollection<Photo>(datacontext.Photos.Include(x => x.Film));
            Delete = new ActionCommand(DeletePicture) { IsExecutable = true };
            Add = new ActionCommand(AddPicture) { IsExecutable = true };
        }
        private void DeletePicture()
        {
            MessageBox.Show(filmid.ToString());

        }
        private void AddPicture()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            Photo p = new Photo() { pathPhoto=open.FileName,isMain=true,};
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
