using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Data;
using System.Data.Entity;
using Domain.Entities;

namespace Infraestructure.Data.Test
{
    public class DBContextTest : DBContext
    {
        public DBContextTest() : base()
        {
            Database.SetInitializer<DBContextTest>(new CreateInitializer());
        }

        protected DBContextTest(System.Data.Common.DbConnection connection) : base(connection)
        {
            Log = Console.WriteLine;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check          
            Database.SetInitializer<DBContextTest>(new CreateInitializer());


            base.OnModelCreating(modelBuilder);
        }
    }

    public class CreateInitializer : CreateDatabaseIfNotExists<DBContextTest>
    {
        protected override void Seed(DBContextTest context)
        {
            context.Seed(context);
            base.Seed(context);
        }
    }


    public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<DBContextTest>
    {
        protected override void Seed(DBContextTest context)
        {
            context.Seed(context);
            base.Seed(context);
        }
    }

    public class AlwaysCreateInitializer : DropCreateDatabaseAlways<DBContextTest>
    {
        protected override void Seed(DBContextTest context)
        {
            context.Seed(context);
            base.Seed(context);
        }
    }

}
