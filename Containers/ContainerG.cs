using System;
namespace cwiczenia2.Contaners
{
    public class ContainerG : Container, IHazardNotifier
    {
        private double pressure;
        public ContainerG(int wysokosc, int glebokosc, int masaWlasna, int maxLadownosc)
            : base(wysokosc, glebokosc, masaWlasna, maxLadownosc, "G")
        {
            pressure = 1;
        }

        public void SendHazardNotification(string nrSeryjny)
        {
            Console.WriteLine($"Wystąpiła niebezbieczna operacja dla kontenera: {nrSeryjny}");
        }

        public override void rozładuj(double masaRozladunku)
        {
            if (this.masaLadunku - masaRozladunku < this.masaLadunku * 0.05)
            {
                this.SendHazardNotification(this.nrSeryjny);
                throw new Exception();
            }
            base.rozładuj(masaRozladunku);
        }
    }
}

