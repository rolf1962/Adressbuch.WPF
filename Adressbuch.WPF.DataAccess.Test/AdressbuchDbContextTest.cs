using System.Xml.Serialization;
using Adressbuch.WPF.DataAccess;
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

            UnitOfWork unitOfWork = new UnitOfWork(dbContext);
            List<Person> personen = unitOfWork.PersonRepository.GetAll(
                null, //predicate: o => o.Nachname == "Max Mustermann",
                person => person.Adressen, person => person.Erreichbarkeiten);

            Assert.That(personen,Is.Not.Null);
        }

    }
}
