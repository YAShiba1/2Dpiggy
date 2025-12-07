using System.Collections;
using UnityEngine;


public class SmoothHealthBar : SliderHealthBar
{
    [SerializeField] private float _sliderSpeed;

    private Coroutine _changeSliderValueCoroutine;

    protected override void OnHealthChanged(int health)
    {
        if(_changeSliderValueCoroutine != null)
        {
            StopCoroutine(_changeSliderValueCoroutine);
        }

        _changeSliderValueCoroutine = StartCoroutine(ChangeSliderValue(health));
    }

    private IEnumerator ChangeSliderValue(int targetValue)
    {
        while (HealthSlider.value != targetValue)
        {
            HealthSlider.value = Mathf.MoveTowards(HealthSlider.value, targetValue, _sliderSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
