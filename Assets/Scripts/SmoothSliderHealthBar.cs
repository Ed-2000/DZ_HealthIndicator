using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHealthBar : HealthBar
{
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _smoothSliderSpeed = 0.5f;

    private void OnEnable()
    {
        Health.HealthHasChanged += DrawHealth;
    }

    private void OnDisable()
    {
        Health.HealthHasChanged -= DrawHealth;
    }
    
    private void Awake()
    {
        InitSlider(0, Health.MaxCount, _smoothSlider);
    }

    protected override void DrawHealth(float currentHealth)
    {
        StartCoroutine(SmoothFillingOfSlider(currentHealth));
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