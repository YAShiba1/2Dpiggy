using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AbilityAura : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _defaultAlpha;

    private Coroutine _auraTransparencyCoroutine;

    public float Radius => _spriteRenderer.bounds.extents.x;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _defaultAlpha = _spriteRenderer.color.a;
    }

    public void StartTransparencyCoroutine(float duration)
    {
        if (_auraTransparencyCoroutine != null)
        {
            StopCoroutine(_auraTransparencyCoroutine);
        }

        StartCoroutine(ChangeAuraTransparency(duration));
    }

    private IEnumerator ChangeAuraTransparency(float duration)
    {
        float timeElapsed = 0;
        float startAlpha = 0f;
        float endAlpha = _defaultAlpha;

        Color currentColor = _spriteRenderer.color;

        while (timeElapsed < duration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / duration);

            currentColor.a = newAlpha;
            _spriteRenderer.color = currentColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        currentColor.a = endAlpha;
        _spriteRenderer.color = currentColor;
    }
}
