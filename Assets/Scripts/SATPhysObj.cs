using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATPhysObj : MonoBehaviour
{
    public SATObj satobj;
    public bool isrect; // check this if shape is rect, to add thing to calculate corners when true
                        // Start is called before the first frame update


    public List<Vector3> wVertices = new List<Vector3>();
    public List<float> dotproducts = new List<float>();

    void Start()
    {
        SATMainPhysics.instance.SATobjinspace.Add(this);
        if (isrect)
        {
            satobj.width = transform.localScale.x;
            satobj.height = transform.localScale.y;
            satobj.vertices.Add(new Vector3(-satobj.width * 0.5f, satobj.height * 0.5f));
            satobj.vertices.Add(new Vector3(satobj.width * 0.5f, satobj.height * 0.5f));
            satobj.vertices.Add(new Vector3(satobj.width * 0.5f, -satobj.height * 0.5f));
            satobj.vertices.Add(new Vector3(-satobj.width * 0.5f, -satobj.height * 0.5f));
        }
        wVertices.AddRange(satobj.vertices);
    }



    // Update is called once per frame
    void Update()
    {
        for (int b = 0; b < satobj.vertices.Count; b++)
        {
            wVertices[b] = satobj.vertices[b] + transform.position;
        }    
        satobj.normals.Clear();
        for (int a = 0; a < satobj.vertices.Count; a++)
        {
            satobj.normals.Add(wVertices[(a + 1) % wVertices.Count] - wVertices[a]);
            satobj.normals[a] = new Vector3(satobj.normals[a].y * -1, satobj.normals[a].x);
            satobj.normals[a] = satobj.normals[a].normalized;
        }
        dotproducts.Clear();
        for (int a=0; a < satobj.normals.Count; a++)
        {
            for (int b = 0; b < wVertices.Count; b ++)
            {
                dotproducts.Add(Vector3.Dot(satobj.normals[a], wVertices[b]));
            }

        }
        transform.position = new Vector3(transform.position.x + (satobj.Velocity.x * Time.fixedDeltaTime), transform.position.y + (satobj.Velocity.y * Time.fixedDeltaTime), 0);


        satobj.Velocity.x = (1 - (satobj.Drag * Time.fixedDeltaTime)) * satobj.Velocity.x;
        satobj.Velocity.y = (1 - (satobj.Drag * Time.fixedDeltaTime)) * satobj.Velocity.y;
        if ((Mathf.Abs(satobj.Velocity.x) < 0.0001) && (Mathf.Abs(satobj.Velocity.y) < 0.0001))
        {
            satobj.Velocity.x = 0;
            satobj.Velocity.y = 0;
        }
    }

    void OnDestroy()
    {
        SATMainPhysics.instance.SATobjinspace.Remove(this);
    }
}

