using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    public AObstacle aObstacle;

    void Start()
    {
        Obstacle.instance.obsinspace.Add(this);
    }


    // Update is called once per frame
    void Update()
    {
        aObstacle.position = transform.position;
        aObstacle.width = (transform.localScale.x);
        aObstacle.height = (transform.localScale.y);
        aObstacle.ymin = transform.localPosition.y - (aObstacle.width / 2);
        aObstacle.ymax = transform.localPosition.y + (aObstacle.width / 2);
        aObstacle.xmin = transform.localPosition.x - (aObstacle.height / 2);
        aObstacle.xmax = transform.localPosition.x + (aObstacle.height / 2);
    }

    

    void OnDestroy()
    {
        Obstacle.instance.obsinspace.Remove(this);
    }
}
