using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Login
{
    public partial class RemoveEmployee : Form
    {
        // Id of the employee being removed
        int employee_id;

        // Instance of the class, used for verifying the data entered by the user
        VerifyText verify_text = new VerifyText();

        // Database handler which makes the connections to the database
        DatabaseHandler db = new DatabaseHandler();

        // Colors
        Color ButtonTextColor;
        Color ButtonBackColor;
        Color FormTextColor;
        Color FormBackColor;
        Color TextboxTextColor;
        Color TextboxBackColor;
        string theme_file;

        // Constructor
        public RemoveEmployee(int id)
        {
            InitializeComponent();
            employee_id = id;
            setTheme();
            // Take data from database and show it in form
            textBoxFirstName.Text = db.getFirstNameUser(employee_id);
            textBoxLastName.Text = db.getLastNameUser(employee_id);
        }

        // Cancel button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Reset button
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxFirstName.Text = db.getFirstNameUser(employee_id);
            textBoxLastName.Text = db.getLastNameUser(employee_id);
            textBoxReasonForLeaving.Text = "";
            textBoxRejoinDesirability.Text = "";
            textBoxObservations.Text = "";
            dateTimePickerLeaveDate.Value = DateTime.Now;
        }

        // Accept button
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string reasonforleaving = textBoxReasonForLeaving.Text;
            string rejoindesirability = textBoxRejoinDesirability.Text;
            string observations = textBoxObservations.Text;
            DateTime leavedate = dateTimePickerLeaveDate.Value;
            bool ok = true;

            // Verify reason for leaving
            if (verify_text.IsInjection(reasonforleaving) || !verify_text.HasOnlyLetters(reasonforleaving))
            {
                labelReasonForLeaving.Show();
                labelReasonForLeaving.Text = "Please insert only letters.";
                labelReasonForLeaving.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelReasonForLeaving.Hide();
            }

            // Verify rejoin desirability
            if (verify_text.IsInjection(rejoindesirability) || !verify_text.HasOnlyLetters(rejoindesirability))
            {
                labelRejoinDesirability.Show();
                labelRejoinDesirability.Text = "Please insert only letters.";
                labelRejoinDesirability.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelRejoinDesirability.Hide();
            }

            // Verify observations
            if (verify_text.IsInjection(observations))
            {
                labelObservations.Show();
                labelObservations.Text = "Please don't use SQL injection characters like ' or \\.";
                labelObservations.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelObservations.Hide();
            }

            // If all data is correct 
            if (ok == true)
            {
                db.updateReasonForLeavingUser(employee_id, reasonforleaving);
                db.updateRejoinDesirabilityUser(employee_id, rejoindesirability);
                db.updateLeaveDateUser(employee_id, leavedate);
                db.updateObservationsUser(employee_id, observations);
                db.deleteProjectRequestUser(employee_id);
                db.deleteTaskRequestUser(employee_id);
                db.deleteFromActiveProject(employee_id);
                db.deleteFromActiveTask(employee_id);
                MessageBox.Show("Succsessfully updated!");
                this.Close();
            }
        }

        // Set colors
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
            TextboxTextColor = Color.FromArgb(Convert.ToInt32(lines[8]));
            TextboxBackColor = Color.FromArgb(Convert.ToInt32(lines[9]));
            Colors.Close();
        }

        // Select theme
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
            foreach (Control c in this.Controls)
            {
                setColorControls(c);
            }
        }

        // Set colors in the form
        private void setColorControls(Control c)
        {
            if (c is Button)
            {
                c.ForeColor = ButtonTextColor;
                c.BackColor = ButtonBackColor;
            }

            if (c is TextBox)
            {
                c.ForeColor = TextboxTextColor;
                c.BackColor = TextboxBackColor;
            }

            this.ForeColor = FormTextColor;
            this.BackColor = FormBackColor;
        }
    }
}
