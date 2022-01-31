using UnityEngine;
using UnityEngine.Events;

public class BucketHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent released;
    
    public void NotifyReleased()
    {
        released?.Invoke();
    }
}