using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using users_files.Controller;

namespace users_files
{
    class Controlls_controller
    {
        Controller_data data;
        private DataGridView T = new DataGridView();
        private Button login = new Button();
        private TextBox username = new TextBox();

        private Label id = new Label();
        private Label insertion = new Label();
        private Button read = new Button();
        private Button write = new Button();
        private Button todelegate = new Button();
        private TextBox file_to_do = new TextBox();
        


        public Controlls_controller(Controller_data c)
        {
            data = c;
        }

        public Label create_ID()
        {
            id.Left = 20;
            id.Top = 230;
            id.Text = "Ідентифікатор";
            return id;
        }

        public Label create_insertion()
        {
            insertion.Left = 235;
            insertion.Top = 230;
            insertion.Text = "Введіть файл";
            return insertion;
        }

        public DataGridView insert_table()
        {
            T.Dock = DockStyle.Top;
            T.AutoResizeColumns();
            T.ColumnCount = data.get_usercount()+1;
            T.RowCount = data.get_filecount()+1;
            T.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            T.Rows[0].Cells[0].Value = "Об'єкт / Суб'єкт";
            for (int i = 1; i < T.ColumnCount; i++)
            {
                T.Rows[0].Cells[i].Value = data.get_user(i - 1).Name;
            }

            for (int i = 1; i < T.RowCount; i++)
            {
                T.Rows[i].Cells[0].Value = data.get_file(i - 1).Name;
            }
            for (int i = 1; i < T.RowCount; i++)
            {
                for (int j = 1; j < T.ColumnCount; j++)
                {
                    T.Rows[i].Cells[j].Value = data.rigts_insertion(data.get_file(i-1), data.get_user(j - 1));
                }
            }
            MessageBox.Show("Введіть ідентифікатор користувача у вікно вводу!");
            return T;
        }

        public TextBox create_textbox()
        {
            username.Left = 20;
            username.Top = 210;
            return username;
        }
        public Button create_button()
        {
            login.Text = "Увійти";
            login.Left = 20;
            login.Top = 170;
            login.Click += login_click;
            return login;
        }
        private user insertion_correct()
        {
            for (int i = 0; i < data.get_usercount(); i++)
            {
                if (username.Text == data.get_user(i).Name)
                {
                    return data.get_user(i);
                }
            }
            return null;
        }

        private void login_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            
            if (insertion_correct()!=null && b.Text == "Увійти")
            {
                
                b.Text = "Вийти";
                username.Enabled = false;
                MessageBox.Show("Вхід користувача " + insertion_correct().Name +" виконано \n"+data.formatted_rigts(insertion_correct()));
                read.Enabled = true;
                write.Enabled = true;
                todelegate.Enabled = true;
                file_to_do.Enabled = true;
            }
            else if(b.Text == "Вийти")
            {
                b.Text = "Увійти";
                MessageBox.Show("Вихід користувача " + insertion_correct().Name + " виконано");
                username.Enabled = true;
                username.Text = string.Empty;
                read.Enabled = false;
                write.Enabled = false;
                todelegate.Enabled =false;
                file_to_do.Text = string.Empty;
                file_to_do.Enabled = false;
            }
            else
            {
                MessageBox.Show("Користувача не знайдено");
                username.Text = string.Empty;
            }          
        }
        
        public Button create_button_for_read()
        {
            read.Left = 170;
            read.Top = 170;
            read.Text = "зчитати";
            read.Enabled = false;
            read.Click += read_click;
            return read;
        }

        private void read_click(object sender, EventArgs e)
        {
            file f=null;
            for(int i = 0; i < data.get_filecount(); i++)
            {
                if(file_to_do.Text==data.get_file(i).Name)
                {
                    f = data.get_file(i);
                    break;
                }
            }
            if(f==null)
            {
                MessageBox.Show("Нема такого файлу");
                file_to_do.Text = string.Empty;
            }
            else if(f.Get_Read(insertion_correct().Count) == 1)
            {
                MessageBox.Show("Читання з " + f.Name + " дозволено ");
                file_to_do.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Читання з " + f.Name + " не дозволено ");
                file_to_do.Text = string.Empty;
            }
        }

        public Button create_button_for_write()
        {
            write.Left = 250;
            write.Top = 170;
            write.Text = "записати";
            write.Enabled = false;
            write.Click += write_click;
            return write;
        }

        private void write_click(object sender, EventArgs e)
        {
            file f = null;
            for (int i = 0; i < data.get_filecount(); i++)
            {
                if (file_to_do.Text == data.get_file(i).Name)
                {
                    f = data.get_file(i);
                    break;
                }
            }
            if (f == null)
            {
                MessageBox.Show("Нема такого файлу");
                file_to_do.Text = string.Empty;
            }
            else if (f.Get_Write(insertion_correct().Count) == 1)
            {
                MessageBox.Show("Запис в " + f.Name + " дозволено ");
                file_to_do.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Запис в " + f.Name + " не дозволено ");
                file_to_do.Text = string.Empty;
            }
        }

        public Button create_button_for_delegate()
        {
            todelegate.Left = 330;
            todelegate.Top = 170;
            todelegate.Text = "делегувати";
            todelegate.Enabled = false;
            todelegate.Click += todelegate_click;
            return todelegate;
        }
        file f_d = null;
        user u_d = null;
        string operation = "";
        private void todelegate_click(object sender, EventArgs e)
        {

            for (int i = 0; i < data.get_filecount(); i++)
            {
                if (file_to_do.Text == data.get_file(i).Name)
                {
                    f_d = data.get_file(i);
                    break;
                }
            }
            if (f_d == null)
            {
                MessageBox.Show("Нема такого файлу");
                file_to_do.Text = string.Empty;
            }
            else if (f_d.Get_Todelegate(insertion_correct().Count) == 1)
            {
                MessageBox.Show("Делегування " + f_d.Name + " дозволено \n тепер введіть операцію");
                file_to_do.Text = string.Empty;
                insertion.Text = "Операція";
                todelegate.Click -= todelegate_click;
                todelegate.Click += delegation_start_enter_operation;
             }
            else
            {
                MessageBox.Show("Делегування " + f_d.Name + " не дозволено");
                file_to_do.Text = string.Empty;
                f_d = null;
            }
        }

        public void delegation_start_enter_operation(object sender, EventArgs e)
        {
            if(file_to_do.Text!="Читання" && file_to_do.Text != "Запис" && file_to_do.Text != "Делегування")
            {
                file_to_do.Text = string.Empty;
                f_d = null;
                insertion.Text = "Введіть файл";
                todelegate.Click -= delegation_start_enter_operation;
                todelegate.Click += todelegate_click;
                MessageBox.Show("Не існує такої операції!");
            }
            else
            {
                operation = file_to_do.Text;
                file_to_do.Text = string.Empty;
                todelegate.Click -= delegation_start_enter_operation;
                todelegate.Click += delegation_continue_enter_user;
                insertion.Text = "Користувач";
                MessageBox.Show("Введіть користувача для делегування!");
            }
        }

        private void delegation_continue_enter_user(object sender, EventArgs e)
        {
            for (int i = 0; i < data.get_usercount(); i++)
            {
                if (file_to_do.Text == data.get_user(i).Name)
                {
                    u_d = data.get_user(i);
                    break;
                }
            }
            if (u_d == null)
            {
                MessageBox.Show("Немає такого користувача");
                file_to_do.Text = string.Empty;
                todelegate.Click -= delegation_continue_enter_user;
                todelegate.Click += todelegate_click;
                insertion.Text = "Введіть файл";
                u_d = null;
                f_d = null;
                operation = "";
            }
            else
            if (operation == "Читання")
            {
                insertion.Text = "Введіть файл";
                todelegate.Click -= delegation_continue_enter_user;
                todelegate.Click += todelegate_click;
                if(f_d.Get_Read(u_d.Count)==1 || f_d.Get_Read(insertion_correct().Count) == 0)
                {
                    MessageBox.Show("Помилка! Користувач вже має дані права, або недостатньо прав у делегуючого користувача");
                    u_d = null;
                    f_d = null;
                    operation = "";
                    file_to_do.Text = string.Empty;
                }
                else
                {
                    f_d.Set_Read(u_d.Count,1);
                    T.Rows[f_d.Count+1].Cells[u_d.Count+1].Value = data.rigts_insertion(f_d,u_d);
                    
                    file_to_do.Text = string.Empty;
                    MessageBox.Show("Право на читання надано користувачу " + u_d.Name);
                    u_d = null;
                    f_d = null;
                    operation = "";
                }
            }
            else
            if (operation == "Запис")
            {
                insertion.Text = "Введіть файл";
                todelegate.Click -= delegation_continue_enter_user;
                todelegate.Click += todelegate_click;
                if (f_d.Get_Write(u_d.Count) == 1 || f_d.Get_Write(insertion_correct().Count) == 0)
                {
                    MessageBox.Show("Помилка!Користувач вже має дані права, або недостатньо прав у делегуючого користувача");
                    u_d = null;
                    f_d = null;
                    operation = "";
                    file_to_do.Text = string.Empty;
                }
                else
                {
                    f_d.Set_Write(u_d.Count, 1);
                    T.Rows[f_d.Count + 1].Cells[u_d.Count + 1].Value = data.rigts_insertion(f_d, u_d);

                    file_to_do.Text = string.Empty;
                    MessageBox.Show("Право на запис надано користувачу " + u_d.Name);
                    u_d = null;
                    f_d = null;
                    operation = "";
                }
            }
            else
            if (operation == "Делегування")
            {
                insertion.Text = "Введіть файл";
                todelegate.Click -= delegation_continue_enter_user;
                todelegate.Click += todelegate_click;
                if (f_d.Get_Todelegate(u_d.Count) == 1 || f_d.Get_Todelegate(insertion_correct().Count) == 0||(f_d.Get_Read(u_d.Count) == 0)&& (f_d.Get_Write(u_d.Count)==0))
                {
                    MessageBox.Show("Помилка!Користувач вже має дані права, недостатньо прав у делегуючого користувача, або користувачу немає чого делегувати в майбутньому");
                    u_d = null;
                    f_d = null;
                    operation = "";
                    file_to_do.Text = string.Empty;
                }
                else
                {
                    f_d.Set_Todelegate(u_d.Count, 1);
                    T.Rows[f_d.Count + 1].Cells[u_d.Count + 1].Value = data.rigts_insertion(f_d, u_d);

                    file_to_do.Text = string.Empty;
                    MessageBox.Show("Право на делегування надано користувачу " + u_d.Name);
                    u_d = null;
                    f_d = null;
                    operation = "";
                }
            }
        }


        public TextBox create_texbox_for_all()
        {
            file_to_do.Left = 235;
            file_to_do.Top = 210;
            file_to_do.Enabled = false;
            return file_to_do;
        }
    }
}
