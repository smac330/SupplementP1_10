using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// represents a Quarter, a floating-point number categorized into four equal ranges.
/// </summary>

public class Quarter
{
    private static int counter = 0;

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

    public Quarter()
    {

        /// <summary>
        /// Initializes a new instance of the Quarter class. 
        /// Throws an exception if more than four quarters are created.
        /// </summary>
        
        counter++;

        if (counter > 4)
        {
            throw new QuarterException("Quarter limit exceeded", counter);
        }
        Value = counter;
    }
}

public class Program{
    public static void Main()
    {
        /// <summary>
        /// Entry point of the application. Handles user choices and manages the quarters list.
        /// </summary>
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

        /// <summary>
        /// Displays the current quarters, grouping them by value to ensure a maximum of four lines.
        /// </summary>
        /// <param name="quarters">List of quarters to be displayed.</param>
        
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

/// <summary>
/// Custom exception for Quarter limit violations.
/// </summary>

public class QuarterException : Exception{
    /// <summary>
    /// Gets the invalid number that caused the exception.
    /// </summary>
    public int InvalidNumber { get; }

    /// <summary>
    /// Initializes a new instance of the QuarterException class with a message and invalid number.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="invalidNumber">The number that caused the exception.</param>
    public QuarterException(string message, int invalidNumber) : base(message)
    {
        InvalidNumber = invalidNumber;
    }
}


