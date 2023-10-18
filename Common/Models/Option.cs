using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace Common.Models;
public class Option<T>
{
    public T Value { get; private set; }
    public bool HasValue { get; private set; }

    private Option()
    {
        Value = default(T);
        HasValue = false;
    }

    public static Option<T> CreateSome<T>(T value)
    {
        if (value != null)
        {
            return new Option<T>
            {

                Value = value,
                HasValue = true
            };
        }

        return new Option<T>
        {
            HasValue = false,
            Value = default(T)
        };
    }
}