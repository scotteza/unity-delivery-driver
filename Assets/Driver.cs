using UnityEngine;
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Driver : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        transform.Rotate(0, 0, 0.2f);
        transform.Translate(0, 0.02f, 0);
    }
}
