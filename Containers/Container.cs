using System;
namespace cwiczenia2
{
	public class Container
	{
		private static int nrSeryjnyGenerator = 0;
		protected double masaLadunku; //kg
        protected double wysokosc; //cm
        protected double masaWlasna; //kg
        protected double glebokosc; //cm
        protected double maxLadownosc; //kg
		protected string nrSeryjny;


		public virtual void zaladuj(double masaLadunku)
		{
			if (this.masaLadunku + masaLadunku > maxLadownosc)
				throw new OverfillException();
			this.masaLadunku += masaLadunku;
		}
		public virtual void rozładuj(double masaRozladunku)
		{
			if (this.masaLadunku - masaRozladunku < 0)
				throw new Exception();
			this.masaLadunku -= masaRozladunku;
		}

		protected Container(int wysokosc, int glebokosc, int masaWlasna, int maxLadownosc, string type)
		{
			this.masaLadunku = 0;
			this.wysokosc = wysokosc;
			this.glebokosc = glebokosc;
			this.masaWlasna = masaWlasna;
            this.maxLadownosc = maxLadownosc;

			this.nrSeryjny = $"KON-{type}-{nrSeryjnyGenerator++}";
		}

		public double getTotalWeight()
		{
			return masaWlasna + masaLadunku;
		}
		public string getNrSeryjny()
		{
			return nrSeryjny;
		}
        public override string ToString()
		{
			return $"{nrSeryjny}\nmasa ladunku: {masaLadunku}\nmasa wlasna: {masaWlasna}" +
				$"\nwysokosc: {wysokosc}\nglebokosc: {glebokosc}\nmax ladownosc: {maxLadownosc}";
		}
    }
}

