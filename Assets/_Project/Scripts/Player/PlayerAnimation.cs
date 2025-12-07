using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _isJumpingHash = Animator.StringToHash("IsJumping");
    private int _isFallingHash = Animator.StringToHash("IsFalling");
    private int _speedHash = Animator.StringToHash("Speed");

    public void SetIsJumping(bool isJumping)
    {
        _animator.SetBool(_isJumpingHash, isJumping);
    }

    public void SetIsFalling(bool isFalling)
    {
        _animator.SetBool(_isFallingHash, isFalling);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_speedHash, Mathf.Abs(speed));
    }
}
