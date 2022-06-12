using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.ValueChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnHealthChanged;
        
    }

    private void OnHealthChanged(int newValue)
    {
        StartCoroutine(_smoothValueChange(newValue));
    }

    private IEnumerator _smoothValueChange(int newValue)
    {
        while (_slider.value != _health.Value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, newValue, _transitionSpeed * Time.deltaTime);

            yield return null;
        }

        yield break;
    }
}
