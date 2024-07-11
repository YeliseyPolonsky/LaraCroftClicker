using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public enum IncomOption
{
    PerClick,
    PerSecond
}

public class ShopButton : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private double _price;
    [SerializeField] private double _incom;
    [SerializeField] private Sprite _iconSprite;
    [SerializeField] private IncomOption _incomOption;

    [Space(20)] [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Button _button;
    [SerializeField] private Clicker _clicker;

    [Space(20)] 
    [SerializeField] private float Duration;
    [SerializeField] private AnimationCurve _curve;

    private void Awake()
    {
        _clicker.OnCoinsChange += UpdateButton;
    }

    private void Start()
    {
        _button.onClick.AddListener(Buy);
    }

    private void UpdateButton(double coins)
    {
        if (coins < _price)
        {
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }
    }

    private void OnValidate()
    {
        _nameText.text = _name;
        _priceText.text = Formater.Format(_price);
        _iconImage.sprite = _iconSprite;

        switch (_incomOption)
        {
            case IncomOption.PerClick:
                _descriptionText.text = "+" + Formater.Format(_incom) + " за клик";
                break;

            case IncomOption.PerSecond:
                _descriptionText.text = "+" + Formater.Format(_incom) + " в секунду";
                break;
        }
    }

    public void Buy()
    {
        switch (_incomOption)
        {
            case IncomOption.PerClick:
                _clicker.AddCoinPerClick(_price, _incom);
                break;

            case IncomOption.PerSecond:
                _clicker.AddCoinPerSecond(_price, _incom);
                break;
        }

        StartCoroutine(ScaleProcess());
    }
    
    private IEnumerator ScaleProcess()
    {
        for (float t = 0; t < 1; t += Time.deltaTime / Duration)
        {
            transform.localScale = Vector3.one * _curve.Evaluate(t);
            yield return null;
        }
    }

    private void OnDestroy()
    {
        _clicker.OnCoinsChange -= UpdateButton;
    }
}