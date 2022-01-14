using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Damageobj : MonoBehaviour
{
    public damageobj damageObj;
    GameObject target;
    Vector3 direction;

    void Start()
    {
        DamageCheck.instance.obsinspace.Add(this);
        damageObj.position = transform.position;
        damageObj.width = (transform.GetComponent<SpriteRenderer>().bounds.size.x);
        damageObj.height = (transform.GetComponent<SpriteRenderer>().bounds.size.y);
        //anObstacle.width = (transform.localScale.x);
        //anObstacle.height = (transform.localScale.y);
        damageObj.ymin = transform.localPosition.y - (damageObj.height / 2);
        damageObj.ymax = transform.localPosition.y + (damageObj.height / 2);
        damageObj.xmin = transform.localPosition.x - (damageObj.width / 2);
        damageObj.xmax = transform.localPosition.x + (damageObj.width / 2);
    }

    private void Awake()
    {
        if (damageObj.istargeted == true)
        {
            target = GameObject.FindWithTag("Player");
            direction = (this.transform.position - target.transform.position).normalized;
            Debug.Log(direction);
            direction.z = 0;
            direction.x = -Mathf.Abs(direction.x);
            //direction.x += direction.x * 3;
            direction.y = -Mathf.Abs(direction.y);
            this.damageObj.velocity = direction;
        }
    }

    private void Update()
    {
        damageObj.position = transform.position;
        damageObj.width = (transform.GetComponent<SpriteRenderer>().bounds.size.x);
        damageObj.height = (transform.GetComponent<SpriteRenderer>().bounds.size.y);
        //anObstacle.width = (transform.localScale.x);
        //anObstacle.height = (transform.localScale.y);
        damageObj.ymin = transform.localPosition.y - (damageObj.height / 2);
        damageObj.ymax = transform.localPosition.y + (damageObj.height / 2);
        damageObj.xmin = transform.localPosition.x - (damageObj.width / 2);
        damageObj.xmax = transform.localPosition.x + (damageObj.width / 2);
        transform.position += damageObj.velocity * Time.deltaTime;
        if (damageObj.Health < 0)
        {
            Destroy(gameObject);
        }
    }



    void OnDestroy()
    {
        DamageCheck.instance.obsinspace.Remove(this);
    }
}