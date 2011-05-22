using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebKindergarten.Code.Entities
{
    public class Kind
    {
        public virtual int Id { get; private set; }
        public virtual string Vorname { get; set; }
        public virtual string Nachname { get; set; }
        public virtual DateTime Geburtstag { get; set; }
        public virtual User ChildUser { get; set; }

        public virtual int Alter
        {
            get
            {
                TimeSpan span = DateTime.Now.Subtract(Geburtstag);
                return span.Days/365;
            }
        }

        public override string ToString()
        {
            return Vorname + " " + Nachname + " (" + Alter.ToString() + ")";
        }
    }
}