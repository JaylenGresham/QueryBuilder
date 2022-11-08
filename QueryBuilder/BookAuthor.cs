using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    class BookAuthor : IClassModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public BookAuthor()
        {

        }

        public BookAuthor(int Id, int BookId, int AuthorId)
        {
            this.Id = Id;
            this.BookId = BookId;
            this.AuthorId = AuthorId;
        }
    }

}
