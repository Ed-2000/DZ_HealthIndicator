using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damage;

    public void Attack()
    {
        _health.CurrentCount -= _damage;
    }
}
