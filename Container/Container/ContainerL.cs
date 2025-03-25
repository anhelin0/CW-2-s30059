namespace Container;

public class ContainerL : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public ContainerL(double height, double ownWeight, double depth, double maxCapacity, bool isHazardous)
        : base(height, ownWeight, depth, maxCapacity, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double cargoWeight)
        {
            double maxAllowedLoad = IsHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

            if (cargoWeight + CargoWeight > maxAllowedLoad)
            {
                NotifyHazard(SerialNumber);
                throw new OverfillException($"{SerialNumber}: Cargo exceeds maximum payload");
            }

            CargoWeight += cargoWeight;
            Console.WriteLine($"Added cargo to {SerialNumber}.");
        }

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Container {containerNumber} exceeded limit.");
    }

}