using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATPhysObj : MonoBehaviour
{
    public SATObj satobj;
    // Start is called before the first frame update
    public Vector2[] vertices;
    void Start()
    {
        SATMainPhysics.instance.SATobjinspace.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

