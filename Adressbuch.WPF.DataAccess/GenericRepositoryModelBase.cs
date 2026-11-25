using Adressbuch.WPF.Model;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Adressbuch.WPF.DataAccess
{
    public class GenericRepositoryModelBase<T> : GenericRepository<T> where T : ModelBase
    {
        private string _userName;
        internal GenericRepositoryModelBase(DbContext context, string userName) : base(context)
        {
            _userName = userName;
        }

        public override void Insert(T entity)
        {
            entity.Created = DateTime.Now;
            entity.CreatedBy = _userName;

            base.Insert(entity);
        }

        public override void Update(T entity)
        {
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = _userName;

            base.Update(entity);
        }
    }
}
