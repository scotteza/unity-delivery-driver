using UnityEngine;

// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable CheckNamespace
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Driver : MonoBehaviour
{
    private const string BoostTag = "Boost";

    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] float _steeringSpeed = 300;
    [SerializeField] float _movementSpeed = 20;
    [SerializeField] float _slowSpeed = 10;
    [SerializeField] float _fastSpeed = 40;

    private void Start()
    {
    }

    private void Update()
    {
        Steer();
        Move();
    }

    private void Steer()
    {
        var steerAmount = Input.GetAxis(HorizontalAxisName) * _steeringSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
    }

    private void Move()
    {
        var moveAmount = Input.GetAxis(VerticalAxisName) * _movementSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == BoostTag)
        {
            _movementSpeed = _fastSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _movementSpeed = _slowSpeed;
    }
}
