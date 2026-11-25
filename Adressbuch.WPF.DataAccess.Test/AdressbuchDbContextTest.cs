using Adressbuch.WPF.Model;
using Microsoft.EntityFrameworkCore;

namespace Adressbuch.WPF.DataAccess.Test
{
    public class AdressbuchDbContextTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Erzeugt einen <see cref="DbContext"/> für die Adressbuch-Datenbank
        /// Wenn Sie nicht existiert, soll sie erzeugt werden.
        /// </summary>
        [Test]
        public void TestDatabaseExistsOrCreateted()
        {
            // Wenn die Datenbank existiert, wird sie geöffnet, wenn sie nicht
            // Existiert, wird sie erzeugt. Das erledigt das EntityFramework
            AdressbuchDbContext dbContext = new AdressbuchDbContext();

            // Überprüfen. dass es den DbContext gibt
            Assert.That(dbContext, Is.Not.Null);

        }

        [Test]
        public void TestPersonRepository()
        {
            AdressbuchDbContext dbContext = new AdressbuchDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);

            List<Person> personen = unitOfWork.PersonRepository.GetAll(
                predicate: p => p.Nachname == "Jansen",
                person => person.Adressen, person => person.Erreichbarkeiten);

            Assert.That(personen, Is.Not.Null);

            // Neue Person einfügen
            Person person = new Person() { Nachname = "Testmann", Vornamen = "Manfred", Geburtsdatum = new DateTime(2000, 2, 28) };

            unitOfWork.PersonRepository.Insert(person);
            unitOfWork.Save();
            
            person.Bemerkungen = "Da gibt es viel zu erzählen - ein anderes Mal.";
            unitOfWork.PersonRepository.Update(person);
            unitOfWork.Save();

            unitOfWork.PersonRepository.Delete(person);
            unitOfWork.Save();
        }
    }
}
