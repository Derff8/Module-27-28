using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    public event Action<CurrencyType> OnAddClicked;
    [SerializeField] private Image _imageCurrency;
    [SerializeField] private TMP_Text _countCurrency;
    [SerializeField] private Button _addButton;

    private Currency _myCurrency;

    public void Initalize(Sprite image, Currency currency)
    {
        _imageCurrency.sprite = image;
        _myCurrency = currency;

        UpdateText(_myCurrency.Value);

        _myCurrency.OnValueChanged += UpdateText;
    }


    private void UpdateText(int newValue)
    {
        _countCurrency.text = newValue.ToString();
    }

    private void OnDestroy()
    {
        if (_myCurrency != null)
        {
            _myCurrency.OnValueChanged -= UpdateText;
        }
    }

    private void OnEnable()
    {
        _addButton.onClick.AddListener(ButtonClick);
    }

    private void OnDisable()
    {
        _addButton.onClick.RemoveListener(ButtonClick);
    }

    private void ButtonClick()
    {
        OnAddClicked?.Invoke(_myCurrency.Tipe);
    }
}
