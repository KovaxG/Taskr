using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Login
{
    public partial class HomePage : Form
    {
        private Login mainForm = null;
        DatabaseHandler db = new DatabaseHandler();
        int user;
        DataTable usersTable = new DataTable();
        DataTable formerusersTable = new DataTable();
        DataTable secretaryTable = new DataTable();
        DataTable formersecretaryTable = new DataTable();
        public HomePage(Form callingForm)
        {

            InitializeComponent();
            mainForm = callingForm as Login;
            user = this.mainForm.getUser;

            string URL = db.getAvatarLinkSecretary(user);
            pictureAvatar.ImageLocation = URL;

            DataSet dsEmployees = db.loadEmployees();
            dataGridViewUsers.DataSource = dsEmployees.Tables["users"];
            usersTable = dsEmployees.Tables["users"];
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewUsers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.AllowUserToAddRows = false;

            DataSet dsFormerEmployees = db.loadFormerEmployees();
            dataGridViewFormerUsers.DataSource = dsFormerEmployees.Tables["users"];
            formerusersTable = dsFormerEmployees.Tables["users"];
            dataGridViewFormerUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFormerUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewFormerUsers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewFormerUsers.AllowUserToAddRows = false;

            DataSet dsSecretary = db.loadSecretary();
            dataGridViewSecretary.DataSource = dsSecretary.Tables["secretary"];
            secretaryTable = dsSecretary.Tables["secretary"];
            dataGridViewSecretary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSecretary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewSecretary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewSecretary.AllowUserToAddRows = false;

            DataSet dsFormerSecretary = db.loadFormerSecretary();
            dataGridViewFormerSecretary.DataSource = dsFormerSecretary.Tables["secretary"];
            formersecretaryTable = dsFormerSecretary.Tables["secretary"];
            dataGridViewFormerSecretary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFormerSecretary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewFormerSecretary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewFormerSecretary.AllowUserToAddRows = false;

            labelUsername.Text = db.getDisplayNameSecretary(user);

            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.Add("Available");
            comboBoxStatus.Items.Add("Working");
            comboBoxStatus.Items.Add("Day off");
            comboBoxStatus.Items.Add("Holiday");
            comboBoxStatus.Items.Add("Sick");
            comboBoxStatus.Text = db.getStatusSecretary(user);

            
        }
        
        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            
            EditUserDetails Form = new EditUserDetails(this);
            Form.ShowDialog();
            this.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureAvatar_Click(object sender, EventArgs e)
        {
           
        }

        private void TabPageFormerUser_Click(object sender, EventArgs e)
        {

        }
        public int getUser
        {
            get { return user; }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string URL = db.getAvatarLinkSecretary(user);
            pictureAvatar.ImageLocation = URL;
            labelUsername.Text = db.getDisplayNameSecretary(user);
            comboBoxStatus.Text = db.getStatusSecretary(user);

            DataSet dsEmployees = db.loadEmployees();
            dataGridViewUsers.DataSource = dsEmployees.Tables["users"];
            usersTable = dsEmployees.Tables["users"];
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewUsers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.AllowUserToAddRows = false;

            DataSet dsFormerEmployees = db.loadFormerEmployees();
            dataGridViewFormerUsers.DataSource = dsFormerEmployees.Tables["users"];
            formerusersTable = dsFormerEmployees.Tables["users"];
            dataGridViewFormerUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFormerUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewFormerUsers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewFormerUsers.AllowUserToAddRows = false;

            DataSet dsSecretary = db.loadSecretary();
            dataGridViewSecretary.DataSource = dsSecretary.Tables["secretary"];
            secretaryTable = dsSecretary.Tables["secretary"];
            dataGridViewSecretary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSecretary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewSecretary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewSecretary.AllowUserToAddRows = false;

            DataSet dsFormerSecretary = db.loadFormerSecretary();
            dataGridViewFormerSecretary.DataSource = dsFormerSecretary.Tables["secretary"];
            formersecretaryTable = dsFormerSecretary.Tables["secretary"];
            dataGridViewFormerSecretary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFormerSecretary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewFormerSecretary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewFormerSecretary.AllowUserToAddRows = false;
          
        }

        private void buttonCreateNewUser_Click(object sender, EventArgs e)
        {
            NewUser form = new NewUser(this);
            form.ShowDialog();
            this.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s;
            s = comboBoxStatus.SelectedItem.ToString();
            db.updateStatusSecretary(user,s);

        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = dataGridViewUsers.CurrentCell.RowIndex;
            int columnIndex = dataGridViewUsers.CurrentCell.ColumnIndex;

            if (columnIndex == 0)
            {
                DataGridViewRow row = dataGridViewUsers.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                EditEmployee form = new EditEmployee(id);
                form.ShowDialog();
                this.Show();
            }
            if (columnIndex == 1)
            {

                DataGridViewRow row = dataGridViewUsers.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                if (db.checkIfProjectLeader(id))
                {
                    MessageBox.Show("Cannot delete employee! Ask employee to give his postion of Project Leader to someone else.");
                }
                else
                {
                    RemoveEmployee form = new RemoveEmployee(id);
                    form.ShowDialog();
                    this.Show();

                }

            }
         
        }

        private void dataGridViewFormerUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewFormerUsers.CurrentCell.RowIndex;
            int columnIndex = dataGridViewFormerUsers.CurrentCell.ColumnIndex;
            if (columnIndex == 0)
            {
                DataGridViewRow row = dataGridViewFormerUsers.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                EditFormerEmployee form = new EditFormerEmployee(id);
                form.ShowDialog();
                this.Show();
            }
           
        }

        private void dataGridViewSecretary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewSecretary.CurrentCell.RowIndex;
            int columnIndex = dataGridViewSecretary.CurrentCell.ColumnIndex;
            if (columnIndex == 0)
            {
                DataGridViewRow row = dataGridViewSecretary.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                EditSecretary form = new EditSecretary(id);
                form.ShowDialog();
                this.Show();
            }
            if(columnIndex == 1)
            {
                DataGridViewRow row = dataGridViewSecretary.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                RemoveSecretary form = new RemoveSecretary(id);
                form.ShowDialog();
                this.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewFormerSecretary.CurrentCell.RowIndex;
            int columnIndex = dataGridViewFormerSecretary.CurrentCell.ColumnIndex;
            if (columnIndex == 0)
            {
                DataGridViewRow row = dataGridViewFormerSecretary.Rows[rowIndex];
                int id = Int32.Parse(row.Cells[1].Value.ToString());
                EditFormerSecretary form = new EditFormerSecretary(id);
                form.ShowDialog();
                this.Show();
            }
        }
        
         

        private void textBoxSearchFirstName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchUserFirstName.Text;
            string searchLastName = textBoxSearchUserLastName.Text;

            usersTable.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
            dataGridViewUsers.Refresh();
        }

        private void textBoxSearchLastName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchUserFirstName.Text;
            string searchLastName = textBoxSearchUserLastName.Text;

            usersTable.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
            dataGridViewUsers.Refresh();
        }

        

        private void textBoxSearchFormerSecretaryFirstName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchFormerSecretaryFirstName.Text;
            string searchLastName = textBoxSearchFormerSecretaryLastName.Text;

            formersecretaryTable.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
            dataGridViewUsers.Refresh();
        }

        private void textBoxSearchFormerSecretaryLastName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchFormerSecretaryFirstName.Text;
            string searchLastName = textBoxSearchFormerSecretaryLastName.Text;

            formersecretaryTable.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
            dataGridViewUsers.Refresh();
        }

        private void textBoxSearchFormerUserFirstName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchFormerUserFirstName.Text;
            string searchLastName = textBoxSearchFormerUserLastName.Text;

            formerusersTable.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
            dataGridViewUsers.Refresh();
        }

        private void textBoxSearchFormerUserLastName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchFormerUserFirstName.Text;
            string searchLastName = textBoxSearchFormerUserLastName.Text;

            formerusersTable.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
            dataGridViewUsers.Refresh();
        }

        private void textBoxSearchSecretaryFirstName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchSecretaryFirstName.Text;
            string searchLastName = textBoxSearchSecretaryLastName.Text;

            secretaryTable.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
            dataGridViewUsers.Refresh();
        }

        private void textBoxSearchSecretaryLastName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchSecretaryFirstName.Text;
            string searchLastName = textBoxSearchSecretaryLastName.Text;

            secretaryTable.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
            dataGridViewUsers.Refresh();
        }

        private void dataGridViewSecretary_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

      
       
    }
}
