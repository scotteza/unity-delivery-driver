using UnityEngine;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger area hit");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left trigger area");
    }
}
