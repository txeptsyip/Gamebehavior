using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    public List<GameObject> ships = new List<GameObject>();
    SpriteRenderer thing;
    public Transform rpoint;
    // Start is called before the first frame update
    void Start()
    {
        thing = transform.GetComponent<SpriteRenderer>();
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 8));
            Debug.Log("spawning?");
            int spawns = Random.Range(1, 5);
            int i = 0;
            while (i < spawns)
            {
                Vector3 rndPoint3D = RandomPointInBounds(thing.bounds, 1f);
                Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
                rpoint.position = rndPoint2D;
                int s = Random.Range(0,ships.Count);
                Instantiate(ships[s], rndPoint2D, rpoint.rotation);
                i++;
                Debug.Log("finished spawning");
                yield return null;
            }
        }
    }

 private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),(0f));
    }
}
