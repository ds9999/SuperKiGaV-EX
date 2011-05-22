using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebKindergarten.Code.Entities;
using FluentNHibernate.Mapping;

namespace WebKindergarten.Code.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.Vorname);
            Map(x => x.Nachname);
            Map(x => x.PasswordHash);

            HasMany(x => x.Children)
                .Cascade.All()
                .Inverse();
        }
    }
}