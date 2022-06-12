using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _characterHealth;
    [SerializeField] private int _damageValue;

    private void Damage()
    {
        _characterHealth.TakeDamage(_damageValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Damage();
    }
}
