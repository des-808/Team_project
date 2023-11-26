using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_project.Model
{
    public partial class BookAllProperty
    {
        public int BookAllPropertyId { get;private set; }
        public List<Author>? Authors { get; set; }
        public List<Book>? Books { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
