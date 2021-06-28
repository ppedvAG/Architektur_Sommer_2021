using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Demo
{
    // Basisfeatures definieren
    public interface IComponent
    {
        string Beschreibung { get; }
        decimal Preis { get; }
    }

    // Root-Element, bestehend aus Grundkomponenten
    public class Pizza : IComponent
    {
        public string Beschreibung => "Pizza ";
        public decimal Preis => 5m;
    }

    public abstract class Dekorator : IComponent
    {
        public Dekorator(IComponent parent)
        {
            this.parent = parent;
        }
        protected readonly IComponent parent;

        public abstract string Beschreibung { get; }

        public abstract decimal Preis { get; }
    }
    // Weitere Elemente, die die Pizza "dekorieren"

    public class Salami : Dekorator
    {
        public Salami(IComponent parent) : base(parent){}

        public override string Beschreibung => parent.Beschreibung + "Salami ";

        public override decimal Preis => parent.Preis + 2m;
    }
    public class Käse : Dekorator
    {
        public Käse(IComponent parent) : base(parent) { }

        public override string Beschreibung => parent.Beschreibung + "Käse ";

        public override decimal Preis => parent.Preis + 0.5m;
    }
    public class Schinken : Dekorator
    {
        public Schinken(IComponent parent) : base(parent) { }

        public override string Beschreibung => parent.Beschreibung + "Schinken ";

        public override decimal Preis => parent.Preis + 0.77m;
    }

    public class Trüffel : Dekorator
    {
        public Trüffel(IComponent parent) : base(parent) { }

        public override string Beschreibung => parent.Beschreibung + "Trüffel ";

        public override decimal Preis => parent.Preis + 24.99m;
    }

    public class Blattgold : Dekorator
    {
        public Blattgold(IComponent parent) : base(parent) { }

        public override string Beschreibung => parent.Beschreibung + "Blattgold ";

        public override decimal Preis => parent.Preis + 99.99m;
    }

}
