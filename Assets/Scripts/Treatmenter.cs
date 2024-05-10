using UnityEngine;

public class Treatmenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _amountOfHealthRestored;

    public void Heal()
    {
        _health.CurrentCount += _amountOfHealthRestored;
    }
}
