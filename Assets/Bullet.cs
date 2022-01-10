using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (0 * Time.fixedDeltaTime), transform.position.y + (speed * Time.fixedDeltaTime), 0);
    }
}
