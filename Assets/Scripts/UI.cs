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
        _smoothSlider.minValue = 0;
        _smoothSlider.maxValue = _health.MaxCount;
        _smoothSlider.value = _health.MaxCount;

        _slider.minValue = 0;
        _slider.maxValue = _health.MaxCount;
    }

    private void OnEnable()
    {
        _health.HealthHasChanged += DrawHealth;
    }

    private void OnDisable()
    {
        _health.HealthHasChanged -= DrawHealth;
    }

    private void DrawHealth(float currentHealth, float maxHealth)
    {
        _healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();

        FillingOfSlider(currentHealth, maxHealth);
        StartCoroutine(SmoothFillingOfSlider(currentHealth, maxHealth));
    }

    private void FillingOfSlider(float currentHealth, float maxHealth)
    {
        _slider.value = currentHealth;
    }

    private IEnumerator SmoothFillingOfSlider(float currentHealth, float maxHealth)
    {
        var wait = new WaitForFixedUpdate();

        while (_smoothSlider.value != currentHealth)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, currentHealth, _smoothSliderSpeed);
            yield return wait;
        }
    }
}