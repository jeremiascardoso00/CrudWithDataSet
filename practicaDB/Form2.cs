using System;
using System.Windows.Forms;

namespace practicaDB
{
    public partial class Form2 : Form
    {
        private int? Id;
        // method to insert
        // The steps are the following:
        // 1_ once we have a DB with data and a DataSet with a TableAdapter to be able to pass the info
        // the following is to instantiate the TableAdapter
        private userDSTableAdapters.UsersTableAdapter usersTableAdapter = new userDSTableAdapters.UsersTableAdapter();
        public Form2(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if (Id!=null)
            {
                
            }
        }

        public void Insert()
        {
            // 2_Once the method is done in the DataAdapter, all we have to do is invoke it
            // passing it the parameters it requests
            usersTableAdapter.Add(textBox1.Text.Trim(), textBox2.Text.Trim());
        }

        public void Edit()
        {
            usersTableAdapter.UpdateQuery(textBox1.Text.Trim(), textBox2.Text.Trim(), (int)Id);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(this.Id == null)
            {
                Insert();
            }
            else
            {
                Edit();
            }
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Id != null)
            {
                //bringing the result of the select, it only brings me the row with the sent id
                userDS.UsersDataTable usersDataTable = usersTableAdapter.GetDataById((int)Id);
                userDS.UsersRow userRow = (userDS.UsersRow)usersDataTable.Rows[0];
                textBox1.Text = userRow.firstName;
                textBox2.Text = userRow.lastName;
            }
        }
    }
}
