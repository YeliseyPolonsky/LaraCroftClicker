using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class Level
{
    public GameObject Model;
    public int Clicks;
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Clicker _clicker;
    [SerializeField] private Image _levelBarImage;

    private int _clicks;
    private int _currentIndex;
    
    private float targetFillValue;

    private void Start()
    {
        ChangeLevelText();
        _clicker.OnClick += Click;
    }

    private void Update()
    {
        _levelBarImage.fillAmount = Mathf.Lerp
            (_levelBarImage.fillAmount,targetFillValue,Time.deltaTime * 10);
    }

    public void Click()
    {
        _clicks++;
        int targetClicks = _levels[_currentIndex].Clicks;

        if (targetClicks <= _clicks)
        {
            _clicks = 0;
            RaiseLevel();
            ChangeLevelText();
        }
        
        targetFillValue = (float)_clicks / targetClicks;
    }

    private void ChangeLevelText()
    {
        _levelText.text = "Уровень " + (_currentIndex + 1);
    }

    private void RaiseLevel()
    {
        _levels[_currentIndex].Model.SetActive(false);
        _currentIndex++;
        _levels[_currentIndex].Model.SetActive(true);
    }

    private void OnDestroy()
    {
        _clicker.OnClick -= Click;
    }
}