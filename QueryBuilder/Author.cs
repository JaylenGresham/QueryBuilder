using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    class Author : IClassModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public Author()
        {

        }

        public Author(int Id, string FirstName, string Surname)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.Surname = Surname;
        }
    }       
}
