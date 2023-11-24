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
        private Book? selectedBook;
        public ObservableCollection<Book> BooksObserv { get; set; }

        public Book SelectedUser
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedUser");
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
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? new RelayCommand(obj => { AddMethod(); });
            }
        }

        private RelayCommand deleteComand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteComand ?? new RelayCommand(obj => { DeleteMethod(); });
            }
        }

        private RelayCommand updateComand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateComand ?? new RelayCommand(obj => { DeleteMethod(); });
            }
        }
    }
}
