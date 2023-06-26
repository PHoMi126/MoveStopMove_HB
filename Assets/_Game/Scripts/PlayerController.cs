using UnityEngine;
using static CharacterController;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] FloatingJoystick _joystick;
    [SerializeField] GameOverMenu _gameOverMenu;
    [SerializeField] float _moveSpeed;

    private float horizontal;
    private float vertical;
    private Vector3 direction;

    public CharacterController _characterController;

    private void Start()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Moving();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Stopping();
        }
        else if (_characterController.animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            _rigidbody.velocity = Vector3.zero;
            Invoke(nameof(PlayerDead), 2f);
        }
    }

    private void Moving()
    {
        if (_joystick != null && _characterController != null)
        {
            _characterController.ChangeAnimation(AnimState.Run);
            horizontal = _joystick.Horizontal;
            vertical = _joystick.Vertical;
            if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
            {
                direction = new Vector3(horizontal, 0f, vertical);
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720f * Time.deltaTime);
                transform.position += _moveSpeed * Time.deltaTime * direction;
            }
        }
    }

    private void Stopping()
    {
        _characterController.ChangeAnimation(AnimState.Idle);
        _rigidbody.velocity = Vector3.zero;
    }

    private void PlayerDead()
    {
        gameObject.SetActive(false);
        _joystick.gameObject.SetActive(false);
        _gameOverMenu.gameObject.SetActive(true);
    }
}