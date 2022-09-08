using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFU25EF.Entities
{
    public class Book
    {
        
            public int Id { get; set; }
            public string Title { get; set; }
            public int Year { get; set; }          
             public int AuthorID { get; set; }          
            public Author Author { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();

       

    }
}
