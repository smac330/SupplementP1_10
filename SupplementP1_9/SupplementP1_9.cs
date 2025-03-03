using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SupplementP1_9;

public class SupplementP1_9
{
    /// <summary>
    /// custom exception that is thrown when an invalid sequence is generated.
    /// </summary>
    public class InvalidSequence : Exception
        {
            /// <summary>
            /// initializes a new instance of the <see cref="InvalidSequence"/> class with a specified error message.
            /// </summary>
            /// <param name="message">the message that describes the error.</param>
            public InvalidSequence(string message) : base(message) { }
        }

        /// <summary>
        /// IEnumerable implementation that generates floating-point numbers between 0.0 and 1.0.
        /// throws an <see cref="InvalidSequence"/> if three consecutive numbers are <= 0.5.
        /// </summary>
        public class RandomFloatEnumerable : IEnumerable<double>
        {
            private static readonly Random _random = new Random();

            public IEnumerator<double> GetEnumerator()
            {
                int count = 0;
                while (true)
                {
                    double value = _random.NextDouble();
                    if (value <= 0.5)
                    {
                        count++;
                        if (count >= 3)
                        {
                            throw new InvalidSequence("Three consecutive values <= 0.5");
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    yield return value;
                }
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
