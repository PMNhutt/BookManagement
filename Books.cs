using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    public class Books
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public string author { get; set; }
        public int amount { get; set; }

        public Books(int id, string name, string publisher, int year, string author, int amount)
        {
            this.Id = id;
            this.Name = name;
            this.Publisher = publisher;
            this.Year = year;
            this.author = author;
            this.amount = amount;
        }




    }
}
