using System;
using System.Collections.Generic;

public class Wallet
{
    public event Action<CurrencyType, int> OnCurencyChanged;

    private Dictionary<CurrencyType, int> _currencies;

    public Wallet()
    {
        _currencies = new Dictionary<CurrencyType, int>();

        _currencies.Add(CurrencyType.coins, 0);
        _currencies.Add(CurrencyType.diamonds, 0);
        _currencies.Add(CurrencyType.energy, 0);
    }

    public int Get(CurrencyType type)
    {
        if (_currencies.TryGetValue(type, out int amount))
            return amount;
        return 0;
    }

    public void Add(CurrencyType type, int amount)
    {
        if (amount <= 0) return;

        _currencies[type] += amount;
        OnCurencyChanged?.Invoke(type, _currencies[type]);
    }

    public bool TrySubtract(CurrencyType type, int amount)
    {
        if (amount <= 0) return false;

        int currentAmount = Get(type);
        if (currentAmount - amount < 0) return false;

        _currencies[type] -= amount;
        OnCurencyChanged?.Invoke(type, _currencies[type]);
        return true;
    }
}
