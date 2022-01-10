using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Damageobj : MonoBehaviour
{
    public damageobj damageObj;

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

    private void Update()
    {
        transform.position += damageObj.velocity * Time.deltaTime;
    }



    void OnDestroy()
    {
        DamageCheck.instance.obsinspace.Remove(this);
    }
}