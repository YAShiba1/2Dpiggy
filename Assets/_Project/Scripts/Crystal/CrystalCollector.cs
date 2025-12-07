using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CrystalCollector : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Crystal crystal))
        {
            _audioSource.Play();

            crystal.SelfDestroy();
        }
    }
}
