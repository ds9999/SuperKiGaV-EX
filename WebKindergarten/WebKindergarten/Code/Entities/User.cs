using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebKindergarten.Code.Entities
{
    public class User
    {
        public virtual int Id { get; private set; }
        public virtual string UserName { get; set; }
        public virtual string Vorname { get; set; }
        public virtual string Nachname { get; set; }
        public virtual int PasswordHash { get; set; }
        public virtual IList<Kind> Children { get; set; }

        public User()
        {
            Children = new List<Kind>();
        }

        public virtual void AddNewChild(Kind k){
            k.ChildUser = this;
            Children.Add(k);
        }
    }
}