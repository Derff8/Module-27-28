using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    public event Action<CurrencyType> OnAddClicked;
    public event Action<CurrencyType> OnSubtractClicked;
    [SerializeField] private Image _imageCurrency;
    [SerializeField] private TMP_Text _countCurrency;
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _subtractButton;

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
        _addButton.onClick.AddListener(AddButtonClick);
        _subtractButton.onClick.AddListener(SubtractButtonClick);
    }

    private void OnDisable()
    {
        _addButton.onClick.RemoveListener(AddButtonClick);
        _subtractButton.onClick.RemoveListener(SubtractButtonClick);
    }

    private void AddButtonClick()
    {
        OnAddClicked?.Invoke(_myCurrency.Tipe);
    }

    private void SubtractButtonClick()
    {
        OnSubtractClicked?.Invoke(_myCurrency.Tipe);
    }
}
