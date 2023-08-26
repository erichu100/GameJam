using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Camera screen;
    private float left;
    private float right;
    private float up;
    private float down;

    // Start is called before the first frame update
    void Start()
    {
        screen = Camera.main;

        int width = screen.pixelWidth;
        int height = screen.pixelHeight;
        Vector3 downLeft = new Vector3(0, 0, 0);
        Vector3 upRight = new Vector3(width, height, 0);
        downLeft = screen.ScreenToWorldPoint(downLeft) + new Vector3(0, 0, 10);
        upRight = screen.ScreenToWorldPoint(upRight) + new Vector3(0, 0, 10);
        left = downLeft.x;
        down = downLeft.y;
        right = upRight.x;
        up = upRight.y;
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 10;
        int xVelo = 0;
        int yVelo = 0;

        if (Input.GetKey(KeyCode.W) && transform.position.y < up) { yVelo += speed; }
        if (Input.GetKey(KeyCode.A) && transform.position.x > left) { xVelo -= speed; }
        if (Input.GetKey(KeyCode.S)  && transform.position.y > down) { yVelo -= speed; }
        if (Input.GetKey(KeyCode.D) && transform.position.x < right) { xVelo += speed; }
        transform.position += (new Vector3(xVelo, yVelo, 0)).normalized * Time.deltaTime * speed;
        Vector3 mouseCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 relativeCoord = new Vector2(mouseCoord.x - transform.position.x, mouseCoord.y - transform.position.y);
        transform.up = relativeCoord;
        //Debug.Log(mouseCoord.x);
        //Debug.Log(mouseCoord.y);
        //transform.Rotate = Input.mousePosition;
    }
}
