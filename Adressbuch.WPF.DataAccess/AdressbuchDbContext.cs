using Adressbuch.WPF.Model;
using Microsoft.EntityFrameworkCore;

namespace Adressbuch.WPF.DataAccess
{
    public class AdressbuchDbContext : DbContext
    {

#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
        public AdressbuchDbContext()
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

        {
            Database.EnsureCreated();
        }

        public DbSet<Person> Personen {  get; set; }
        public DbSet<Adresse> Adressen { get; set; }
        public DbSet<Erreichbarkeit> Erreichbarkeiten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                                                          
            optionsBuilder.UseMySQL("server=linux;database=adressbuch;user=adressbuch;password=Syquest1!");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                             
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Adresse>().HasKey(adresse => adresse.ID);
            //modelBuilder.Entity<Person>().HasKey(person => person.ID);
            //modelBuilder.Entity<Telefon>().HasKey(telefon => telefon.ID);
        }
    }
}