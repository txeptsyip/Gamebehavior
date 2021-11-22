using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SATMainPhysics : MonoBehaviour
{
    public static SATMainPhysics instance;
    // OH GOD WHY IS EVERYTHING PUBLIC JESUS CHRIST!
    public List<SATPhysObj> SATobjinspace = new List<SATPhysObj>();
    public List<Vector3> tempnormals = new List<Vector3>();
    public List<float> dotproducts = new List<float>();
    public float aMin = 5000;
    public float aMax = 5001;
    public float bMin = 6000;
    public float bMax = 6001;

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
        for (int a = 0; a < SATobjinspace.Count; a++)
        {
            for (int b = 0; b < SATobjinspace.Count; b++)
            {
                if (a != b)
                {
                    tempnormals.Clear();
                    tempnormals.AddRange(SATobjinspace[a].normals);
                    tempnormals.AddRange(SATobjinspace[b].normals);

                    for (int c = 0; c < tempnormals.Count; c++)
                    {

                        for (int d = 0; d < SATobjinspace[a].wVertices.Count; d++)
                        {
                            dotproducts.Add(Vector3.Dot(tempnormals[c], SATobjinspace[a].wVertices[d]));
                        }
                        aMin = dotproducts.Min();
                        aMax = dotproducts.Max();
                        dotproducts.Clear();
                        for (int d = 0; d < SATobjinspace[b].wVertices.Count; d++)
                        {
                            dotproducts.Add(Vector3.Dot(tempnormals[c], SATobjinspace[b].wVertices[d]));
                        }
                        bMin = dotproducts.Min();
                        bMax = dotproducts.Max();
                        dotproducts.Clear();
                        if (((aMax > bMin) && (aMax < bMax)) || ((aMin > bMin) && (aMin < bMax)))
                        {
                            if (tempnormals[c] == tempnormals.Last())
                            {
                                Debug.Log("colliding!");
                            }
                        }
                        else
                        {
                            Debug.Log("not colliding");
                            break;
                        }
                    }
                }
            }
        }

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
