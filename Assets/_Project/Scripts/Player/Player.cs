using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(MedKitCollector))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Flipper))]
public class Player : BaseCharacter
{
    [SerializeField] private GroundChecker _groundChecker;

    private MedKitCollector _medKitCollector;
    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;
    private Flipper _flipper;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();
        _flipper = GetComponent<Flipper>();
        _medKitCollector = GetComponent<MedKitCollector>();
    }

    private void Update()
    {
        _flipper.FlipToDirection(_playerMovement.GetHorizontalInput());
        _playerAnimation.SetSpeed(_playerMovement.Rigidbody2D.linearVelocityX);
        _playerAnimation.SetIsJumping(_groundChecker.IsGrounded == false && _playerMovement.Rigidbody2D.linearVelocityY > 0);
        _playerAnimation.SetIsFalling(_groundChecker.IsGrounded == false && _playerMovement.Rigidbody2D.linearVelocityY < 0);
    }

    private void OnEnable()
    {
        _medKitCollector.MedKitCollected += OnMedKitCollected;
    }

    private void OnDisable()
    {
        _medKitCollector.MedKitCollected -= OnMedKitCollected;
    }

    private void OnMedKitCollected(int healthPoints)
    {
        Health.Heal(healthPoints);
    }
}
