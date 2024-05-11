using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        InitSlider(0, Health.MaxCount, _slider);
    }

    protected override void DrawHealth(float currentHealth)
    {
        _slider.value = currentHealth;
    }
}