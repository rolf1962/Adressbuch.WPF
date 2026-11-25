using Adressbuch.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adressbuch.WPF.DataAccess
{
    public class GenericRepositoryModelBase<T>(DbContext context) : GenericRepository<T>(context) where T : ModelBase
    {
        public override void Insert(T entity)
        {
            entity.Created = DateTime.Now;
            entity.CreatedBy = "Rolf Jansen";

            base.Insert(entity);
        }

        public override void Update(T entity)
        {
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = "Rolf Jansen";

            base.Update(entity);
        }
    }
}
