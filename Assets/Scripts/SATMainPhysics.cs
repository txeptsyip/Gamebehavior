using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATMainPhysics : MonoBehaviour
{
    public static SATMainPhysics instance;

    public List<SATPhysObj> SATobjinspace = new List<SATPhysObj>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
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
    public List<Vector3> vertices = new List<Vector3>();
    public float width;
    public float height;
    public List<Vector3> normals = new List<Vector3>();

}
