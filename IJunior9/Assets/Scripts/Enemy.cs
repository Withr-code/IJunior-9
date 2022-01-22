using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private CharacterHealth _characterHealth;
    [SerializeField] private int _damageValue;

    private void Damage()
    {
        _characterHealth.TryGetDamage(_damageValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Damage();
    }
}
