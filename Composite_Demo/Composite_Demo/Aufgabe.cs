namespace Composite_Demo
{
    public abstract class Aufgabe
    {
        public abstract string Beschreibung { get; set; }
        public abstract bool IstErledigt { get; set; }
        public abstract void AufgabeErledigen();
    }

}
