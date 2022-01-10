using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacles : MonoBehaviour
{
    public AObstacle anObstacle;

    void Start()
    {
        Obstacle.instance.obsinspace.Add(this);
        anObstacle.position = transform.position;
        anObstacle.width = (transform.GetComponent<SpriteRenderer>().bounds.size.x);
        anObstacle.height = (transform.GetComponent<SpriteRenderer>().bounds.size.y);
        //anObstacle.width = (transform.localScale.x);
        //anObstacle.height = (transform.localScale.y);
        anObstacle.ymin = transform.localPosition.y - (anObstacle.height / 2);
        anObstacle.ymax = transform.localPosition.y + (anObstacle.height / 2);
        anObstacle.xmin = transform.localPosition.x - (anObstacle.width / 2);
        anObstacle.xmax = transform.localPosition.x + (anObstacle.width / 2);
    }



    void OnDestroy()
    {
        Obstacle.instance.obsinspace.Remove(this);
    }
}
