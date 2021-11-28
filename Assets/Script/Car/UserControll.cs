using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControll : Car
{
    public bool click = false;
    // Start is called before the first frame update
    void Start()
    {
        MindSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.up * 5 * Time.deltaTime);
      
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            click = true;
            StartDrift();
        }
        if (Input.GetKey(KeyCode.A))
        {
            DriftLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            DriftRight();
        }
        if (Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.A))
        {
            click = false;
            StartDrift();
        }
        if (click == false)
        {
            acceleration();
        }
        else
        {
            deceleration();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            UpdateCurrentTime();
        }
        if (Input.GetKey(KeyCode.W))
        {
            GoUp();
        }
    }
   
}
