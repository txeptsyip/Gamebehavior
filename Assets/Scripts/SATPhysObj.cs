using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATPhysObj : MonoBehaviour
{
    public SATObj satobj;
    public bool isrect; // check this if shape is rect, to add thing to calculate corners when true
    // Start is called before the first frame update
    public Vector2[] vertices = { new Vector2(0,0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) };
    void Start()
    {
        Debug.Log("start started");
        SATMainPhysics.instance.SATobjinspace.Add(this);
        if (isrect)
        {
            satobj.width = transform.localScale.x;
            satobj.height = transform.localScale.y;
            vertices[0] = (new Vector2(-satobj.width * 0.5f, satobj.height * 0.5f));
            vertices[1] = (new Vector2(-satobj.width * 0.5f, satobj.height * 0.5f));
            vertices[2] = (new Vector2(-satobj.width * 0.5f, satobj.height * 0.5f));
            vertices[3] = (new Vector2(-satobj.width * 0.5f, satobj.height * 0.5f));

            satobj.Vertices = vertices;
        }
    }

    // Update is called once per frame
    void Update()
    {
        getNormal();
    }

    void getNormal()
    {
        for (int a = 0; a < satobj.Vertices.Length; a++)
        {

        }
    }
}

