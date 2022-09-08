using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFU25EF.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
                      
        public List<Book> Books { get; set; } = new List<Book> ();
    }
}
