using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(101)]
public class Unit : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
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
}
