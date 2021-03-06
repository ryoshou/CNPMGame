using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer : MonoBehaviour
{
    public GameObject Player;
    public float LimitRight = 0.8f;
    public float LimitLeft = 0.2f;
    public float LimitUp = 0.8f;
    public float LimitDow = 0.2f;
    protected float Speed;
    bool Moved = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.active == false)
            return;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(Player.transform.position);
        if (screenPos.x>Camera.main.pixelWidth* LimitRight )
        {
            if(Player.transform.up.x > 0)
                Moved = true;
            else
                Moved = false;
        }
        if (screenPos.x < Camera.main.pixelWidth * LimitLeft)
        {
            if (Player.transform.up.x < 0)
                Moved = true;
            else
                Moved = false;
        }
        if (screenPos.y > Camera.main.pixelHeight * LimitUp)
        {
            if (Player.transform.up.y > 0)
                Moved = true;
            else
                Moved = false;
        }
        if (screenPos.y < Camera.main.pixelHeight * LimitDow)
        {
            if (Player.transform.up.y < 0)
                Moved = true;
            else
                Moved = false;
        }
        if ((screenPos.y < Camera.main.pixelHeight * LimitUp && screenPos.y > Camera.main.pixelHeight * LimitDow) && screenPos.x < Camera.main.pixelWidth * LimitRight && screenPos.x > Camera.main.pixelWidth * LimitLeft)
        {
            Moved = false;
        }
        if (Moved==true)
        {
            Speed = Player.GetComponent<Car>().CurrentSpeed;
            transform.Translate(Player.transform.up * Speed * Time.deltaTime);
        }
       
    }
    public void FightPlayer()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
