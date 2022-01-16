using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standardshot : MonoBehaviour
{
    public List<GameObject> firepoint = new List<GameObject>();
    public GameObject bulletPrefab;
    float timer;
    public float attrate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attrate)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;
        Debug.Log(firepoint.Count);
        int i = 0;
        // so when I try and get this to just iterate though the firepoints it fails to work?
        // I can't be having a script for each ship with its fire points or a script per fire point this code is a clusterfuck enough as it is
        while (i < firepoint.Count)
        {
            Debug.Log("trying to shoot");
            Instantiate(bulletPrefab, firepoint[i].transform.position, firepoint[i].transform.rotation);
            i++;
        }
    }
}
