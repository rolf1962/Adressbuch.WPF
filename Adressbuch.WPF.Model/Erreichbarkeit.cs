namespace Adressbuch.WPF.Model
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Erreichbarkeit : ModelBase
    {
        public enum Anschlussart { Unbekannt = 0, TelefonFestnetz = 1, TelefonMobil = 2, Web = 3, Email = 4 }
        private Anschlussart _anschlussArt;
        private string? _vorwahl;
        private string? _anschluss = string.Empty;

        [Column("Anschlussart")]
        public Anschlussart AnschlussArt { get => _anschlussArt; set { if (_anschlussArt != value) { _anschlussArt = value; NotifyPropertyChanged(); } } }

        [Column("Vorwahl")]
        public string? Vorwahl { get => _vorwahl; set { if (_vorwahl != value) { _vorwahl = value; NotifyPropertyChanged(); } } }

        [Column("Anschluss")]
        public string? Anschluss { get => _anschluss; set { if (_anschluss != value) { _anschluss = value; NotifyPropertyChanged(); } } }

        public ICollection<Person> Personen { get; set; } = new HashSet<Person>();
    }
}
