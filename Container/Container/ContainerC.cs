namespace Container;

public class ContainerC : Container
{
    private static readonly Dictionary<string, double> ProductRequirements = new Dictionary<string, double>
    {
        {"banana", 13.3},
        {"chocolate", 18},
        {"fish", 2},
        {"meat", -15},
        {"ice cream", -18},
        {"frozen pizza", -30},
        {"cheese", 7.2},
        {"sausages", 5},
        {"butter", 20.5},
        {"eggs", 19}
    };

    public string ProductType { get; private set; }
    public double Temperature { get; private set; }

    public ContainerC(double height, double ownWeight, double depth, double maxCapacity, string productType,
        double temperature)
        : base(height, ownWeight, depth, maxCapacity, "C")
    {
        ProductType = productType;
        Temperature = temperature;
        
        if (!ProductRequirements.ContainsKey(productType.ToLower()))
        {
            throw new ArgumentException($"Unknown product type: {productType}");
        }

        double requiredTemp = ProductRequirements[productType.ToLower()];
        if (temperature < requiredTemp)
        {
            throw new ArgumentException($"Temperature {temperature}°C is too low for {productType}. Minimum: {requiredTemp}°C");
        }

    }
    
    public override void LoadCargo(double mass)
    {
        base.LoadCargo(mass);
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"- Product type: {ProductType}");
        Console.WriteLine($"- Temperature: {Temperature}°C");
    }
}
    