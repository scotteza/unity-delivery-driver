using UnityEngine;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Trigger : MonoBehaviour
{
    private const string PackageTag = "Package";
    private const string CustomerTag = "Customer";

    private int _carriedPackageCount = 0;
    [SerializeField] private float _destroyDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PackageTag)
        {
            var package = collision.gameObject;
            PickUpPackage(package);
        }

        if (collision.tag == CustomerTag)
        {
            AttemptToDeliverPackage();
        }
    }

    private void PickUpPackage(GameObject package)
    {
        _carriedPackageCount++;
        Destroy(package, _destroyDelay);
        Debug.Log("Picked up a package");
    }

    private void AttemptToDeliverPackage()
    {
        if (_carriedPackageCount == 0)
        {
            Debug.Log("You are not carrying any packages");
        }
        else
        {
            Debug.Log($"Delivered {_carriedPackageCount} package(s) to the customer, good job!");
            _carriedPackageCount = 0;
        }
    }
}
