using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// represents a Quarter, a floating-point number categorized into four equal ranges.
/// </summary>

public class Quarter
{

    /// <summary>
    /// initializes a new instance of the <see cref="Quarter"/> class.
    /// </summary>
    /// <param name="value">a floating-point value in the range [0.0, 1.0).</param>
    /// <exception cref="ArgumentOutOfRangeException">thrown if the value is outside the allowed range.</exception>

    public double Value { get; }
    public Quarter(double value)
    {
        if (value < 0.0 || value >= 1.0)
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be in range [0.0, 1.0)");
        Value = value;
    }

    private int GetQuarter() => (int)(Value * 4);

    public static bool operator ==(Quarter a, Quarter b) => a.GetQuarter() == b.GetQuarter();
    public static bool operator !=(Quarter a, Quarter b) => !(a == b);
    public static bool operator <(Quarter a, Quarter b) => a.Value < b.Value;
    public static bool operator >(Quarter a, Quarter b) => a.Value > b.Value;
    public static bool operator <=(Quarter a, Quarter b) => a.Value <= b.Value;
    public static bool operator >=(Quarter a, Quarter b) => a.Value >= b.Value;

    public override bool Equals(object obj) => obj is Quarter q && this == q;
    public override int GetHashCode() => GetQuarter().GetHashCode();
}

public class Program{
    public static void Main()
    {
        List<Quarter> quarters = new List<Quarter>();

        while (true)
            {
                Console.WriteLine("Select an option:\n1. Add a Quarter\n2. Quit");
                string input = Console.ReadLine();
                
                if (input == "2") break;
                if (input != "1")
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }
                
                try
                {
                    Quarter newQuarter = new Quarter();
                    quarters.Add(newQuarter);
                    DisplayQuarters(quarters);
                }
                catch (QuarterException ex)
                {
                    Console.WriteLine($"Error: {ex.Message} (Invalid Number: {ex.InvalidNumber})");
                    break;
                }
            }

        static void DisplayQuarters(List<Quarter> quarters)
        {
            var groupedQuarters = quarters.GroupBy(q => q.Value);
            
            Console.WriteLine("Existing Quarters:");
            foreach (var group in groupedQuarters)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
        }

        }
    }

