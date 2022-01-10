using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    int i = 0;
    public int destructtime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sdtimer());
    }

    // Update is called once per frame
    public IEnumerator sdtimer()
    {
        while (true)
        {
            i++;
            yield return new WaitForSeconds(1);
            if (i >= destructtime)
            {
                Destroy(gameObject);
            }
        }
    }
}
