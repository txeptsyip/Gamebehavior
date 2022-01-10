using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Transform target;
    float speed = 5;
    Vector3[] path;
    int targetIndex;
    bool ignoreblockers = false;


    private void Start()
    {
        Path.PathRequest(transform.position, target.position, onpathfound);
    }

    public void onpathfound (Vector3[] newpath, bool pathsuccess)
    {
        if (pathsuccess)
        {
            path = newpath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");

        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        while(true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed* Time.deltaTime);
            yield return null;
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i > path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], new Vector3(1,1,0));

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else Gizmos.DrawLine(path[i - 1], path[i]);
            }
        }
    }
}
