using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Demo
{
    public enum Oberflächenart { Unbehandelt, Gewachst,Lackiert};
    public class Schrank
    {
        private Schrank()
        {

        }

        public int AnzahlTüren { get; set; }
        public int AnzahlBöden { get; set; }
        public Oberflächenart Oberfläche { get; set; }
        public string Farbe { get; set; }
        public bool Kleiderstange { get; set; }
        public bool Metallschiene { get; set; }

        public static SchrankBauer BaueSchrank()
        {
            return new SchrankBauer();
        }

        public class SchrankBauer
        {
            public SchrankBauer()
            {
                zuBauenderSchrank = new Schrank();
            }

            private Schrank zuBauenderSchrank;

            public SchrankBauer MitBöden(int AnzahlBöden)
            {
                if (AnzahlBöden > 0 && AnzahlBöden <= 6)
                    zuBauenderSchrank.AnzahlBöden = AnzahlBöden;
                else
                    throw new ArgumentException("Die Anzahl der Böden ist ungültig");

                return this; // Aktuelle SchrankBauer-Instanz
            }

            public SchrankBauer MitTüren(int AnzahlTüren)
            {
                if (AnzahlTüren >= 2 && AnzahlTüren <= 7)
                    zuBauenderSchrank.AnzahlTüren = AnzahlTüren;
                else
                    throw new ArgumentException("Die Anzahl der Türen ist ungültig");

                return this;
            }
            public SchrankBauer MitMetallschiene(bool mitSchiene)
            {
                zuBauenderSchrank.Metallschiene = mitSchiene;
                return this;
            }
            public SchrankBauer MitKleiderstange(bool mitStange)
            {
                zuBauenderSchrank.Kleiderstange = mitStange;
                return this;
            }
            public SchrankBauer MitOberfläche(Oberflächenart Oberfläche)
            {
                zuBauenderSchrank.Oberfläche = Oberfläche;
                return this;
            }
            public SchrankBauer InFarbe(string Farbe)
            {
                if (zuBauenderSchrank.Oberfläche == Oberflächenart.Lackiert)
                    zuBauenderSchrank.Farbe = Farbe;
                else
                    throw new ArgumentException("Nur ein lackierter Schrank darf eine Farbe haben");
                return this;
            }

            public Schrank Konstruiere()
            {
                // ToDo: Abschließende Komplett-Validierung
                return zuBauenderSchrank;
            }
        }
    }
}
