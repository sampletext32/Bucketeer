using UnityEngine;
using UnityEngine.Events;

public class TaskDrag : MonoBehaviour
{
    private bool _isDragging;

    private Transform _transform;
    private Camera _camera;
    
    private BucketHandler _activeBucket;

    private void Start()
    {
        _transform = transform;
        _camera    = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _activeBucket = other.GetComponent<BucketHandler>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _activeBucket = null;
    }

    private void OnMouseDown()
    {
        _isDragging = true;
        
        Debug.Log("DOWN");
    }

    private void OnMouseUp()
    {
        _isDragging = false;
        _activeBucket?.NotifyReleased();
    }

    private void OnMouseDrag()
    {
        if (_isDragging)
        {
            var delta = _camera.ScreenToWorldPoint(Input.mousePosition) - _transform.position;

            // eliminate Z offset
            _transform.Translate(delta.x, delta.y, 0);
        }
    }
}