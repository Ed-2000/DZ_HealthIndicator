using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxCount = 100.0f;

    private float _currentCount;

    public event Action<float, float> HealthHasChanged;

    public float CurrentCount
    {
        get => _currentCount;

        set
        {
            if (value < 0)
                _currentCount = 0;
            else if (value > MaxCount)
                _currentCount = MaxCount;
            else
                _currentCount = value;

            HealthHasChanged?.Invoke(_currentCount, MaxCount);
        }
    }

    public float MaxCount { get => _maxCount; }

    private void Awake()
    {
        CurrentCount = MaxCount;
        HealthHasChanged?.Invoke(CurrentCount, MaxCount);
    }
}