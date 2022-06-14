using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;
    [Space]
    [SerializeField] private int _healValue;

    public int Value { get; private set; }

    public event UnityAction<int> ValueChanged;

    private void Awake()
    {
        Value = _maxValue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            Heal(_healValue);
    }

    public void TakeDamage(int damageValue)
    {
        Value -= damageValue;

        Value = Mathf.Clamp(Value, _minValue, _maxValue);
        ValueChanged?.Invoke(Value);
    }

    public void Heal(int healValue)
    {
        Value += healValue;

        Value = Mathf.Clamp(Value, _minValue, _maxValue);
        ValueChanged?.Invoke(Value);
    }
}
