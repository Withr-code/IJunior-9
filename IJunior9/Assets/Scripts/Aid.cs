using UnityEngine;

public class Aid : MonoBehaviour
{
    [SerializeField] private Health _characterHealth;
    [SerializeField] private int _healValue;

    private void Heal()
    {
        _characterHealth.TakeHeal(_healValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            Heal();
    }
}
