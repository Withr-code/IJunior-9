using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    private int _value;

    public event UnityAction<int> Changed;

    private void Awake()
    {
        _value = _maxValue;
    }

    public void TakeDamage(int damageValue)
    {
        _value = Mathf.Clamp(_value - damageValue, _minValue, _maxValue);
        Changed?.Invoke(_value);
    }

    public void TakeHeal(int healValue)
    {
        _value = Mathf.Clamp(_value + healValue, _minValue, _maxValue);
        Changed?.Invoke(_value);
    }
}
