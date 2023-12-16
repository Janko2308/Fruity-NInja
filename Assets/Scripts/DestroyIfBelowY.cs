using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfBelowY : MonoBehaviour
{
    public float yThreshold = -10.0f;
    public float destructionDelay = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destructionDelay);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yThreshold)
        {
            Destroy(gameObject);
        }
    }
}
