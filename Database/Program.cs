using DatabaseEF;
using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
DbProviderFactories.RegisterFactory("System.Data.SQLite", System.Data.SQLite.SQLiteFactory.Instance);


using(var db = new MTContext())
{
    db.Database.CreateIfNotExists();
    db.Persons.Add(new Person() { Id = Guid.NewGuid(), Name = "Karl" });
    //db.Database.SqlQuery<Person>("CREATE TABLE Person (Id int, Name TEXT)");
    db.Database.ExecuteSqlCommand("UPDATE PERSON SET Name = 'Test' WHERE Name = 'Karl'");
    db.Database.ExecuteSqlCommand("CREATE TABLE BOOK (Id int, Name text)");
    db.SaveChanges();
}