using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    private Wallet _wallet;

    public List<Currency> Currency => _wallet.Currencies;

    private void Awake()
    {
        _wallet = new Wallet();
    }

    public void AddCurrency(CurrencyType type)
    {
        foreach (Currency currency in Currency)
            if (currency.Tipe == type)
                currency.AddValue();
    }
}
