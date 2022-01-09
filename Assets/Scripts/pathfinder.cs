using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class pathfinder : MonoBehaviour
{
    Path requestmanager;

    Astargridscript grid;
    void awake()
    {
        requestmanager = gameObject.GetComponent<Path>();
        grid = gameObject.GetComponent<Astargridscript>();
    }

    private void Start()
    {
        grid = gameObject.GetComponent<Astargridscript>();
    }
    IEnumerator FindPath(Vector3 startpos, Vector3 targetpos)
    {

        Node startNode = grid.nodefromworld(startpos);
        Node targetNode = grid.nodefromworld(targetpos);

        List<Node> openSet = new List<Node>(grid.MaxSize);
        HashSet<Node> closedSet = new HashSet<Node>();
        //hashset used so duplicate nodes are automatically discounted as hashset removes duplicates (duplicate nodes do not appear to be able to happen but still)
        Vector3[] waypoints = new Vector3[0];
        bool pathsuccess = false;


        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].f < currentNode.f || openSet[i].f == currentNode.f && openSet[i].h < currentNode.h)
                {
                    currentNode = openSet[i];
                }
            }
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                pathsuccess = true;
                //RetracePath(startNode, targetNode);
                yield break;
            }

            foreach (Node nextnodes in grid.Getnextnodes(currentNode))
            {
                if (!nextnodes.hasobstacle || closedSet.Contains(nextnodes))
                {
                    continue;
                }
                int newMovementCostToNext = currentNode.g + GetDistance(currentNode, nextnodes);
                if (newMovementCostToNext < currentNode.g || !openSet.Contains(nextnodes))
                {
                    nextnodes.g = newMovementCostToNext;
                    nextnodes.h = GetDistance(nextnodes, targetNode);
                    nextnodes.parent = currentNode;

                    if (!openSet.Contains(nextnodes))
                    {
                        openSet.Add(nextnodes);
                    }
                }
            }
        }
        yield return null;
        if (pathsuccess)
        {
            waypoints = RetracePath(startNode, targetNode);
        }
        requestmanager.FinishedPath(waypoints, pathsuccess);
    }

    Vector3[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Vector3[] waypoints = simplepath(path);
        Array.Reverse(waypoints);
        return waypoints;
        //grid.path = path;
    }

    Vector3[] simplepath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 olddirection = Vector2.zero;

        for (int i = 1; i < path.Count; i ++)
        {
            Vector2 newdirection = new Vector2(path[i - 1].gridx - path[i].gridx, path[i - 1].gridy - path[i].gridy);
            if (newdirection != olddirection)
            {
                waypoints.Add(path[i].positioninworld);
            }
            olddirection = newdirection;
        }
        return waypoints.ToArray();
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridx - nodeB.gridx);
        int distY = Mathf.Abs(nodeA.gridy - nodeB.gridy);

        if (distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }
        else
        {
            return 14 * distX + 10 * (distY - distX);
        }
    }
    public void StartFindPath(Vector3 start, Vector3 end)
    {
        StartCoroutine(FindPath(start, end));
    }

}


// openset (the set of nodes to be checked)
// closeset (the set of nodes already checked)


// add start node to open

//loop
// current is node in open with lowest f
// remove current from open
// add current to closed
// if current is target path has been found so return
// foreach nextnode of the current node
// if nextnode has obstacle or is closed skip to next

// if new path to next is shorter or next is not in open
// set f to next
// set parent of next to current
// if next is not in open
// add next to open