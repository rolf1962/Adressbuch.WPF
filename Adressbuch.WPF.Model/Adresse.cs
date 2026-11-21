using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Adressbuch.WPF.Model
{
    public class Adresse : ModelBase
    {
        private string? _postleitzahl;
        private string? _ort;
        private string? _strasse;
        private string? _hausnummer;

        [Column("Postleitzahl")]
        public string? Postleitzahl { get => _postleitzahl; set { if (_postleitzahl != value) { _postleitzahl = value; NotifyPropertyChanged(); } } }

        [Column("Ort")]
        public string? Ort { get => _ort; set { if (_ort != value) { _ort = value; NotifyPropertyChanged(); } } }

        [Column("Strasse")]
        public string? Strasse { get => _strasse; set { if (_strasse != value) { _strasse = value; NotifyPropertyChanged(); } } }

        [Column("Hausnummer")]
        public string? Hausnummer { get => _hausnummer; set { if (_hausnummer != value) { _hausnummer = value; NotifyPropertyChanged(); } } }

        public ICollection<Person> Personen { get; set; } = new HashSet<Person>();
    }
}
