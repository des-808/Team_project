using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Team_project.Model;

namespace Team_project.ViewModel
{
    public class MainWindowViewModel : Notify
    {
        DbbooksContext db = new DbbooksContext();
        private RelayCommand addCommand;
        private RelayCommand deleteComand;
        private RelayCommand editComand;
        Book selectedBook;
        public ObservableCollection<Book> BooksObserv { get; set; }

        public Book SelectedBook
        {
            get { return selectedBook;}
            set{ selectedBook = value; OnPropertyChanged("SelectedBook"); }
        }
        
        public MainWindowViewModel()
        {
            db.Books.Load();
            BooksObserv = db.Books.Local.ToObservableCollection();
        }

        private void AddMethod()
        {
            Book book = new Book();
            book.Title = "капитанская будка";
            book.Description = "ХЗ";
            db.Books.Add(book);
            db.SaveChanges();
            //author.FirstName = "Федя"; author.LastName = "Форточкин";
            //author.Books = BooksObserv;
            //MessageBox.Show("Добавляем что-то");
        }

        private void DeleteMethod(Object obj)
        {

            MessageBox.Show("Удаляем что-то");
        }

        private void EditMethod() 
        {
            MessageBox.Show("Обновляем что-то");
        }

        
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? new RelayCommand(obj => { AddMethod(); });
            }
        }

        
        public RelayCommand DeleteCommand
        {
            //get
            //{
            //    return deleteComand ?? new RelayCommand(obj => { DeleteMethod(selectedItem); });
            //}

            get
            {
                return deleteComand ??
                  (deleteComand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      Book? book = selectedItem as Book;
                      if (book == null) return;
                      db.Books.Remove(book);
                      db.SaveChanges();
                  }));
            }
        }

        
        public RelayCommand EditCommand
        {
            get
            {
                return editComand ?? new RelayCommand(obj => { EditMethod(); });
            }
        }
    }
}
