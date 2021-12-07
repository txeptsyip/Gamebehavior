using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SATMainPhysics : MonoBehaviour
{
    public static SATMainPhysics instance;
    // OH GOD WHY IS EVERYTHING PUBLIC JESUS CHRIST!
    public List<SATPhysObj> SATobjinspace = new List<SATPhysObj>();

    public List<float> dotproducts = new List<float>();
    float aMin = 5000;
    float aMax = 5001;
    float bMin = 6000;
    float bMax = 6001;
    Vector3 mousepos;

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
        if(Input.GetMouseButtonDown(0))
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 0;
            Debug.Log(mousepos);
            for (int a = 0; a < SATobjinspace.Count; a++)
            {
                if (SATobjinspace[a].satobj.ismmoveable == true)
                {
                    float dist = Vector3.Distance(mousepos, SATobjinspace[a].satobj.position);
                    Vector3 direction = (SATobjinspace[a].satobj.position - mousepos).normalized;
                    float force = (dist * 1.2f);
                    SATobjinspace[a].satobj.Velocity = direction;

                }
            }
        }

        for (int a = 0; a < SATobjinspace.Count; a++)
        {
            for (int b = 0; b < SATobjinspace.Count; b++)
            {
                if (a != b)
                {
                    bool collision = false;
                    List<Vector3> tempnormals = new List<Vector3>();
                    tempnormals.AddRange(SATobjinspace[a].satobj.normals);
                    tempnormals.AddRange(SATobjinspace[b].satobj.normals);

                    for (int c = 0; c < tempnormals.Count; c++)
                    {

                        for (int d = 0; d < SATobjinspace[a].satobj.wVertices.Count; d++)
                        {
                            dotproducts.Add(Vector3.Dot(tempnormals[c], SATobjinspace[a].satobj.wVertices[d]));
                        }
                        aMin = dotproducts.Min();
                        aMax = dotproducts.Max();
                        dotproducts.Clear();
                        for (int d = 0; d < SATobjinspace[b].satobj.wVertices.Count; d++)
                        {
                            dotproducts.Add(Vector3.Dot(tempnormals[c], SATobjinspace[b].satobj.wVertices[d]));
                        }
                        bMin = dotproducts.Min();
                        bMax = dotproducts.Max();
                        dotproducts.Clear();
                        if (((aMax > bMin) && (aMax < bMax)) || ((aMin > bMin) && (aMin < bMax)))
                        {
                            if (tempnormals[c] == tempnormals.Last())
                            {
                                collision = true;
                                Debug.Log("colliding");
                                docollision(a, b);
                            }
                        }
                        else
                        {
                            collision = false;
                            break;
                        }
                    }
                }
            }
        }

    }
    void docollision(int a , int b)
    {
        Vector3 relativeV = SATobjinspace[b].satobj.Velocity - SATobjinspace[a].satobj.Velocity;
        Vector3 cNormal = (SATobjinspace[b].satobj.position - SATobjinspace[b].satobj.position).normalized;
        float velANorm = Vector3.Dot(relativeV, cNormal);
        if (velANorm > 0) 
        { 
            Debug.Log("was already moving away");
            return;
        }
        float restitution = Mathf.Min(SATobjinspace[a].satobj.restitution, SATobjinspace[b].satobj.restitution);
        float IScale = -(1 - restitution) * velANorm;
        IScale /= (1 / SATobjinspace[a].satobj.mass) + (1 / SATobjinspace[b].satobj.mass);
        Vector3 impulseTotal = IScale * cNormal;
        SATobjinspace[a].satobj.Velocity = -(1 / SATobjinspace[a].satobj.mass * impulseTotal);
        SATobjinspace[b].satobj.Velocity = (1 / SATobjinspace[b].satobj.mass * impulseTotal);
        Debug.Log(" they should be moving away now");
        // figure out what normal needs to be used for the collision

    }
}




[System.Serializable]
public class SATObj
{
    public Vector3 position;
    public Vector3 Velocity;
    public float Drag;
    public List<Vector3> vertices = new List<Vector3>();
    public float width;
    public float height;
    public List<Vector3> normals = new List<Vector3>();
    public List<Vector3> wVertices = new List<Vector3>();
    public bool ismmoveable;
    public float restitution;
    public float mass;
}
