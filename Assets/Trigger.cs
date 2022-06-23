using UnityEngine;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Trigger : MonoBehaviour
{
    bool hasPackage = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            hasPackage = true;
            Debug.Log("Picked up package");
        }
        else if (collision.tag == "Customer")
        {
            AttemptToDeliverPackage();
        }
    }

    private void AttemptToDeliverPackage()
    {
        if (hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
        }
        else
        {
            Debug.Log("You can't deliver a package you haven't picked up");
        }
    }
}
