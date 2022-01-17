using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerscript : MonoBehaviour
{
    public GameObject UiText;
    // not used because... reasons i guess? i just shoehorned some health into the scripts i use for damage physics collisions like a right nutter
    public float speed = 30f;
    public Camera camera;
    Rect screenBounds;
    float objectWidth, objectHeight;
    public float cameraSpeed = 0f;
    public Text healthText;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        float cameraHeight = camera.orthographicSize * 2;
        float cameraWidth = cameraHeight * camera.aspect;
        Vector2 cameraSize = new Vector2(cameraWidth, cameraHeight);
        Vector2 cameraCentreInWorld = camera.transform.position;
        Vector2 bottomLeft = cameraCentreInWorld - (cameraSize / 2);
        screenBounds = new Rect(bottomLeft, cameraSize);
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        // would have been really useful a few months ago it is getting the size of the sprite based on the PIXELS - could still be used might need changes to code but NO TIME
        Debug.Log(objectHeight);
        Debug.Log(objectWidth);

    }

    // Update is called once per frame
    void Update()
    {
           
        health = gameObject.GetComponent<Damageobj>().damageObj.Health;
        healthText.text = health.ToString();
        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = pos;
        screenBounds.position = (Vector2)camera.transform.position - (screenBounds.size / 2);
        if (camera.transform.position.y < 68)
        {
            camera.transform.position += new Vector3(0, 1 * cameraSpeed * Time.deltaTime, 0);
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
