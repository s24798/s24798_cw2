using cwiczenia2;
using cwiczenia2.Contaners;

Container containerLDanger = new ContainerL(1, 1, 1, 10, true);
Container containerL = new ContainerL(1, 1, 1, 10, false);
Container containerG = new ContainerG(1, 1, 1, 10);

containerL.zaladuj(7);

containerLDanger.zaladuj(5);

containerG.zaladuj(10);

Kontenerowiec kontenerowiec = new Kontenerowiec(10, 3, 33);
kontenerowiec.loadContainer(containerLDanger);
var conList = new List<Container> { containerG, containerL};
kontenerowiec.loadContainer(conList);

Console.WriteLine(kontenerowiec);
Console.WriteLine(containerG);