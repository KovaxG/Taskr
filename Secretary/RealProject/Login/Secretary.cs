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
    public partial class Secretary : Form
    {
        
        // Database handler: methods with queries
        DatabaseHandler db = new DatabaseHandler();
        // Methods which check if a string contains only letter, only numbers, etc
        VerifyText verify_text = new VerifyText();
        // The id of the user
        int secretary_id;
        // Tables filled with data from database
        DataTable user_table = new DataTable();
        DataTable formeruser_table = new DataTable();
        DataTable secretary_table = new DataTable();
        DataTable formersecretary_table = new DataTable();

        // Constructor 
        public Secretary(int id)
        {
            InitializeComponent();

            // Get id from Login
            secretary_id = id;
            setAvatarImage();
            setDisplayName();
            setStatus();
            setUserData();
            setFormerUserData();
            setSecretaryData();
            setFormerSecretaryData();
        }
        
        // Edit profile
        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            EditUserDetails Form = new EditUserDetails(secretary_id);
            Form.ShowDialog();
            this.Show();
            setDisplayName();
            setAvatarImage();
        }

        // Logout
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Refresh button
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            setAvatarImage();
            setStatus();
            setUserData();
            setFormerSecretaryData();
            setSecretaryData();
            setFormerSecretaryData();
        }

        // Create new user
        private void buttonCreateNewUser_Click(object sender, EventArgs e)
        {
            NewUser form = new NewUser(secretary_id);
            form.ShowDialog();
            this.Show();
            setUserData();
            setSecretaryData();
        }

        // Change status
        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s;
            s = comboBoxStatus.SelectedItem.ToString();
            db.updateStatusSecretary(secretary_id,s);
        }

        /* <---------------------------------------- DATAGRIDVIEW ACTIONS ----------------------------------------> */
        // Edit and remove user
        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewUsers.CurrentCell.RowIndex;
            int columnIndex = dataGridViewUsers.CurrentCell.ColumnIndex;

            // Edit button
            if (columnIndex == 0)
            {
                DataGridViewRow row = dataGridViewUsers.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                EditEmployee form = new EditEmployee(id);
                form.ShowDialog();
                this.Show();
                setUserData();
            }

            // Remove button
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
                    setUserData();
                    setFormerUserData();
                }
            }
        }

        // Edit former user
        private void dataGridViewFormerUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewFormerUsers.CurrentCell.RowIndex;
            int columnIndex = dataGridViewFormerUsers.CurrentCell.ColumnIndex;

            // Edit button
            if (columnIndex == 0)
            {
                DataGridViewRow row = dataGridViewFormerUsers.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                EditFormerEmployee form = new EditFormerEmployee(id);
                form.ShowDialog();
                this.Show();
                setFormerUserData();
            }
           
        }

        // Edit secretary
        private void dataGridViewSecretary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewSecretary.CurrentCell.RowIndex;
            int columnIndex = dataGridViewSecretary.CurrentCell.ColumnIndex;
            
            // Edit button
            if (columnIndex == 0)
            {
                DataGridViewRow row = dataGridViewSecretary.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                EditSecretary form = new EditSecretary(id);
                form.ShowDialog();
                this.Show();
                setSecretaryData();
            }

            // Remove button
            if(columnIndex == 1)
            {
                DataGridViewRow row = dataGridViewSecretary.Rows[rowIndex];
                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                RemoveSecretary form = new RemoveSecretary(id);
                form.ShowDialog();
                this.Show();
                setSecretaryData();
                setFormerSecretaryData();
            }
        }

        // Edit former secretary
        private void dataGridViewFormerSecretary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewFormerSecretary.CurrentCell.RowIndex;
            int columnIndex = dataGridViewFormerSecretary.CurrentCell.ColumnIndex;
            
            // Edit button
            if (columnIndex == 0)
            {
                DataGridViewRow row = dataGridViewFormerSecretary.Rows[rowIndex];
                int id = Int32.Parse(row.Cells[1].Value.ToString());
                EditFormerSecretary form = new EditFormerSecretary(id);
                form.ShowDialog();
                this.Show();
                setFormerSecretaryData();
            }
        }
        
         
        /* <---------------------------------------- SEARCH PROPERTY ----------------------------------------> */
        private void textBoxSearchUserFirstName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchUserFirstName.Text;
            string searchLastName = textBoxSearchUserLastName.Text;


            if (verify_text.HasOnlyLettersOrNull(searchFirstName) && verify_text.HasOnlyLettersOrNull(searchLastName))
            {
                user_table.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
                dataGridViewUsers.Refresh();
            }
            else
            {
                user_table.DefaultView.RowFilter = "FirstName like .";
                dataGridViewUsers.Refresh();
            }
        }

        private void textBoxSearchUserLastName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchUserFirstName.Text;
            string searchLastName = textBoxSearchUserLastName.Text;


            if (verify_text.HasOnlyLettersOrNull(searchFirstName) && verify_text.HasOnlyLettersOrNull(searchLastName))
            {
                user_table.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
                dataGridViewUsers.Refresh();
            }
            else
            {
                user_table.DefaultView.RowFilter = "FirstName like .";
                dataGridViewUsers.Refresh();
            }
        }

        private void textBoxSearchFormerSecretaryFirstName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchFormerSecretaryFirstName.Text;
            string searchLastName = textBoxSearchFormerSecretaryLastName.Text;

            if (verify_text.HasOnlyLettersOrNull(searchFirstName) && verify_text.HasOnlyLettersOrNull(searchLastName))
            {
                formersecretary_table.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
                dataGridViewSecretary.Refresh();
            }
            else
            {
                formersecretary_table.DefaultView.RowFilter = "FirstName like .";
                dataGridViewFormerSecretary.Refresh();
            }
        }

        private void textBoxSearchFormerSecretaryLastName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchFormerSecretaryFirstName.Text;
            string searchLastName = textBoxSearchFormerSecretaryLastName.Text;

            if (verify_text.HasOnlyLettersOrNull(searchFirstName) && verify_text.HasOnlyLettersOrNull(searchLastName))
            {
                formersecretary_table.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
                dataGridViewSecretary.Refresh();
            }
            else
            {
                formersecretary_table.DefaultView.RowFilter = "FirstName like .";
                dataGridViewFormerSecretary.Refresh();
            }
        }

        private void textBoxSearchFormerUserFirstName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchFormerUserFirstName.Text;
            string searchLastName = textBoxSearchFormerUserLastName.Text;

            if (verify_text.HasOnlyLettersOrNull(searchFirstName) && verify_text.HasOnlyLettersOrNull(searchLastName))
            {
                formeruser_table.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
                dataGridViewUsers.Refresh();
            }
            else
            {
                formeruser_table.DefaultView.RowFilter = "FirstName like .";
                dataGridViewFormerUsers.Refresh();
            }
        }

        private void textBoxSearchFormerUserLastName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchFormerUserFirstName.Text;
            string searchLastName = textBoxSearchFormerUserLastName.Text;

            if (verify_text.HasOnlyLettersOrNull(searchFirstName) && verify_text.HasOnlyLettersOrNull(searchLastName))
            {
                formeruser_table.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
                dataGridViewUsers.Refresh();
            }
            else
            {
                formeruser_table.DefaultView.RowFilter = "FirstName like .";
                dataGridViewFormerUsers.Refresh();
            }
        }

        private void textBoxSearchSecretaryFirstName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchSecretaryFirstName.Text;
            string searchLastName = textBoxSearchSecretaryLastName.Text;

            if (verify_text.HasOnlyLettersOrNull(searchFirstName) && verify_text.HasOnlyLettersOrNull(searchLastName))
            {
                secretary_table.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
                dataGridViewUsers.Refresh();
            }
            else
            {
                secretary_table.DefaultView.RowFilter = "FirstName like .";
                dataGridViewUsers.Refresh();
            }
        }

        private void textBoxSearchSecretaryLastName_TextChanged(object sender, EventArgs e)
        {
            string searchFirstName = textBoxSearchSecretaryFirstName.Text;
            string searchLastName = textBoxSearchSecretaryLastName.Text;

            if (verify_text.HasOnlyLettersOrNull(searchFirstName) && verify_text.HasOnlyLettersOrNull(searchLastName))
            {
                secretary_table.DefaultView.RowFilter = "FirstName like '" + searchFirstName + "%'" + "AND LastName like '" + searchLastName + "%'";
                dataGridViewUsers.Refresh();
            }
            else
            {
                secretary_table.DefaultView.RowFilter = "FirstName like .";
                dataGridViewUsers.Refresh();
            }
        }
        /* <---------------------------------------- SOME SET METHODS ----------------------------------------> */
        private void setDisplayName()
        {
            // Get and set displayname
            labelUsername.Text = db.getDisplayNameSecretary(secretary_id);
        }

        private void setAvatarImage()
        {
            // Get and set photo
            pictureAvatar.ImageLocation = db.getAvatarLinkSecretary(secretary_id).ToString();
        }

        private void setUserData()
        {
            // Get and set user data
            DataSet dsEmployees = db.loadEmployees();
            dataGridViewUsers.DataSource = dsEmployees.Tables["users"];
            user_table = dsEmployees.Tables["users"];
        }

        private void setFormerUserData()
        {
            // Get and set former user data
            DataSet dsFormerEmployees = db.loadFormerEmployees();
            dataGridViewFormerUsers.DataSource = dsFormerEmployees.Tables["users"];
            formeruser_table = dsFormerEmployees.Tables["users"];
        }

        private void setSecretaryData()
        {
            // Get and set secretary data
            DataSet dsSecretary = db.loadSecretary();
            dataGridViewSecretary.DataSource = dsSecretary.Tables["secretary"];
            secretary_table = dsSecretary.Tables["secretary"];
        }

        private void setFormerSecretaryData()
        {
            // Get and set fromer secretary data
            DataSet dsFormerSecretary = db.loadFormerSecretary();
            dataGridViewFormerSecretary.DataSource = dsFormerSecretary.Tables["secretary"];
            formersecretary_table = dsFormerSecretary.Tables["secretary"];
        }

        private void setStatus()
        {
            // Get and set status
            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.Add("Available");
            comboBoxStatus.Items.Add("Working");
            comboBoxStatus.Items.Add("Day off");
            comboBoxStatus.Items.Add("Holiday");
            comboBoxStatus.Items.Add("Sick");
            comboBoxStatus.Text = db.getStatusSecretary(secretary_id);
        }
    }
}
