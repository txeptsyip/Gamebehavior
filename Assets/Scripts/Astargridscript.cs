using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/playlist?list=PLFt_AvWsXl0cq5Umv3pMC9SPnKjfp9eGW unity 3D pathfinding tutorial series from 7 years ago
[DefaultExecutionOrder(100)]
public class Astargridscript : MonoBehaviour
{
    public Vector3 gridsizeworld;
    public float nodesize;
    Node[,] grid;



    float halfnode;
    int gridsizeX;
    int gridsizeY;

    private void Start()
    {
        halfnode = nodesize / 2;
        gridsizeX = Mathf.RoundToInt(gridsizeworld.x / nodesize);
        gridsizeY = Mathf.RoundToInt(gridsizeworld.y / nodesize);

        CreateGrid();

    }

    public Node nodefromworld(Vector3 PositioninWorld)
    {
        float Xpercent = (PositioninWorld.x + gridsizeworld.x / 2) / gridsizeworld.x;
        float Ypercent = (PositioninWorld.y + gridsizeworld.y / 2) / gridsizeworld.y;
        Ypercent = Mathf.Clamp01(Ypercent);
        Xpercent = Mathf.Clamp01(Xpercent);

        int x = Mathf.RoundToInt((gridsizeX - 1) * Xpercent);
        int y = Mathf.RoundToInt((gridsizeY - 1) * Ypercent);

        return grid[x, y];
    }

    public List<Node> Getnextnodes(Node node)
    {
        List<Node> nextnodes = new List<Node>();
        for (int x = -1; x <=1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x==0 && y == 0)
                {
                    continue;
                }
                int checkX = node.gridx + x;
                int checkY = node.gridy + y;

                if (checkX >= 0 && checkX < gridsizeX && checkY >= 0 && checkY < gridsizeY)
                {
                    nextnodes.Add(grid[checkX, checkY]);
                }
            }
        }
        return nextnodes;
    }

    void CreateGrid()
    {
        grid = new Node[gridsizeX, gridsizeY];
        Vector3 bottomleft = transform.position - Vector3.right * gridsizeworld.x / 2 - Vector3.up * gridsizeworld.y / 2;

        for (int x=0; x < gridsizeX; x++)
        {
            for (int y = 0; y < gridsizeY; y++)
            {
                Vector3 worldpoint = bottomleft + Vector3.right * (x * nodesize + halfnode) + Vector3.up * (y * nodesize + halfnode);
// current problem, only one obstacle item is coming up as being a blocker according to the gizmos after computer restart copying the one working blocker worked and making new ones also worked so
// evidently a unity issue of some form (didn't save correctly?)

                // problem solved, unity can end up changing the order in which multiple starts are called upon project save and re-load - changing to Awake() in obstacles fixed the issue
                bool noobstacle = !(Obstacle.instance.checkobstacle(halfnode, worldpoint));
                // uses AABB collision to set the blockers as i'm working with a square grid and this can be disguised by the use of multiple sprites
                // also AABB is really fast and the amount of grid squares are probably going to make anything more complicated a nightmare
                // could make this an update or something so I can have moving terrain but this is just a simple shmup  with the odd boat or something enemy that has to deal with the terrain
                grid[x, y] = new Node(noobstacle, worldpoint, x ,y);
            }
        }
    }
    public List<Node> path;
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(transform.position, new Vector3(gridsizeworld.x, gridsizeworld.y, 1));

    //    if (grid != null)
    //    {
    //        foreach (Node n in grid)
    //        {
    //            Gizmos.color = (n.hasobstacle) ? Color.white : Color.red;
    //            if (path != null)
    //            {
    //                if (path.Contains(n))
    //                {
    //                    Gizmos.color = Color.black;
    //                }
    //            }
    //            Gizmos.DrawCube(n.positioninworld, new Vector3(1, 1, 0) * (nodesize - .1f));
    //        }
    //    }
    //}
    public int MaxSize
    {
        get
        {
            return gridsizeX * gridsizeY;
        }
    }
}


