using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using SupplementP1_9;
using static SupplementP1_9.SupplementP1_9;

namespace SupplementP1_9.Tests;

public class UnitTest1
{
    [Fact]
    public void TestInvalidSequence()
    {
        var enumerator = new RandomFloatEnumerable().GetEnumerator();

        Assert.Throws<InvalidSequence>(() =>
        {
            while (enumerator.MoveNext())
            {
                var _ = enumerator.Current;
            }
        });
    }

    [Fact]
    public void TestQuarterEquality()
    {
        Assert.True(new Quarter(0.1) == new Quarter(0.2));
        Assert.True(new Quarter(0.3) == new Quarter(0.4));
        Assert.False(new Quarter(0.2) == new Quarter(0.3));
    }

    [Fact]
    public void TestQuarterComparison()
    {
        Assert.True(new Quarter(0.1) < new Quarter(0.3));
        Assert.False(new Quarter(0.7) < new Quarter(0.5));
        Assert.True(new Quarter(0.75) > new Quarter(0.5));
    }
}

