using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    class Categories : IClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Categories()
        {

        }

        public Categories(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
