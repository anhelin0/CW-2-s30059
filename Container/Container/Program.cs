namespace Container;

class Program
{
    static void Main(string[] args)
    {
        var refrigeratedContainer = new ContainerC(250, 2000, 200, 12000, "banana", 14);
        var liquidContainerSafe = new ContainerL(220, 1800, 200, 10000, false);
        var liquidContainerHazard = new ContainerL(220, 2000, 200, 8000, true);
        var gasContainer = new ContainerG(200, 1500, 200, 7000, 2.5);

        refrigeratedContainer.LoadCargo(8000);
        liquidContainerSafe.LoadCargo(9000);
        liquidContainerHazard.LoadCargo(4000);
        gasContainer.LoadCargo(6000);

        var ship1 = new Ship("Tytanic", 20, 10, 50);
        var ship2 = new Ship("Olympic", 18, 8, 40);

        ship1.LoadContainer(refrigeratedContainer);
        ship1.LoadContainer(liquidContainerSafe);

        ship1.LoadContainers(new List<Container> { liquidContainerHazard, gasContainer });

        ship1.PrintInfo();

        ship1.RemoveContainer(liquidContainerSafe); 
        ship1.PrintInfo();

        var newRefrigeratedContainer = new ContainerC(250, 2100, 200, 12500, "fish", 3);
        ship1.ReplaceContainer(refrigeratedContainer.SerialNumber, newRefrigeratedContainer);
        ship1.PrintInfo();

        ship1.TransferContainer(newRefrigeratedContainer.SerialNumber, ship2);
        ship1.PrintInfo();
        ship2.PrintInfo();

        gasContainer.EmptyCargo();
        Console.WriteLine($"\nGas container after emptying: {gasContainer.CargoWeight}kg (should be 5% of original)");

        newRefrigeratedContainer.PrintInfo();
    }
}