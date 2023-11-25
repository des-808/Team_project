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
        private RelayCommand copyComand;
        private RelayCommand addComand;
        private RelayCommand updateComand;
        private RelayCommand deleteComand;
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

        private void AddMethod()//в данный момент не рабочий
        {
            //Book book = new Book();
            //if (book is null) return;
            //if (selectedBook is null)
            //    return;
            //book.BookId = 0;
            //book.Title = SelectedBook.Title;
            //book.Description = SelectedBook.Description;
            //book.AuthorFkNavigation.LastName = SelectedBook.AuthorFkNavigation.LastName;
            //book.AuthorFkNavigation.LastName = SelectedBook.AuthorFkNavigation.LastName;
            //book.CategoryFkNavigation.CategoryName = SelectedBook.CategoryFkNavigation.CategoryName;
            //db.Books.Add(book);
            //db.SaveChanges();
            Book book = new Book();
            if (selectedBook is null) return;
            book.Title = selectedBook.Title;
            book.Description = selectedBook.Description;
            Author author = new Author();
            author.FirstName = selectedBook.FirstName;
            author.LastName = selectedBook.AuthorFkNavigation.LastName;
            Category category = new Category();
            category.CategoryName = selectedBook.CategoryFkNavigation.CategoryName;
            db.Add(book);
            db.Add(author);
            db.Add(category);
            //db.Books.Add(book);
            db.SaveChanges();

        }

        private void DeleteMethod(Book obj)
        {
            Book? book = obj as Book;
            if (book == null) return;
            db.Books.Remove(book);
            db.SaveChanges();
            //MessageBox.Show("Удаляем что-то");
        }
        private void UpdateMethod(Book SelectedBook) 
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
        private void CopyMethod(Book obj)
        {   
            if (obj == null) return;
            Book? book = obj as Book;

            Book newBook = new Book();
            newBook.Title = book.Title;
            newBook.Description = book.Description;
            newBook.AuthorFk = book.AuthorFk;
            newBook.AuthorFk = book.AuthorFk;
            newBook.CategoryFk = book.CategoryFk;
            db.Books.Add(book);
            db.SaveChanges();
            //MessageBox.Show("Удаляем что-то");
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addComand ?? new RelayCommand(obj => { AddMethod(); });
                //return addComand ?? new RelayCommand(obj => { CopyMethod(SelectedBook); });
            }
        } 
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteComand ?? new RelayCommand(obj => { DeleteMethod(SelectedBook); });
            }
        }
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateComand ?? new RelayCommand(obj => { UpdateMethod(SelectedBook); });
            }
        }
        public RelayCommand CopyCommand
        {
            get
            {
                return copyComand ?? new RelayCommand(obj => { CopyMethod(SelectedBook); });
            }
        }

    }
}
