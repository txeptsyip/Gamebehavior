using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Path : MonoBehaviour
{

    Queue<RequestPath> queueofpaths = new Queue<RequestPath>();
    RequestPath currentRequestPath;
    pathfinder Pathfinding;
    bool processingpath;

    static Path instance;
    public static void PathRequest(Vector3 start, Vector3 end, Action<Vector3[], bool> callback)
    {
        RequestPath newpath = new RequestPath(start, end, callback);
        instance.queueofpaths.Enqueue(newpath);
        instance.TryProcessNext();
    }

    private void Awake()
    {
        instance = this;
        Pathfinding = GetComponent<pathfinder>();
    }

    void TryProcessNext()
    {
        if (!processingpath && queueofpaths.Count > 0)
        {
            currentRequestPath = queueofpaths.Dequeue();
            processingpath = true;
            Pathfinding.StartFindPath(currentRequestPath.start, currentRequestPath.end);
        }
    }

    public void FinishedPath(Vector3[] path, bool success)
    {
        currentRequestPath.callback(path, success);
        processingpath = false;
        TryProcessNext();
    }

    struct RequestPath
    {
        public Vector3 start, end;
        public Action<Vector3[], bool> callback;

        public RequestPath(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback)
        {
            start = _start;
            end = _end;
            callback = _callback;
        }
    }
}
