using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATPhysObj : MonoBehaviour
{
    public SATObj satobj;
    public bool isrect; // check this if shape is rect, to add thing to calculate corners when true
                        // Start is called before the first frame update
    public List<Vector2> vertices = new List<Vector2>();
    public List<Vector2> normals = new List<Vector2>();
    void Start()
    {
        Debug.Log("start started");
        SATMainPhysics.instance.SATobjinspace.Add(this);
        satobj = new SATObj();
        if (isrect)
        {
            satobj.width = transform.localScale.x;
            satobj.height = transform.localScale.y;
            vertices.Add(new Vector2(-satobj.width * 0.5f, satobj.height * 0.5f));
            vertices.Add(new Vector2(satobj.width * 0.5f, satobj.height * 0.5f));
            vertices.Add(new Vector2(satobj.width * 0.5f, -satobj.height * 0.5f));
            vertices.Add(new Vector2(-satobj.width * 0.5f, -satobj.height * 0.5f));
            

        }
        for (int a = 0; a < vertices.Count; a++)
        {
            normals.Add(vertices[(a + 1) % vertices.Count] - vertices[a]);
            normals[a] = new Vector2(normals[a].x * -1, normals[a].y);
            normals[a] = normals[a].normalized;
        }
    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        SATMainPhysics.instance.SATobjinspace.Remove(this);
    }
}

