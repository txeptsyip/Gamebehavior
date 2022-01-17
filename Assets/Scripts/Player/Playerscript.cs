using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerscript : MonoBehaviour
{
    public GameObject UItext;
    // public float health = 100f;
    // not used because... reasons i guess? i just shoehorned some health into the scripts i use for damage physics collisions like a right nutter
    public float Speed = 30f;
    public Camera Camera;
    Rect screenBounds;
    float objectWidth, objectHeight;
    public float CameraSpeed = 0f;
    public Text Healthtext;
    float helth;

    // Start is called before the first frame update
    void Start()
    {
        float cameraHeight = Camera.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.aspect;
        Vector2 camerasize = new Vector2(cameraWidth, cameraHeight);
        Vector2 cameracentreinworld = Camera.transform.position;
        Vector2 bottomleft = cameracentreinworld - (camerasize / 2);
        screenBounds = new Rect(bottomleft, camerasize);
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        // would have been really useful a few months ago it is getting the size of the sprite based on the PIXELS - could still be used might need changes to code but NO TIME
        Debug.Log(objectHeight);
        Debug.Log(objectWidth);

    }

    // Update is called once per frame
    void Update()
    {
           
        helth = gameObject.GetComponent<Damageobj>().damageObj.Health;
        Healthtext.text = helth.ToString();
        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.position = pos;
        screenBounds.position = (Vector2)Camera.transform.position - (screenBounds.size / 2);
        if (Camera.transform.position.y < 68)
        {
            Camera.transform.position += new Vector3(0, 1 * CameraSpeed * Time.deltaTime, 0);
        }
    }
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x + screenBounds.width - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y + screenBounds.height - objectHeight);
        transform.position = viewPos;
    }
}
