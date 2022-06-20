using UnityEngine;

// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable CheckNamespace
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Driver : MonoBehaviour
{
    [SerializeField]
    float _steeringSpeed = 0.8f;

    [SerializeField]
    float _movementSpeed = 0.02f;

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
        var steerAmount = Input.GetAxis("Horizontal") * _steeringSpeed;
        transform.Rotate(0, 0, -steerAmount);
    }

    private void Move()
    {
        var moveAmount = Input.GetAxis("Vertical") * _movementSpeed;
        transform.Translate(0, moveAmount, 0);
    }
}
