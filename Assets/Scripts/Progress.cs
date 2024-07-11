using TMPro;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;
    
    [SerializeField] private TMP_Text _countCoinsText;
    [SerializeField] private TMP_Text _coinPerSecondText;

    public void UpdateCoins()
    {
        _countCoinsText.text = Formater.Format(_clicker.CountCoins);
        _coinPerSecondText.text = Formater.Format(_clicker.CoinsPerSecond);
        
        _clicker.OnCoinsChange?.Invoke(_clicker.CountCoins);
    }
}
