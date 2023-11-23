using System;
using System.Collections.Generic;

namespace Team_project.Model;

public partial class Author : Notify
{
    public int AuthorId { get; set; }


    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
