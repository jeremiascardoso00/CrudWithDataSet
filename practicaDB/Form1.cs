using System;
using System.Windows.Forms;

namespace practicaDB
{
    public partial class Form1 : Form
    {
        // select command
        // The steps are the following:
        // 1_ once we have a DB with data and a DataSet with a TableAdapter to be able to pass the info
        // the following is to instantiate the TableAdapter
        private userDSTableAdapters.UsersTableAdapter usersTableAdapter = new userDSTableAdapters.UsersTableAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        public void RefreshInfo()
        {
            // 2_Create a DataTable object within the DataSet and tell it that it will be the same
            // that the selection method that we had defined in the creation of the TableAdapter
            userDS.UsersDataTable usersDataTable = usersTableAdapter.GetData();


            // 3_Finally we define the DataSource of our dataGridView = to the DataTable that we obtained from
            // TableAdapter "usersDataTable"
            dataGridView1.DataSource = usersDataTable;
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshInfo();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            RefreshInfo();
        }

        //function to obtain the id in the data grid view
        private int? GetId()
        {
            try
            {
                return int.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                Form2 form2 = new Form2(Id);
                form2.ShowDialog();
                RefreshInfo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                usersTableAdapter.DeleteQuery((int)Id);
                RefreshInfo();
            }
        }
    }
}
