using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CurrencyIconData
{
    public CurrencyType Type;
    public Sprite Icon;
}
public class WalletView : MonoBehaviour
{
    [SerializeField] private List<CurrencyIconData> _currencyIcons;
    [SerializeField] private Transform _walletContainer;
    [SerializeField] private CurrencyView _currencyPrefab;

    private Wallet _wallet;

    private List<CurrencyView> _spawnedViews = new List<CurrencyView>();

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
        {
            CurrencyView newCurrencyItem = Instantiate(_currencyPrefab, _walletContainer);
            Sprite icon = GetIconForCurrency(type);
            newCurrencyItem.Initalize(type, icon, _wallet.Get(type));

            newCurrencyItem.OnAddClicked += RequestAddCurrency;
            newCurrencyItem.OnSubtractClicked += RequestSubtractCurrency;

            _spawnedViews.Add(newCurrencyItem);
        }
        _wallet.OnCurencyChanged += UpdateCurrenyUI;
    }

    private void UpdateCurrenyUI(CurrencyType type, int newValue)
    {
        foreach (CurrencyView view in _spawnedViews)
        {
            if (view.Type == type)
            {
                view.UpdateText(newValue);
                break;
            }
        }
    }

    private void OnDestroy()
    {
        if (_wallet != null)
        {
            _wallet.OnCurencyChanged -= UpdateCurrenyUI;
        }

        foreach (CurrencyView view in _spawnedViews)
        {
            view.OnAddClicked -= RequestAddCurrency;
            view.OnSubtractClicked -= RequestSubtractCurrency;
        }
    }

    private void RequestAddCurrency(CurrencyType type, int amount)
    {
        _wallet.Add(type, amount);
    }

    private void RequestSubtractCurrency(CurrencyType type, int amount)
    {
        _wallet.TrySubtract(type, amount);
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
