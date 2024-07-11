using TMPro;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void SetTextValue(double value)
    {
        _text.text = "+" + Formater.Format(value);
    }
}