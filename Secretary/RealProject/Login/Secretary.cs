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
using System.IO;

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
        // Colors 
        Color ButtonTextColor;
        Color ButtonBackColor;
        Color FormTextColor;
        Color FormBackColor;
        Color PanelTextColor;
        Color PanelBackColor;
        Color TabpageTextColor;
        Color TabpageBackColor;
        Color TextboxTextColor;
        Color TextboxBackColor;
        string theme_file;
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
            setTheme();


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
            setTheme();
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

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            form.ShowDialog();
            this.Show();
            setTheme();
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
            comboBoxStatus.Items.Add("Not Available");
            comboBoxStatus.Text = db.getStatusSecretary(secretary_id);
        }

        private void setColors()
        {
            List<string> lines = new List<string>();
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", theme_file);
            StreamReader Colors = new StreamReader(path);
            while (!Colors.EndOfStream)
            {
                lines.Add(Colors.ReadLine());
            }
            ButtonTextColor = Color.FromArgb(Convert.ToInt32(lines[0]));
            ButtonBackColor = Color.FromArgb(Convert.ToInt32(lines[1]));
            FormTextColor = Color.FromArgb(Convert.ToInt32(lines[2]));
            FormBackColor = Color.FromArgb(Convert.ToInt32(lines[3]));
            PanelTextColor = Color.FromArgb(Convert.ToInt32(lines[4]));
            PanelBackColor = Color.FromArgb(Convert.ToInt32(lines[5]));
            TabpageTextColor = Color.FromArgb(Convert.ToInt32(lines[6]));
            TabpageBackColor = Color.FromArgb(Convert.ToInt32(lines[7]));
            TextboxTextColor = Color.FromArgb(Convert.ToInt32(lines[8]));
            TextboxBackColor = Color.FromArgb(Convert.ToInt32(lines[9]));
            Colors.Close();
        }

        private void setTheme()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Selected theme.txt");
            StreamReader r = new StreamReader(path);
            string text_file = r.ReadLine();
            r.Close();

            if (text_file == "Gray")
            {
                theme_file = "Gray.txt";
            }

            if (text_file == "Purple")
            {
                theme_file = "Purple.txt";
            }
            if (text_file == "Taskr")
            {
                theme_file = "Taskr.txt";
            }
            if (text_file == "Colors")
            {
                theme_file = "Colors.txt";
            }
            setColors();
            setColorControls();
        }

        private void setColorControls()
        {
            this.ForeColor = FormTextColor;
            this.BackColor = FormBackColor;

            panelSide.ForeColor = PanelTextColor;
            panelSide.BackColor = PanelBackColor;
            PanelUsers.ForeColor = PanelTextColor;
            PanelUsers.BackColor = PanelBackColor;

            tabPageFormerSecretary.ForeColor = TabpageTextColor;
            tabPageFormerSecretary.BackColor = TabpageBackColor;
            tabPageSecretary.ForeColor = TabpageTextColor;
            tabPageSecretary.BackColor = TabpageBackColor;
            TabPageFormerUser.ForeColor = TabpageTextColor;
            TabPageFormerUser.BackColor = TabpageBackColor;
            TabPageUsers.ForeColor = TabpageTextColor;
            TabPageUsers.BackColor = TabpageBackColor;

            textBoxSearchFormerSecretaryFirstName.ForeColor = TextboxTextColor;
            textBoxSearchFormerSecretaryFirstName.BackColor = TextboxBackColor;
            textBoxSearchSecretaryFirstName.ForeColor = TextboxTextColor;
            textBoxSearchSecretaryFirstName.BackColor = TextboxBackColor;
            textBoxSearchFormerUserFirstName.ForeColor = TextboxTextColor;
            textBoxSearchFormerUserFirstName.BackColor = TextboxBackColor;
            textBoxSearchUserFirstName.ForeColor = TextboxTextColor;
            textBoxSearchUserFirstName.BackColor = TextboxBackColor;
            textBoxSearchFormerSecretaryLastName.ForeColor = TextboxTextColor;
            textBoxSearchFormerSecretaryLastName.BackColor = TextboxBackColor;
            textBoxSearchSecretaryLastName.ForeColor = TextboxTextColor;
            textBoxSearchSecretaryLastName.BackColor = TextboxBackColor;
            textBoxSearchFormerUserLastName.ForeColor = TextboxTextColor;
            textBoxSearchFormerUserLastName.BackColor = TextboxBackColor;
            textBoxSearchUserLastName.ForeColor = TextboxTextColor;
            textBoxSearchUserLastName.BackColor = TextboxBackColor;

            buttonCreateNewUser.ForeColor = ButtonTextColor;
            buttonCreateNewUser.BackColor = ButtonBackColor;
            buttonEditProfile.ForeColor = ButtonTextColor;
            buttonEditProfile.BackColor = ButtonBackColor;
            buttonLogout.ForeColor = ButtonTextColor;
            buttonLogout.BackColor = ButtonBackColor;
            buttonRefresh.ForeColor = ButtonTextColor;
            buttonRefresh.BackColor = ButtonBackColor;
            buttonSettings.ForeColor = ButtonTextColor;
            buttonSettings.BackColor = ButtonBackColor;

            labelUsername.ForeColor = FormTextColor;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Secretary_Load(object sender, EventArgs e)
        {

        }

        
    }
}
