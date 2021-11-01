using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATMainPhysics : MonoBehaviour
{
    public static SATMainPhysics instance;

    public List<SATPhysObj> SATobjinspace = new List<SATPhysObj>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class SATObj
{
    public Vector3 position;
    public Vector3 Velocity;
    public float Drag;
    public Vector2[] Vertices;
    public float width;
    public float height;
    
}
