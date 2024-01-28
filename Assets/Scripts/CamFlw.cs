using UnityEngine;

public class CamFlw : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    GameObject player;

    private void Awake()
    {
        _offset = transform.position - target.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        if (Cinematic.isCineOn)
        {
            gameObject.GetComponent<Camera>().fieldOfView = 35;
        }
        else
        {
            gameObject.GetComponent<Camera>().fieldOfView = 60;
        }
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
