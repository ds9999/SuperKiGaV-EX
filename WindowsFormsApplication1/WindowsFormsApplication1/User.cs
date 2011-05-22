using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class User
    {
        public virtual String Username { get; set; }
        public virtual int PasswordHash { get; set; }
        public virtual int Group { get; set; }
        public virtual long ID { get; set; }

        public override string ToString()
        {
            return Username + " " + Group.ToString() + " ID:" + ID.ToString(); 
        }
    }
}
