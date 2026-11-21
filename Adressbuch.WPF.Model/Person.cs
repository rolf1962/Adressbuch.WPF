using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Adressbuch.WPF.Model
{
    public class Person : ModelBase
    {
        private string? _nachname;
        private string? _vornamen;
        private DateTime? _geburtsdatum;
        private string? _bemerkungen;

        [Column("Nachname")]
        public string? Nachname { get => _nachname; set { if (_nachname != value) { _nachname = value; NotifyPropertyChanged(); } } }

        [Column("Vornamen")]
        public string? Vornamen { get => _vornamen; set { if (_vornamen != value) { _vornamen = value; NotifyPropertyChanged(); } } }

        [Column("Geburtsdatum")]
        public DateTime? Geburtsdatum { get => _geburtsdatum; set { if (_geburtsdatum != value) { _geburtsdatum = value; NotifyPropertyChanged(); } } }

        [Column("Bemerkungen")]
        public string? Bemerkungen { get => _bemerkungen; set { if (_bemerkungen != value) { _bemerkungen = value; NotifyPropertyChanged(); } } }

        public ICollection<Adresse> Adressen { get; set; } = new HashSet<Adresse>();
        public ICollection<Erreichbarkeit> Erreichbarkeiten { get; set; } = new HashSet<Erreichbarkeit>();
    }
}
