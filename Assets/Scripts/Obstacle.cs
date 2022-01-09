using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static Obstacle instance;

    public List<Obstacles> obsinspace = new List<Obstacles>();

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

    void Start()
    {
    }

    public bool checkobstacle(float nodesize, Vector3 worldposition)
    {
        float height = nodesize, width = nodesize;
        float xmax = worldposition.x + (height / 2);
        float ymax = worldposition.y + (width / 2);
        float ymin = worldposition.y - (width / 2);
        float xmin = worldposition.x - (height / 2);
        for (int a = 0; a < obsinspace.Count; a++)
        {
            var shapeA = obsinspace[a];
            if (shapeA.anObstacle.xmax > xmin && shapeA.anObstacle.xmin < xmax && shapeA.anObstacle.ymax > ymin && shapeA.anObstacle.ymin < ymax)
            {
                return true;
            }
        }
        return false;
    }
}

[System.Serializable]
public class AObstacle
{
    public Vector3 position;
    public float xmax = 1f;
    public float xmin = 1f;
    public float ymax = 1f;
    public float ymin = 1f;
    public float width = 1f;
    public float height = 1f;
}