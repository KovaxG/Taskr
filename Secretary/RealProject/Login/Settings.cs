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
    public partial class Settings : Form
    {


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
        public Settings()
        {
            InitializeComponent();
            setTheme();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (radioButtonCustom.Checked)
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Selected theme.txt");
                StreamWriter theme = new StreamWriter(path);
                theme.WriteLine("Colors");
                theme.Close();
                path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Colors.txt");
                StreamWriter Colors = new StreamWriter(path);
                Colors.WriteLine(ButtonTextColor.ToArgb().ToString());
                Colors.WriteLine(ButtonBackColor.ToArgb().ToString());
                Colors.WriteLine(FormTextColor.ToArgb().ToString());
                Colors.WriteLine(FormBackColor.ToArgb().ToString());
                Colors.WriteLine(PanelTextColor.ToArgb().ToString());
                Colors.WriteLine(PanelBackColor.ToArgb().ToString());
                Colors.WriteLine(TabpageTextColor.ToArgb().ToString());
                Colors.WriteLine(TabpageBackColor.ToArgb().ToString());
                Colors.WriteLine(TextboxTextColor.ToArgb().ToString());
                Colors.WriteLine(TextboxBackColor.ToArgb().ToString());
                Colors.Close();
                MessageBox.Show("Successfully updated!");
                this.Close();
            }
            if (radioButtonGray.Checked)
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Selected theme.txt");
                StreamWriter theme = new StreamWriter(path);
                theme.WriteLine("Gray");
                theme.Close();
                MessageBox.Show("Successfully updated!");
                this.Close();
            }

            if (radioButtonPurple.Checked)
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Selected theme.txt");
                StreamWriter theme = new StreamWriter(path);
                theme.WriteLine("Purple");
                theme.Close();
                MessageBox.Show("Successfully updated!");
                this.Close();
            }

            if (radioButtonTaskr.Checked)
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Selected theme.txt");
                StreamWriter theme = new StreamWriter(path);
                theme.WriteLine("Taskr");
                theme.Close();
                MessageBox.Show("Successfully updated!");
                this.Close();
            }
            if (!radioButtonCustom.Checked && !radioButtonGray.Checked && !radioButtonPurple.Checked && !radioButtonTaskr.Checked)
            {
                MessageBox.Show("Please select an option.");
            }

        }

        private void buttonButtonTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ButtonTextColor = colorDialog1.Color;
                buttonButtonTextColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonButtonBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ButtonBackColor = colorDialog1.Color;
                buttonButtonBackColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonTabpageTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TabpageTextColor = colorDialog1.Color;
                buttonTabpageTextColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonTabpageBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TabpageBackColor = colorDialog1.Color;
                buttonTabpageBackColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonTextboxTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TextboxTextColor = colorDialog1.Color;
                buttonTextboxTextColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonTextboxBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TextboxBackColor = colorDialog1.Color;
                buttonTextboxBackColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonPanelTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                PanelTextColor = colorDialog1.Color;
                buttonPanelTextColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonPanelBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                PanelBackColor = colorDialog1.Color;
                buttonPanelBackColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonFormTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                FormTextColor = colorDialog1.Color;
                buttonFormTextColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonFormBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                FormBackColor = colorDialog1.Color;
                buttonFormBackColor.BackColor = colorDialog1.Color;
            }
        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCustom.Checked)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        c.Enabled = true;
                    }
                }
            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Button && c != buttonAccept && c != buttonCancel)
                    {
                        c.Enabled = false;
                    }
                }
            }
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
            foreach (Control c in this.Controls)
            {
                setColorControls(c);
            }
        }

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
