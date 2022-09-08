using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFU25EF.Entities;

namespace SFU25EF
{
    public class AuthorRepositary
    {
       
        /// Получить книгу по ID       
        public Author GetAuthorByID(int id)
        {
            using (var db = new AppContext())
            {
                return db.Authors.Where(c => c.Id == id).FirstOrDefault();
            }
        }
    }
}
