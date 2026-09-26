using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    public event Action<CurrencyType, int> OnAddClicked;
    public event Action<CurrencyType, int> OnSubtractClicked;

    [SerializeField] private Image _imageCurrency;
    [SerializeField] private TMP_Text _countCurrency;
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _subtractButton;
    [SerializeField] private TMP_InputField _inputField;

    public CurrencyType Type { get; private set; }

    public void Initalize(CurrencyType type ,Sprite image, int startValue)
    {
        Type = type;
        _imageCurrency.sprite = image;
        UpdateText(startValue);
    }

    public void UpdateText(int newValue)
    {
        _countCurrency.text = newValue.ToString();
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
        if (int.TryParse(_inputField.text, out int amount))
        {
            OnAddClicked?.Invoke(Type, amount);
        }

        _inputField.text = "";
    }

    private void SubtractButtonClick()
    {
        if (int.TryParse(_inputField.text, out int amount))
        {
            OnSubtractClicked?.Invoke(Type, amount);
        }

        _inputField.text = "";
    }
}
