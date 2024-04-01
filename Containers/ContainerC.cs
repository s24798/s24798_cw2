using System;
namespace cwiczenia2.Contaners
{
    public class ContainerC : Container
    {
        private string rodzajProduktu;
        private decimal temperatura;

        public ContainerC(int wysokosc, int glebokosc, int masaWlasna, int maxLadownosc,string rodzajProduktu, decimal temperatura)
            : base(wysokosc, glebokosc, masaWlasna, maxLadownosc, "C")
        {
            this.rodzajProduktu = rodzajProduktu;
            this.temperatura = temperatura;
        }


    }
}

