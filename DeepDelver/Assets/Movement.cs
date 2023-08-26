using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 10;
        int xVelo = 0;
        int yVelo = 0;

        if (Input.GetKey(KeyCode.W)) { yVelo += speed; }
        if (Input.GetKey(KeyCode.A)) { xVelo -= speed; }
        if (Input.GetKey(KeyCode.S)) { yVelo -= speed; }
        if (Input.GetKey(KeyCode.D)) { xVelo += speed; }
        transform.position += (new Vector3(xVelo, yVelo, 0)).normalized * Time.deltaTime * speed;
        Vector3 mouseCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 relativeCoord = new Vector2(mouseCoord.x - transform.position.x, mouseCoord.y - transform.position.y);
        transform.up = relativeCoord;
        //Debug.Log(mouseCoord.x);
        //Debug.Log(mouseCoord.y);
        //transform.Rotate = Input.mousePosition;
    }
}
