using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public class ListBook
    {
        private List<Books> list;
        public ListBook()
        {
            List = new List<Books>();
        }

        

        public List<Books> List { get => list; set => list = value; }

        public Books GetBookID (int id)
        {
            foreach (Books item in List)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public bool AddBook(Books book)
        {
            if(GetBookID(book.Id) != null)
            {
                MessageBox.Show("ID existed", "Book Management", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                List.Add(book);
            }
            return true;
          
        }

        public bool RemoveBook (int id)
        {
            Books book = GetBookID(id);
            if (book == null)
            {
                return false;
            }
            else
            {
                List.Remove(book);
            }
            return true;
        }


    }
}
