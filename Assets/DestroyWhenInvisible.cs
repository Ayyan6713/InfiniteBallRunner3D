
using UnityEngine;

public class DestroyWhenInvisible : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Debug.Log("ayyan");
        Destroy(transform.parent.gameObject);
    }
}

