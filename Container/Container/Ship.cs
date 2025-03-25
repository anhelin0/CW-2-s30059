namespace Container;

public class Ship
{
    public string Name { get; set; }
    public List<Container> Containers { get;  set; } = new List<Container>();
    public double MaxSpeed  { get;  set; }
    public int MaxContainers { get;  set; }
    public double MaxCapacity { get;  set; }


    public Ship(string name, double maxSpeed, int maxContainers, double maxCapacity)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxCapacity = maxCapacity;
        Containers = new List<Container>();
    }


    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
        {
            throw new Exception("Ship at full capacity.");
        }

        if (Containers.Sum(c => c.CargoWeight + c.OwnWeight) + container.CargoWeight + container.OwnWeight >
            MaxCapacity * 1000)
        {
            throw new Exception("Maksymalna waga została przekroczona.");
        }

        Containers.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} loaded onto ship {Name}.");

    }
    
    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }
    
    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
        Console.WriteLine($"Container {container.SerialNumber} removed from ship {Name}.");

    }
    
    public void TransferContainer(string serialNumber, Ship targetShip)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new Exception("Kontener nie został znaleziony na statku.");
        }
        targetShip.LoadContainer(container);
        Containers.Remove(container);
        Console.WriteLine($"Container {serialNumber} transferred from {Name} to {targetShip.Name}.");
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1)
        {
            throw new Exception($"Container {serialNumber} not found on the ship");
        }
        Containers[index] = newContainer;
        Console.WriteLine($"Container {serialNumber} replaced with new container {newContainer.SerialNumber} on ship {Name}.");
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"\nShip: {Name}\n" +
                          $"Max speed: {MaxSpeed}knots\n" +
                          $"Max containers count: {MaxContainers}\n" +
                          $"Max containers weight: {MaxCapacity}tons\n" +
                          $"Containers: {string.Join(", ", Containers)}\n");
    }
}