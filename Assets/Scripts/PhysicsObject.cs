using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    public Circle circle;

    // Start is called before the first frame update
    void Start()
    {
        mainphysics.instance.objinspace.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        circle.position = transform.position;
        circle.radius = ((transform.localScale.x + transform.localScale.y) / 2) / 2;
    }

    void OnDestroy()
    {
        mainphysics.instance.objinspace.Remove(this);
    }
}
