using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _startingTransform;
    public Camera gameCamera;
    public GameObject levelManagerObject;
    private LevelManager _levelManager;

    // Start is called before the first frame update
    private void Start()
    {
        _startingTransform = transform;
        _levelManager = levelManagerObject.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Moved) return;
        var newPosition =
            gameCamera.ScreenToWorldPoint(touch.position);
//                Debug.Log("touched coordinates: " + pos);
        transform.position = new Vector3(newPosition.x,
            _startingTransform.position.y,
            _startingTransform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _levelManager.RestartLevel();
        }
    }
}