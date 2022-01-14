using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetedshot : MonoBehaviour
{
    public Transform Firepoint;
    public Transform Firepoint2;
    public GameObject bulletPrefab;
    float timer;
    public float attrate;
    GameObject target;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
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
        Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
        Instantiate(bulletPrefab, Firepoint2.position, Firepoint2.rotation);
    }
}
