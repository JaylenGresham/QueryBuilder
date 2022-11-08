using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    class BookCategory : IClassModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public BookCategory()
        {

        }

        public BookCategory(int Id, int BookId, int CategoryId)
        {
            this.Id = Id;
            this.BookId = BookId;
            this.CategoryId = CategoryId;
        }
    }
}
