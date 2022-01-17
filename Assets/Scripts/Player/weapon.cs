using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform Firepoint;
    public Transform Firepoint2;
    public GameObject bulletPrefab;
    public float RoF;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (timer >= RoF)
            {
                Shoot();
                timer = 0;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
        Instantiate(bulletPrefab, Firepoint2.position, Firepoint2.rotation);
    }    
}
