using UnityEngine;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            Debug.Log("Collided with package");
        }
        else if (collision.tag == "Customer")
        {
            Debug.Log("Collided with customer");
        }
        else
        {
            Debug.Log($"Collided with {collision.tag}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
