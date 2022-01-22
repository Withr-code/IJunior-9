using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]

public class SliderValueChanger : MonoBehaviour
{
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private CharacterHealth _health;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _health.ValueChanged += OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        StartCoroutine(_smoothValueChange());
    }

    private IEnumerator _smoothValueChange()
    {
        while (_slider.value != _health.Value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.Value, _transitionSpeed * Time.deltaTime);

            yield return null;
        }

        yield break;
    }
}
