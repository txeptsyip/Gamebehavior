using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mainphysics : MonoBehaviour
{
    public static mainphysics instance;

    public List<PhysicsObject> objinspace = new List<PhysicsObject>();
    public List<RectPhysObj> rectinspace = new List<RectPhysObj>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for(int a = 0; a < objinspace.Count; a++)
        {
            for(int b = 0; b < objinspace.Count; b++)
            {
                if (a != b)
                {
                    var current = objinspace[a];
                    var other = objinspace[b];
                    var intersecting = Colliding(current.circle, other.circle);
                    if (intersecting)
                    {
                        Debug.Log("intersecting");
                    }
                }
            }
        }
        for (int a = 0; a < rectinspace.Count; a++)
        {
            for (int b = 0; b < rectinspace.Count; b++)
            {
                if (a != b)
                {
                    var current = rectinspace[a];
                    var other = rectinspace[b];
                    var intersecting = RectColliding(current.rectangle, other.rectangle);
                    if (intersecting)
                    {
                        Debug.Log("intersecting");
                    }
                }
            }
        }
    }

    bool Colliding(Circle shapeA, Circle shapeB)
    {
        var distance = (shapeA.position - shapeB.position).magnitude;
        if ((shapeA.radius + shapeB.radius) > distance)
        {
            return true;
        }
        else return false;
    }
    bool RectColliding(Rectangle shapeA, Rectangle shapeB)
    {
        if (shapeA.xmax > shapeB.xmin && shapeA.xmin < shapeB.xmax && shapeA.ymax > shapeB.ymin && shapeA.ymin < shapeB.ymax)
        {
            return true;
        }
        else return false;
    }
}

[System.Serializable]
public class Circle
{
    public Vector3 position;
    public float radius = 1f;
}
[System.Serializable]
public class Rectangle
{
    public Vector3 position;
    public float xmax = 1f;
    public float xmin = 1f;
    public float ymax = 1f;
    public float ymin = 1f;
    public float width = 1f;
    public float height = 1f;
    public Vector3 Velocity;
    public float Drag;
}