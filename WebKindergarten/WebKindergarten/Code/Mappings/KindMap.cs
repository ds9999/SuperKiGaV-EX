using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using WebKindergarten.Code.Entities;

namespace WebKindergarten.Code.Mappings
{
    public class KindMap : ClassMap<Kind>
    {
        public KindMap()
        {
            Id(x => x.Id);
            Map(x => x.Vorname);
            Map(x => x.Nachname);
            Map(x => x.Geburtstag);
            References(x => x.ChildUser);
        }
    }
}