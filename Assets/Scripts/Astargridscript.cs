using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astargridscript : MonoBehaviour
{
    public LayerMask anObstacle;
    public Vector3 gridsizeworld;
    public float nodesize;
    Node[,] grid;

    float nodediameter;
    float gridsizex;
    float gridsizey;

    private void Start()
    {
        nodediameter = nodesize * 2;
        gridsizex = gridsizeworld.x / nodediameter;
        gridsizey = gridsizeworld.y / nodediameter;

        CreateGrid();

    }

    void CreateGrid()
    {
        grid = new Node[Mathf.RoundToInt(gridsizex), Mathf.RoundToInt(gridsizey)];
        Vector3 bottomleft = transform.position - Vector3.right * gridsizeworld.x / 2 - Vector3.up * gridsizeworld.y / 2;

        for (int x=0; x < gridsizex; x++)
        {
            for (int y = 0; y < gridsizex; y++)
            {
                Vector3 worldpoint = bottomleft + Vector3.right * (x * nodediameter + nodesize) + Vector3.up * (y * nodediameter + nodesize);
                bool noobstacle = !(Obstacle.checkobstacle(nodesize, worldpoint));
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridsizeworld.x, gridsizeworld.y, 1));
    }
}
