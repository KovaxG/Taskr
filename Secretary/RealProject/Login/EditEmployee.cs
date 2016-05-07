using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class EditEmployee : Form
    {
        int ID;
        DatabaseHandler db = new DatabaseHandler();
        public EditEmployee(int id)
        {
            ID = id;
            InitializeComponent();
            textBoxId.Text = ID.ToString();
            textBoxFirstName.Text = db.getFirstNameUser(ID);
            textBoxLastName.Text = db.getLastNameUser(ID);
            textBoxDisplayName.Text = db.getDisplayNameUser(ID);
            textBoxAvatarLink.Text = db.getAvatarLinkUser(ID);
            textBoxPassword.Text = db.getPasswordHashUser(ID);
            textBoxEmail.Text = db.getEmailUser(ID);
            textBoxPhoneNumber.Text = db.getPhoneNumberUser(ID);
            dateTimePicker.Value = db.getJoinDateUser(ID);
            textBoxAddedBy.Text = db.getAddedByUser(ID).ToString();
            textBoxActiveProject.Text = db.getActiveProjectUser(ID).ToString();
            textBoxWorkStatus.Text = db.getStatusUser(ID);
            textBoxPersonalNotes.Text = db.getPersonalNotesUser(ID);



        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            
            textBoxId.Text = ID.ToString();
            textBoxFirstName.Text = db.getFirstNameUser(ID);
            textBoxLastName.Text = db.getLastNameUser(ID);
            textBoxDisplayName.Text = db.getDisplayNameUser(ID);
            textBoxAvatarLink.Text = db.getAvatarLinkUser(ID);
            textBoxPassword.Text = db.getPasswordHashUser(ID);
            textBoxEmail.Text = db.getEmailUser(ID);
            textBoxPhoneNumber.Text = db.getPhoneNumberUser(ID);
            dateTimePicker.Value = db.getJoinDateUser(ID);
            textBoxAddedBy.Text = db.getAddedByUser(ID).ToString();
            textBoxActiveProject.Text = db.getActiveProjectUser(ID).ToString();
            textBoxWorkStatus.Text = db.getStatusUser(ID);
            textBoxPersonalNotes.Text = db.getPersonalNotesUser(ID);
            

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string firstname = textBoxFirstName.Text;
            string lastname = textBoxLastName.Text;
            string displayname = textBoxDisplayName.Text;
            string avatarlink = textBoxAvatarLink.Text;
            string password = textBoxAvatarLink.Text;
            string email = textBoxEmail.Text;
            string phonenumber = textBoxPhoneNumber.Text;
            DateTime joindate = dateTimePicker.Value.Date;
            string workstatus = textBoxWorkStatus.Text;
            string personalnotes = textBoxPersonalNotes.Text;
            if (firstname != null && lastname != null && displayname != null && avatarlink != null && password != null && email != null && phonenumber != null && workstatus != null && personalnotes!=null)
            {
                db.updateFirstNameUser(ID, firstname);
                db.updateLastNameUser(ID, lastname);
                db.updateDisplayNameUser(ID, displayname);
                db.updateAvatarLinkUser(ID, avatarlink);
                db.updatePasswordUser(ID, password);
                db.updateEmailUser(ID, email);
                db.updatePhoneNumberUser(ID, phonenumber);
                db.updateJoinDateUser(ID, joindate);
                db.updateStatusUser(ID, workstatus);
                db.updatePersonalNotesUser(ID, personalnotes);
                MessageBox.Show("Update successful!");
            }
            else
            {
                MessageBox.Show("Please fill all fields!");

            }
        }
    }
}
