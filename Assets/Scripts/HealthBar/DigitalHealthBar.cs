using UnityEngine;
using TMPro;

public class DigitalHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _healthText;

    protected override void DrawHealth(float currentHealth)
    {
        _healthText.text = currentHealth.ToString() + " / " + Health.MaxCount.ToString();
    }
}