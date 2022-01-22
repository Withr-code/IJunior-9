using UnityEngine;

public class Aid : MonoBehaviour
{
    [SerializeField] private CharacterHealth _characterHealth;
    [SerializeField] private int _healValue;

    private void Heal()
    {
        _characterHealth.TryGetHeal(_healValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            Heal();
    }
}
