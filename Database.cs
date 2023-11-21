using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;
using System.ComponentModel.DataAnnotations;
using DatabaseInterface;

namespace DatabaseEF
{
    class MTContext : DbContext
    {
        public MTContext() : base("name=MTContext")
        {
            Database.SetInitializer<MTContext>(new MTContextInitializer());
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Metadata> Metadatas { get; set; }
    }

    class MTContextInitializer : CreateDatabaseIfNotExists<MTContext>
    {
        protected override void Seed(MTContext context)
        {
            InitializeTables(context);
            base.Seed(context);
            return;
            context.Database.CreateIfNotExists();
            Console.WriteLine("SEED CREATING DATABASE");
            Metadata metadata = new Metadata() { MetadataId = Guid.NewGuid(), Version = "2.8.0" };
            context.Metadatas.Add(metadata);
            context.Persons.Add(new Person() { Id = Guid.NewGuid(), Name = "Olav" });
            base.Seed(context);
        }

        private void InitializeTables(MTContext context)
        {
            context.Database.SqlQuery<Person>("CREATE TABLE Person (Id int, Name TEXT)");
            Console.WriteLine("TEST");
        }

    }
}
