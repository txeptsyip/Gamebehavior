using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATPhysObj : MonoBehaviour
{
    public SATObj satobj;
    public bool isrect; // check this if shape is rect, to add thing to calculate corners when true
                        // Start is called before the first frame update
    public List<Vector3> vertices = new List<Vector3>();
    public List<Vector3> normals = new List<Vector3>();
    public List<Vector3> wVertices = new List<Vector3>();
    void Start()
    {
        Debug.Log("start started");
        SATMainPhysics.instance.SATobjinspace.Add(this);
        satobj = new SATObj();
        if (isrect)
        {
            satobj.width = transform.localScale.x;
            satobj.height = transform.localScale.y;
            vertices.Add(new Vector3(-satobj.width * 0.5f, satobj.height * 0.5f));
            vertices.Add(new Vector3(satobj.width * 0.5f, satobj.height * 0.5f));
            vertices.Add(new Vector3(satobj.width * 0.5f, -satobj.height * 0.5f));
            vertices.Add(new Vector3(-satobj.width * 0.5f, -satobj.height * 0.5f));
            

        }
        wVertices.AddRange(vertices);
    }



    // Update is called once per frame
    void Update()
    {
        for (int b = 0; b < vertices.Count; b++)
        {
            wVertices[b] = vertices[b] + transform.position;
        }    
        normals.Clear();
        for (int a = 0; a < vertices.Count; a++)
        {
            normals.Add(wVertices[(a + 1) % wVertices.Count] - wVertices[a]);
            normals[a] = new Vector3(normals[a].x * -1, normals[a].y);
            normals[a] = normals[a].normalized;
        }
    }

    void OnDestroy()
    {
        SATMainPhysics.instance.SATobjinspace.Remove(this);
    }
}

