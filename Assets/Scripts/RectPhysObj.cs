using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectPhysObj : MonoBehaviour
{
    public Rectangle rectangle;

    // start is called before the first frame update
    void Start()
    {
        mainphysics.instance.rectinspace.Add(this);
        Sprite.vertices
    }

    // update is called once per frame
    void Update()
    {
        rectangle.position = transform.position;
        rectangle.width = (transform.localScale.x);
        rectangle.height = (transform.localScale.y);
        rectangle.ymin = transform.position.y - (rectangle.width / 2);
        rectangle.ymax = transform.position.y + (rectangle.width / 2);
        rectangle.xmin = transform.position.x - (rectangle.height / 2);
        rectangle.xmax = transform.position.x + (rectangle.height / 2);

    }

    void OnDestroy() {
        mainphysics.instance.rectinspace.Remove(this);
    }
}
