using UnityEngine;

// ReSharper disable CheckNamespace
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Trigger : MonoBehaviour
{
    private const string PackageTag = "Package";
    private const string CustomerTag = "Customer";

    private int _carriedPackageCount = 0;

    [SerializeField] private float _destroyDelay = 0.5f;
    [SerializeField] private Color32 _hasPackageColor = new Color32(0, 255, 0, 255);
    [SerializeField] private Color32 _noPackageColor = new Color32(255, 255, 255, 255);

    [SerializeField] private AudioClip _pickUpAudioClip;
    [SerializeField] private AudioClip _dropOffAudioClip;
    [SerializeField] private AudioClip _dropOffFailedAudioClip;

    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

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
        _spriteRenderer.color = _hasPackageColor;
        _audioSource.PlayOneShot(_pickUpAudioClip);
        Destroy(package, _destroyDelay);
        Debug.Log("Picked up a package");
    }

    private void AttemptToDeliverPackage()
    {
        if (_carriedPackageCount == 0)
        {
            _audioSource.PlayOneShot(_dropOffFailedAudioClip);
            Debug.Log("You are not carrying any packages");
        }
        else
        {
            _carriedPackageCount = 0;
            _spriteRenderer.color = _noPackageColor;
            _audioSource.PlayOneShot(_dropOffAudioClip);
            Debug.Log($"Delivered {_carriedPackageCount} package(s) to the customer, good job!");
        }
    }
}
