using System.Collections.Generic;

public class Wallet
{
    private List<Currency> _currencies;

    public List<Currency> Currencies => _currencies;

    public Wallet()
    {
        _currencies = new List<Currency>();

        _currencies.Add(new Currency(CurrencyType.coins, 0));
        _currencies.Add(new Currency(CurrencyType.diamonds, 0));
        _currencies.Add(new Currency(CurrencyType.energy, 0));
    }
}
