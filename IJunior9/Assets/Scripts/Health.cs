using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;
    [Space]
    [SerializeField] private int _healValue;

    private int _value;

    public event UnityAction<int> ValueChanged;

    private void Awake()
    {
        _value = _maxValue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            Heal(_healValue);
    }

    public void TakeDamage(int damageValue)
    {
        _value -= damageValue;

        _value = Mathf.Clamp(_value, _minValue, _maxValue);
        ValueChanged?.Invoke(_value);
    }

    public void Heal(int healValue)
    {
        _value += healValue;

        _value = Mathf.Clamp(_value, _minValue, _maxValue);
        ValueChanged?.Invoke(_value);
    }
}
