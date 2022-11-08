using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    class BooksOutOnLoan : IClassModel
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public string DateIssued { get; set; }
        public string DueDate { get; set; }
        public string DateReturned { get; set; }
        public int UserId { get; set; }
        public BooksOutOnLoan()
        {

        }

        public BooksOutOnLoan(int Id, int BookId, string DateIssued, string DueDate, string DateReturned, int UserId)
        {
            this.Id = Id;
            this.BooksId = BookId;
            this.DateIssued = DateIssued;
            this.DueDate = DueDate;
            this.DateReturned = DateReturned;
            this.UserId = UserId;
        }

    }
}
