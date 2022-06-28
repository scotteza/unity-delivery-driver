using UnityEngine;

// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable CheckNamespace
// ReSharper disable ConvertToConstant.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

public class Driver : MonoBehaviour
{
    private const string BoostTag = "Boost";

    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private float _steeringSpeed = 300;
    [SerializeField] private float _movementSpeed = 20;
    [SerializeField] private float _slowSpeed = 10;
    [SerializeField] private float _fastSpeed = 40;

    private AudioSource _audioSource;

    [SerializeField] private AudioClip _speedUpAudioClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();
        _audioSource.mute = false;
    }

    private void Update()
    {
        Steer();
        var moveAmount = GetMoveAmount();
        Move(moveAmount);
        ManageCarEngineAudio(moveAmount);
    }

    private void Steer()
    {
        var steerAmount = Input.GetAxis(HorizontalAxisName) * _steeringSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
    }

    private float GetMoveAmount()
    {
        return Input.GetAxis(VerticalAxisName) * _movementSpeed * Time.deltaTime;
    }

    private void Move(float moveAmount)
    {
        ManageCarEngineAudio(moveAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void ManageCarEngineAudio(float moveAmount)
    {
        if (moveAmount == 0)
        {
            _audioSource.mute = true;
            _audioSource.Stop();
            return;
        }

        _audioSource.mute = false;
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == BoostTag)
        {
            _movementSpeed = _fastSpeed;
            _audioSource.PlayOneShot(_speedUpAudioClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _movementSpeed = _slowSpeed;
    }
}
