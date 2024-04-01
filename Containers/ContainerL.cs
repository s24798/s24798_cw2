using System;
namespace cwiczenia2.Contaners
{
	public class ContainerL : Container, IHazardNotifier
	{
		private bool isDangerous;

        public ContainerL(int wysokosc, int glebokosc, int masaWlasna, int maxLadownosc, bool isDangerous)
			: base(wysokosc, glebokosc, masaWlasna, maxLadownosc, "L")
		{
			this.isDangerous = isDangerous;
		}

        public void SendHazardNotification(string nrSeryjny)
        {
            Console.WriteLine($"Wystąpiła niebezbieczna operacja dla kontenera: {nrSeryjny}");
        }

        override public void zaladuj(double masaLadunku)
		{
            if ((isDangerous && this.masaLadunku + masaLadunku > maxLadownosc * 0.5) ||
                this.masaLadunku + masaLadunku > maxLadownosc * 0.9)
			{
				this.SendHazardNotification(this.nrSeryjny);
                throw new OverfillException();
            }
			base.zaladuj(masaLadunku);
		}
	}
}

