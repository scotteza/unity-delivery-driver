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
    float _steeringSpeed = 1f;

    [SerializeField]
    float _movementSpeed = 0.02f;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Rotate(0, 0, _steeringSpeed);
        transform.Translate(0, _movementSpeed, 0);
    }
}
