using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthBar : HealthBar
{
    protected Slider HealthSlider;

    private void Awake()
    {
        HealthSlider = GetComponent<Slider>();

        HealthSlider.maxValue = CharacterHealth.Max;
        HealthSlider.value = HealthSlider.maxValue;
    }

    protected override void OnHealthChanged(int health)
    {
        HealthSlider.value = health;
    }
}
