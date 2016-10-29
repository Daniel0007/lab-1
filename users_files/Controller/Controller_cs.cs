using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_files.Controller
{
    class Controller_data
    {

        private user[] user_list;
        private file[] file_list;
        private int usercount;
        private int filecount;
        public Controller_data (int u, int f)
        {
            usercount = u;
            filecount = f;
            user_list = new user[u];
            user_list[0] = new user("Адміністратор", 0);
            for(int i = 1; i < u; i++)
            {
                user_list[i] = new user("Користувач " + i.ToString(), i); 
            }

            file_list = new file[f];

            for(int i = 0; i < f; i++)
            {
                file_list[i] = new file("файл " + (i+1).ToString(), u, i);
            }
            
        }

        public int get_usercount()
        {
            return usercount;
        }
        public int get_filecount()
        {
            return filecount;
        }
        public user get_user(int k)
        {
            return user_list[k];
        }
        public file get_file(int k)
        {
            return file_list[k];
        }

        public string rigts_insertion(file f, user u)
        {
                return file_list[f.Count].Get_Read(u.Count).ToString() 
                + file_list[f.Count].Get_Write(u.Count).ToString() 
                + file_list[f.Count].Get_Todelegate(u.Count).ToString();
        }
        
        private string convert_rigts(user u,file f)
        {
            string temp1 = f.Get_Read(u.Count).ToString(),
                   temp2 = f.Get_Write(u.Count).ToString(),
                   temp3 = f.Get_Todelegate(u.Count).ToString();
            if (temp1 == "0" && temp2 == "0" && temp3 == "0")
            { return "нема прав"; }
            else if(temp1 == "1" && temp2 == "1" && temp3 == "1")
            {
                return "Повні права";
            }
            else
            {
                if (temp1 == "0")
                { temp1 = ""; }
                else
                { temp1 = "Читання "; }
                if (temp2 == "0")
                { temp2 = ""; }
                else
                { temp2 = "Запис "; }

                if (temp3 == "0")
                { temp3 = ""; }
                else
                { temp3 = "Делегування "; }

                return temp1 + temp2 + temp3;
            }
        }
        

        public string formatted_rigts(user u)
        {
            string s = "";
            foreach (file f in file_list)
            {
                s+= f.Name + "        " + convert_rigts(u, f)+ "\n";
            }
            return s;
        }
    }
}
