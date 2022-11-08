using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    class Books : IClassModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Isbn { get; set; }
        public string DateOfPublication { get; set; }

        public Books()
        {

        }

        public Books(int Id, string Title, int Isbn, string DateOfPublication)
        {
            this.Id = Id;
            this.Title = Title;
            this.Isbn = Isbn;
            this.DateOfPublication = DateOfPublication;
        }
    }
}
