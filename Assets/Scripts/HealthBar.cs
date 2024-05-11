using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected void InitSlider(float minValue, float maxValue, Slider slider)
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    private void OnEnable()
    {
        Health.HealthHasChanged += DrawHealth;
    }

    private void OnDisable()
    {
        Health.HealthHasChanged -= DrawHealth;
    }


    protected virtual void DrawHealth(float currentHealth)
    {
    }
}