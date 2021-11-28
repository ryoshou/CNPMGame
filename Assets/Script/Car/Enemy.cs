using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Car
{
    protected GameObject Player;
    protected Vector2 Vec;
    float Corner = 0;
    bool GoLeft = false;
    bool GoRight = false;
    // Start is called before the first frame update
    void Start()
    {
        MindSpeed = Speed;
        Player = GameObject.FindGameObjectWithTag("Player");
        CurrentSpeed = Speed+(MaxSpeed-Speed)/3;
    }

    // Update is called once per frame
    void Update()
    {
        Vec = Player.transform.position - transform.position;
        Corner = Vector2.Angle(new Vector2(transform.up.x,transform.up.y), Vec);
        Quaternion Rotation = Quaternion.LookRotation(Vector3.forward, Vec);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, 250 * Time.deltaTime);
        GoUp();

    }
    void GoToRight()
    {
        GoRight = true;
        GoLeft = false;
    }
    void GoToLeft()
    {
        GoRight = false;
        GoLeft = true;
    }
}
