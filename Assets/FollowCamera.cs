using UnityEngine;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _thingToFollow;

    private void LateUpdate()
    {
        transform.position = _thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
