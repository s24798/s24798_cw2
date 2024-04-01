using System;
namespace cwiczenia2
{
	public class Kontenerowiec
	{
		private HashSet<Container> transportowaneKontonery;
		private int maxSpeed; //wezly
		private int maxContainerCount;
		private double maxTotalContainerWeight; //tony

		public Kontenerowiec(int maxSpeed, int maxContainerCount, double maxTotalContainerWeight)
		{
			transportowaneKontonery = new HashSet<Container>();
			this.maxSpeed = maxSpeed;
			this.maxContainerCount = maxContainerCount;
			this.maxTotalContainerWeight = maxTotalContainerWeight;
		}

		public void loadContainer(Container container)
		{
			if (transportowaneKontonery.Count == maxContainerCount)
				throw new OverfillException();

			double totalWeight = container.getTotalWeight();
			foreach(Container c in transportowaneKontonery) {
				totalWeight += c.getTotalWeight();
			}
			if (totalWeight / 1000 > maxTotalContainerWeight)
				throw new OverfillException();

			transportowaneKontonery.Add(container);
		}

		public void loadContainer(List<Container> containers)
		{
			if (transportowaneKontonery.Count + containers.Count > maxContainerCount)
				throw new OverfillException();

			double totalWeight = 0;
			foreach (Container c in containers)
				totalWeight += c.getTotalWeight();
			foreach (Container c in transportowaneKontonery)
				totalWeight += c.getTotalWeight();
			if (totalWeight > maxTotalContainerWeight)
                throw new OverfillException();

			foreach(Container c in containers)
			{
				transportowaneKontonery.Add(c);
			}
		}

		public void romoveContainer(string nrSeryjny)
		{
			foreach(Container c in transportowaneKontonery)
			{
				if (nrSeryjny.Equals(c.getNrSeryjny()))
				{
					transportowaneKontonery.Remove(c);
					break;
				}
			}
        }

        public void swapContainers(string nrSeryjny, Container container)
        {
            foreach (Container c in transportowaneKontonery)
            {
                if (nrSeryjny.Equals(c.getNrSeryjny()))
                {
                    transportowaneKontonery.Remove(c);
					this.loadContainer(container);
                    break;
                }
            }
        }

        public void moveToAnotherShip(string nrSeryjny, Kontenerowiec destination)
        {
            foreach (Container c in transportowaneKontonery)
            {
                if (nrSeryjny.Equals(c.getNrSeryjny()))
                {
                    transportowaneKontonery.Remove(c);
                    destination.loadContainer(c);
                    break;
                }
            }
        }

        public override string ToString()
		{
			string output= $"max speed: {maxSpeed}\nmax container count: {maxContainerCount}\nmax total weight: {maxTotalContainerWeight}\ncontainers: ";
			foreach(Container c in transportowaneKontonery)
			{
				output += "\n" + c.getNrSeryjny();
			}
			return output;
		}
    }
}

