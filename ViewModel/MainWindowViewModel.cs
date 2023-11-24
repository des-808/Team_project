using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_project.Model;

namespace Team_project.ViewModel
{
    public class MainWindowViewModel : Notify
    {
        DbbooksContext db = new DbbooksContext();
        //public string title;
        //public string description;
        public string lastName;
        public string firstName;
        public string category;
        public ObservableCollection<Book> BooksObserv { get; set; }

        public Book? selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }
        public MainWindowViewModel()
        {
            db.Books.Load();
            db.Authors.Load();
            db.Categories.Load();
            BooksObserv = db.Books.Local.ToObservableCollection();
        }

        private void AddMethod()
        {

        }

        private void DeleteMethod()
        {

        }

        private void UpdateMethod()
        {

        }

        private RelayCommand addCommand;
        private RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? new RelayCommand(obj => { AddMethod(); });
            }
        }

        private RelayCommand deleteComand;
        private RelayCommand DeleteCommand
        {
            get
            {
                return deleteComand ?? new RelayCommand(obj => { DeleteMethod(); });
            }
        }

        private RelayCommand updateComand;
        private RelayCommand UpdateCommand
        {
            get
            {
                return updateComand ?? new RelayCommand(obj => { DeleteMethod(); });
            }
        }
    }
}