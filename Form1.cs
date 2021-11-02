using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class BookManagement : Form
    {
        private ListBook list;

        private int imgNum = 1;
        public BookManagement()
        {
            InitializeComponent();
            list = new ListBook();
        }

        #region Form
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit!", MessageBoxButtons.OKCancel) !=
                System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Reset();
            if (btnAdd.Text.Equals("Add"))
            {
                for (int i = 0 ; i < listView.SelectedItems.Count; i ++)
                {
                    listView.SelectedItems[i].Selected = false;
                }
                btnAdd.Text = "Cancel";                
                tBtnID.Enabled = true;
                tBtnName.Enabled = true;
                tBtnPublisher.Enabled = true;
                tBtnYear.Enabled = true;
                tBtnAuthor.Enabled = true;
                numUDAmount.Enabled = true;
                btnSave.Enabled = true;
                tBtnID.Focus();
            }
            else
            {
                btnAdd.Text = "Add";               
                tBtnID.Enabled = false;
                tBtnName.Enabled = false;
                tBtnPublisher.Enabled = false;
                tBtnYear.Enabled = false;
                tBtnAuthor.Enabled = false;
                numUDAmount.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = 0;
            int year = 0;
            string name = tBtnName.Text;
            string publisher = tBtnPublisher.Text;
            string author = tBtnAuthor.Text;
            int amount = (int)numUDAmount.Value;
            Boolean IsValidFormat()
            {
                if (string.IsNullOrEmpty(tBtnID.Text) || !Int32.TryParse(tBtnID.Text, out id))
                {
                    MessageBox.Show("Input data for ID is incorrect format!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tBtnID.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(tBtnYear.Text) || !Int32.TryParse(tBtnYear.Text, out year))
                {
                    MessageBox.Show("Input data for Year is incorrect format!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tBtnYear.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(tBtnName.Text))
                {
                    MessageBox.Show("Input data for Name cannot empty!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tBtnName.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(tBtnPublisher.Text))
                {
                    MessageBox.Show("Input data for Publisher cannot empty!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tBtnPublisher.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(tBtnAuthor.Text))
                {
                    MessageBox.Show("Input data for Author cannot empty!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tBtnAuthor.Focus();
                    return false;
                }

                return true;
            }

            while (IsValidFormat())
            {
                try
                {
                    Books book = new Books(id, name, publisher, year, author, amount);

                    if (list.AddBook(book))
                    {
                        UpdateListView(list.List);
                        Reset();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error", "Book Management", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    tBtnID.Focus();
                    tBtnID.SelectAll();
                    
                }
                break;
            } 
            
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Remove this line?", "Book Management",MessageBoxButtons.OKCancel);
            for (int i = 0; i < listView.SelectedItems.Count; i ++)
            {
                int id = int.Parse(listView.SelectedItems[i].SubItems[0].Text);
                if (d == DialogResult.OK)
                {
                    list.RemoveBook(id);
                }
            }
            UpdateListView(list.List);
        }

        

        #endregion


        #region Function

        void Reset()
        {
            tBtnID.Text = "";
            tBtnName.Text = "";
            tBtnPublisher.Text = "";
            tBtnYear.Text = "";
            tBtnAuthor.Text = "";
            numUDAmount.Value = 1;
        }

        void UpdateListView(List<Books> listb)
        {
            listView.Items.Clear();
            List<Books> list = listb;
            foreach (Books item in list)
            {
                //list view là add vô 1 item, và những cái sau là sub item
                ListViewItem listview = new ListViewItem(item.Id.ToString());
                listview.SubItems.Add(item.Name.ToString());
                listview.SubItems.Add(item.Publisher.ToString());
                listview.SubItems.Add(item.Year.ToString());
                listview.SubItems.Add(item.author.ToString());
                listview.SubItems.Add(item.amount.ToString());

                listView.Items.Add(listview);
            }
        }

        private void slider()
        {
            if (imgNum == 6)
            {
                imgNum = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"C:\Users\USER\source\repos\BookManagement\Images\{0}.png", imgNum);
            imgNum++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slider();
        }
        

       
        #endregion
    }
}
