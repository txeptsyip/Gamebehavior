using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform Firepoint;
    public Transform Firepoint2;
    public GameObject bulletPrefab;
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
        Instantiate(bulletPrefab, Firepoint2.position, Firepoint2.rotation);
    }    
}
