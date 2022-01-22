using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public int Value { get; private set; }

    public event UnityAction ValueChanged;

    private void Awake()
    {
        Value = _maxValue;
    }

    public void TryGetDamage(int damageValue)
    {
        Value -= damageValue;
        TryClampValue();
    }

    public void TryGetHeal(int healValue)
    {
        Value += healValue;
        TryClampValue();
    }

    private void TryClampValue()
    {
        if (Value >= _minValue && Value <= _maxValue)
            ValueChanged?.Invoke();
        else
            Value = Mathf.Clamp(Value, _minValue, _maxValue);
    }
}
