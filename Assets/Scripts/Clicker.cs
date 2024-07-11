using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public Action OnClick;
    public Action<double> OnCoinsChange; 

    [SerializeField] private Progress _progress;

    public double CoinsPerSecond;
    public double CoinsPerClick;
    public double CountCoins;

    private float _timer;

    private void Start()
    {
        OnClick += Click;
        _progress.UpdateCoins();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 1)
        {
            _timer = 0;
            CountCoins += CoinsPerSecond;
            _progress.UpdateCoins();
        }
    }

    public void Click()
    {
        CountCoins += CoinsPerClick;
        _progress.UpdateCoins();
    }

    public void AddCoinPerClick(double price, double value)
    {
        if(CountCoins<price) return;

        CountCoins -= price;
        CoinsPerClick += value;
        _progress.UpdateCoins();
    }
    
    public void AddCoinPerSecond(double price, double value)
    {
        if(CountCoins<price) return;

        CountCoins -= price;
        CoinsPerSecond += value;
        _progress.UpdateCoins();
    }
}