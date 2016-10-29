using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using users_files.Controller;

namespace users_files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            textBox1.Hide();
            textBox2.Hide();
            button2.Hide();

            
            int file_count = Int32.Parse(textBox1.Text);
            int user_count = Int32.Parse(textBox2.Text);

            Controller_data c = new Controller_data(user_count, file_count);
            Controlls_controller d = new Controlls_controller(c);
            
            Controls.Add(d.insert_table());
            Controls.Add(d.create_ID());
            Controls.Add(d.create_insertion());
            Controls.Add(d.create_textbox());
            Controls.Add(d.create_button());
            Controls.Add(d.create_button_for_read());
            Controls.Add(d.create_button_for_write());
            Controls.Add(d.create_button_for_delegate ());
            Controls.Add(d.create_texbox_for_all());

        }

        private void login_handler(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "Увійти")
            {
                b.Text = "Вийти";
                MessageBox.Show("Вхід виконано");
            }
            
            else
            {
                b.Text = "Увійти";
                MessageBox.Show("Вихід виконано");
            }
        }

        

}
}
