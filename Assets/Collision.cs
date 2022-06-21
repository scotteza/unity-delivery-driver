using UnityEngine;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision started");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision ended");
    }
}
