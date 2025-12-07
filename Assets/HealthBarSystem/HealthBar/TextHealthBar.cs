using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextHealthBar : HealthBar
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        OnHealthChanged(CharacterHealth.Max);
    }

    protected override void OnHealthChanged(int health)
    {
        _text.text = health.ToString() + " / " + CharacterHealth.Max;
    }
}
