using System.Collections;
using UnityEngine;

public class SizeScaller : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;
    
    [SerializeField] private Transform _center;
    [SerializeField] private AnimationCurve _curve;

    public float Duration;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _clicker.OnClick += Scale;
    }

    public void Scale()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ScaleProcess());
    }

    private IEnumerator ScaleProcess()
    {
        for (float t = 0; t < 1; t += Time.deltaTime / Duration)
        {
            _center.localScale = Vector3.one * _curve.Evaluate(t);
            yield return null;
        }
    }
    
    private void OnDisable()
    {
        _clicker.OnClick -= Scale;
    }
}