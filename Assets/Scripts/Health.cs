using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxCount = 100.0f;

    private float _currentCount;

    public event Action<float> HasChanged;

    public float CurrentCount
    {
        get => _currentCount;

        set
        {
            _currentCount = Mathf.Clamp(value, 0, MaxCount);
            HasChanged?.Invoke(_currentCount);
        }
    }

    public float MaxCount { get => _maxCount; }

    private void Awake()
    {
        CurrentCount = MaxCount;
        HasChanged?.Invoke(CurrentCount);
    }
}