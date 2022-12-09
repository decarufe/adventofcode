using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode;

public static class EnumeratorExtensions
{
    public static CustomIntEnumerator GetEnumerator(this Range range)
    {
        return new CustomIntEnumerator(range);
    }

    public static IEnumerable<int> Iterate(this Range range)
    {
        return Enumerable.Range(range.Start.Value, range.End.Value);
    }
}

public ref struct CustomIntEnumerator
{
    private int _current;
    private int _end;

    public CustomIntEnumerator(Range range)
    {
        _current = range.Start.Value - 1;
        _end = range.End.IsFromEnd ? int.MaxValue : range.End.Value;
    }

    public int Current => _current;

    public bool MoveNext() => ++_current <= _end;
}