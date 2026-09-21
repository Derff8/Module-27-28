using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency
{
    public event Action<int> OnValueChanged;

    public Currency(CurrencyType tipe, int value)
    {
        Tipe = tipe;
        Value = value;
    }

    public CurrencyType Tipe { get; }
    public int Value { get; private set; }

    public void AddValue()
    {
        Value++;

        OnValueChanged?.Invoke(Value);
    }

}
