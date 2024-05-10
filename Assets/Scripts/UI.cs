using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _smoothSliderSpeed = 0.5f;

    private void Awake()
    {
        InitSlider(0, _health.MaxCount, _slider);
        InitSlider(0, _health.MaxCount, _smoothSlider);
    }

    private void OnEnable()
    {
        _health.HealthHasChanged += DrawHealth;
    }

    private void OnDisable()
    {
        _health.HealthHasChanged -= DrawHealth;
    }

    private void InitSlider(float minValue, float maxValue, Slider slider)
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    private void DrawHealth(float currentHealth, float maxHealth)
    {
        _healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();

        FillingOfSlider(currentHealth);
        StartCoroutine(SmoothFillingOfSlider(currentHealth));
    }

    private void FillingOfSlider(float currentHealth)
    {
        _slider.value = currentHealth;
    }

    private IEnumerator SmoothFillingOfSlider(float currentHealth)
    {
        var wait = new WaitForFixedUpdate();

        while (_smoothSlider.value != currentHealth)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, currentHealth, _smoothSliderSpeed);
            yield return wait;
        }
    }
}