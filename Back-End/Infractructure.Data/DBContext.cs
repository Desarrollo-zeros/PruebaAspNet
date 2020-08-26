using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Domain.Entities;
using Infraestructure.Data.Base;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infraestructure.Data
{
    public class DBContext : DbContextBase
    {

        public DbSet<Client> Clients { set; get; }

        public DbSet<Contact> Contacts { set; get; }

        
       


        public DBContext() : base("DBContext") {
            if (!Database.Exists("DBContext"))
            {
                Database.SetInitializer<DBContext>(new CreateInitializer());
            }

            

        }

        protected DBContext(DbConnection connection) : base(connection) {

            if (!Database.Exists("DBContext"))
            {
                Database.SetInitializer<DBContext>(new CreateInitializer());
            }


            
        }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            if (!Database.Exists("DBContext"))
            {
                Database.SetInitializer<DBContext>(new CreateInitializer());
            }

        
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            
        }

        public void Seed(DBContext context)
        {
            context.SaveChanges();
        }
    }

    public class CreateInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            
            context.Seed(context);
            base.Seed(context);
        }
    }


    public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {

            
            context.Seed(context);
            base.Seed(context);
        }
    }

    public class AlwaysCreateInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
          
            context.Seed(context);
            base.Seed(context);
        }
    }

}
