using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    private float timeToWait;
    private void Start()
    {
        Invoke("Destroy", timeToWait);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
