using UnityEngine;

public class CamFlw : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    GameObject player, artist, chef, balooner, boss;

    private void Awake()
    {
        _offset = transform.position - target.position;
        player = GameObject.FindGameObjectWithTag("Player");
        artist = GameObject.FindGameObjectWithTag("Artist");
        chef = GameObject.FindGameObjectWithTag("Chef");
        balooner = GameObject.FindGameObjectWithTag("Balooner");
        boss = GameObject.FindGameObjectWithTag("Boss");
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
        if (DialogControl.playersTurn)
        {
            Vector3 targetPosition = player.transform.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        }
        else if (DialogControl.enemysTurn)
        {
            if (LevelScript.Completed1)
            {
                Vector3 targetPosition = chef.transform.position + _offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
            }
            else if (LevelScript.Completed2)
            {
                Vector3 targetPosition = balooner.transform.position + _offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
            }
            else if (LevelScript.Completed3)
            {
                Vector3 targetPosition = boss.transform.position + _offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
            }
            else
            {
                Vector3 targetPosition = artist.transform.position + _offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
            }
            
        }
        else
        {
            Vector3 targetPosition = player.transform.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        }
    }
}
