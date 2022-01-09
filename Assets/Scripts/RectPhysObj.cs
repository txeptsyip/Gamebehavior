using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RectPhysObj : MonoBehaviour
{
    public Rectangle rectangle;

    // start is called before the first frame update
    void Start()
    {
        mainphysics.instance.rectinspace.Add(this);
    }

    // update is called once per frame
    void Update()
    {
        rectangle.position = transform.position;
        rectangle.width = (transform.localScale.x);
        rectangle.height = (transform.localScale.y);
        rectangle.ymin = transform.localPosition.y - (rectangle.width / 2);
        rectangle.ymax = transform.localPosition.y + (rectangle.width / 2);
        rectangle.xmin = transform.localPosition.x - (rectangle.height / 2);
        rectangle.xmax = transform.localPosition.x + (rectangle.height / 2);

        transform.position = new Vector3 (transform.position.x + (rectangle.Velocity.x * Time.fixedDeltaTime), transform.position.y + (rectangle.Velocity.y * Time.fixedDeltaTime), 0);


        rectangle.Velocity.x = (1 - (rectangle.Drag * Time.fixedDeltaTime)) * rectangle.Velocity.x;
        rectangle.Velocity.y = (1 - (rectangle.Drag * Time.fixedDeltaTime)) * rectangle.Velocity.y;
        if ((Mathf.Abs(rectangle.Velocity.x) < 0.0001) && (Mathf.Abs(rectangle.Velocity.y) < 0.0001))
        {
            rectangle.Velocity.x = 0;
            rectangle.Velocity.y = 0;
        }
    }

    void OnDestroy() {
        mainphysics.instance.rectinspace.Remove(this);
    }
}
