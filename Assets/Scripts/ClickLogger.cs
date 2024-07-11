using UnityEngine;

public class ClickLogger : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;

    [SerializeField] private ClickEffect _clickEffectPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Clickable>())
                {
                    _clicker.OnClick.Invoke();
                    CreateClickEffect(hitInfo.point);
                }
            }
        }
    }

    public void CreateClickEffect(Vector3 clickPosition)
    {
        ClickEffect newClickEffect = Instantiate(
            _clickEffectPrefab, clickPosition, Quaternion.identity);
        newClickEffect.SetTextValue(_clicker.CoinsPerClick);
    }
}