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

            Debug.Log("trying to shoot");
            Instantiate(bulletPrefab, firepoint[0].transform.position, firepoint[0].transform.rotation);

    }
}
