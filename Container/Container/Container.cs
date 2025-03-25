namespace Container;

public abstract class Container
{
        private static int counter = 1;
        public double CargoWeight { get; protected set; }
        public double Height { get; }
        public double OwnWeight { get; }
        public double Depth { get; }
        public string SerialNumber { get; private set; }
        public double MaxCapacity { get; }

        public Container(double height, double ownWeight, double depth, double maxCapacity, string type)
        {
            SerialNumber = $"KON-{type}-{counter++}";
            Height = height;
            OwnWeight = ownWeight;
            Depth = depth;
            MaxCapacity = maxCapacity;
        }
        
        public virtual void LoadCargo(double cargoWeight)
        {
            if (CargoWeight + cargoWeight > MaxCapacity)
            {
                throw new OverfillException("Cargo exceeds maximum payload.");
            }
            CargoWeight += cargoWeight;
        }

        public virtual void EmptyCargo()
        {
            CargoWeight = 0;
            Console.WriteLine($"Cargo for {SerialNumber} emptied.");
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Container {SerialNumber}:");
            Console.WriteLine($"- Type: {GetType().Name}");
            Console.WriteLine($"- Height: {Height}cm");
            Console.WriteLine($"- Depth: {Depth}cm");
            Console.WriteLine($"- Own weight: {OwnWeight}kg");
            Console.WriteLine($"- Max capacity: {MaxCapacity}kg");
            Console.WriteLine($"- Total weight: {CargoWeight}kg");
        }
        
        
        public override string ToString()
        {
            return $"{SerialNumber}";
        }
}