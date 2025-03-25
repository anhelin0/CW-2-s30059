namespace Container;

public class ContainerG : Container, IHazardNotifier
{
    private double Pressure{ get; set; }

    public ContainerG(double height, double ownWeight, double depth, double maxCapacity, double pressure)
        : base(height, ownWeight, depth, maxCapacity, "G")
    {
        Pressure = pressure;
    }


    public override void EmptyCargo()
    {
        CargoWeight *= 0.5;
        Console.WriteLine($"Cargo for {SerialNumber} emptied. {CargoWeight}kg left inside.");
    }
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Pressure: {Pressure}Pa\n");
    }


    public override void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaxCapacity)
        {
            NotifyHazard(SerialNumber);
            throw new OverfillException("Cargo exceeds maximum payload.");
        } 
        base.LoadCargo(cargoWeight);
    }


    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Container {containerNumber} exceeded limit.");
    }
}