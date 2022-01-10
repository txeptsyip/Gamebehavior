using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(101)]
public class Unit : MonoBehaviour
{
    private float health;
    public Transform target;
    public float speed = 5;
    private float rotationSpeed;
    Vector3[] path;
    int targetIndex;
    bool ignoreblockers = false;

    public float Health { get => health; set => health = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }

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
                    targetIndex = 0;
                    path = new Vector3[0];
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed* Time.deltaTime);
            yield return null;
        }
    }
}
