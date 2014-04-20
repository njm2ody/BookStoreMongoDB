using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreLogicLayer;

namespace GUI_Form
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        LogicLayer logic;

        private void MainForm_Load(object sender, EventArgs e)
        {
            logic = new LogicLayer("BookStore");
            
            foreach (Book b in logic.GetAllBooks())
            {
                booksList.Items.Add(b.Title + '\t' + b.Author + '\t' + b.Price + '\t' + b.Count);

                booksGrid.Columns;
            }
        }
    }
}
