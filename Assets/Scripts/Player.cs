using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _startingTransform;
    public Camera GameCamera;

    // Start is called before the first frame update
    private void Start()
    {
        _startingTransform = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Moved) return;
        var newPosition =
            GameCamera.ScreenToWorldPoint(touch.position);
//                Debug.Log("touched coordinates: " + pos);
        transform.position = new Vector3(newPosition.x,
            _startingTransform.position.y,
            _startingTransform.position.z);
    }
}