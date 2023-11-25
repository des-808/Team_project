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
            db.Authors.Load();
            db.Categories.Load();
            BooksObserv = db.Books.Local.ToObservableCollection();
        }

        private void AddMethod()
        {
            Book book = new Book();
            if (book is null) return;
            if (selectedBook is null)
                return;
            book.Title = SelectedBook.Title;
            book.Description = SelectedBook.Description;
            book.AuthorFkNavigation.FirstName = SelectedBook.AuthorFkNavigation.FirstName;
            book.AuthorFkNavigation.LastName = SelectedBook.AuthorFkNavigation.LastName;
            book.CategoryFkNavigation.CategoryName = SelectedBook.CategoryFkNavigation.CategoryName;
            db.Books.Add(book);
            db.SaveChanges();
        }

        private void DeleteMethod(Object obj)
        {
            Book? book = obj as Book;
            if (book == null) return;
            db.Books.Remove(book);
            db.SaveChanges();
            //MessageBox.Show("Удаляем что-то");
        }

        private void EditMethod(Book SelectedBook) 
        {
            if (SelectedBook is null) return;
            Book? book = SelectedBook;
            book.Title = SelectedBook.Title;
            book.Description = SelectedBook.Description;
            book.AuthorFkNavigation.FirstName = SelectedBook.AuthorFkNavigation.FirstName;
            book.AuthorFkNavigation.LastName = SelectedBook.AuthorFkNavigation.LastName;
            book.CategoryFkNavigation.CategoryName = SelectedBook.CategoryFkNavigation.CategoryName;
            db.Books.UpdateRange(book);
            db.SaveChanges();    
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
            get
            {
                return deleteComand ?? new RelayCommand(obj => { DeleteMethod(SelectedBook); });
            }
        }

        
        public RelayCommand EditCommand
        {
            get
            {
                return editComand ?? new RelayCommand(obj => { EditMethod(SelectedBook); });
            }
        }

    }
}
