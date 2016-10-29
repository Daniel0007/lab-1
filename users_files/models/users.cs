using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_files
{
    class user
    {
        private string name;
        private int count;
        public string Name { get { return name; } }
        public int Count { get { return count; } }
        public user(string n, int c)
        {
            name = n;
            count = c;
        }
    }
}
