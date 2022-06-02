using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    #region MonoBehaviour

    private void OnValidate()
    {
        _jumpSpeed = _jumpSpeed < 0 ? 0 : _jumpSpeed;
        _rotationSpeed = _rotationSpeed < 0 ? 0 : _rotationSpeed;
        if (_minRotationZ > _maxRotationZ)
        {
            _minRotationZ = _maxRotationZ;
        }
    }

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void Start()
    {
        transform.position = _startPosition;
        transform.rotation = _minRotation;
    }

    private void Update()
    {
        if (transform.rotation != _minRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    #endregion

    public void Jump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Force);
        transform.rotation = _maxRotation;
    }
}
