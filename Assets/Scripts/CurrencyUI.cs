using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct CurrencyIconData
{
    public CurrencyType Type;
    public Sprite Icon;
}
public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private List<CurrencyIconData> _currencyIcons;

    [SerializeField] private WalletExample _wallet;
    [SerializeField] private Transform _walletContainer;
    [SerializeField] private CurrencyView _currencyPrefab;

    private List<Currency> _currencies;

    private void Start()
    {
        _currencies = _wallet.Currency;

        foreach (Currency currency in _currencies)
        {
            CurrencyView newCurrencyItem = Instantiate(_currencyPrefab, _walletContainer);
            Sprite icon = GetIconForCurrency(currency.Tipe);
            newCurrencyItem.Initalize(icon, currency);

            newCurrencyItem.OnAddClicked += RequestAddCurrency;
        }            
    }

    private void RequestAddCurrency(CurrencyType type)
    {
        _wallet.AddCurrency(type);
    }

    private Sprite GetIconForCurrency(CurrencyType tipe)
    {
        foreach (CurrencyIconData data in _currencyIcons)
        {
            if (data.Type == tipe)
                return data.Icon;
        }
        return null;
    }
}
