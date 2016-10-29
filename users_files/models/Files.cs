using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_files
{
    class file
    {
        private string name;
        private int count;
        private int[] read;
        private int[] write;
        private int[] todelegate;

        public int Count {get{return count;}}

        public int Get_Read(int r)
        {
            return read[r];
        }
        public void Set_Read(int r,int val)
        {
            read[r] = val;
        }
        public int Get_Write(int w)
        {
            return write[w];
        }
        public void Set_Write(int w,int val)
        {
            write[w]=val;
        }

        public int Get_Todelegate(int td)
        {
            return todelegate[td];
        }

        public void Set_Todelegate(int td, int val)
        {
            todelegate[td]=val;
        }

        public string Name { get { return name; } }

        public file(string n, int counter, int c)
        {
            count = c;
            Random k = new Random((int)DateTime.Now.Ticks);

            read = new int[counter];
            read[0] = 1;
            for (int i = 1; i < counter; i++)
            {
                read[i] = k.Next(0,2);
            }

            write = new int[counter];
            write[0] = 1;
            for (int i = 1; i < counter; i++)
            {
                write[i] = k.Next(0, 2);
            }

            todelegate = new int[counter];
            todelegate[0] = 1;
            for (int i = 1; i < counter; i++)
            {
                if(write[i]==0&&read[i]==0)
                {
                    todelegate[i] = 0;
                }
                else
                todelegate[i] = k.Next(0, 2);
            }

            name = n;
        }
    }
}
