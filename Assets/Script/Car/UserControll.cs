using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControll : Car
{
    public float TimeDie = 2.0f;
    // Start is called before the first frame update
    protected Vector2 Touched;
    protected Vector2 Mid;
    public bool IsDie = false;
    public AudioClip audiodie;
    void Start()
    {
        MindSpeed = Speed;
        IsDie = false;
        ChangeCar(PlayerPrefs.GetInt("CURRENTCAR", 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 || IsDie == true)
            return;
        //transform.Translate(Vector2.up * 5 * Time.deltaTime);
        if(Input.touchCount>0)
        {
            Touched =Input.GetTouch(0).position; 
            if(Touched.x >= Camera.main.pixelWidth/2)
            {
                DriftRight();
            }
            else
            {
                DriftLeft();
            }
            if(click==false)
            {
                StartDrift();
            }
            click = true;

        }
        else
        {
            if(click==true)
            {
                StartDrift();
            }
            click = false;
        }

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
        GoUp();
    }
    public void PlayerDie()
    {
        IsDie = true;
        this.GetComponent<AudioSource>().PlayOneShot(audiodie);
        this.gameObject.SetActive(false);
        GameObject Canvas = GameObject.FindGameObjectWithTag("CanVas");
        Canvas.GetComponent<Canvas>().startGameover(TimeDie);
    }
    public void ChangeCar(int IdCar)
    {
        this.GetComponent<SpriteRenderer>().sprite = CarManager.Instance.Depots[IdCar].prefap;
        MaxSpeed = CarManager.Instance.Depots[IdCar].MaxSpeed;
        MaxSmooth = CarManager.Instance.Depots[IdCar].MaxSmooth;
        Speed = CarManager.Instance.Depots[IdCar].Speed;
        Smooth = CarManager.Instance.Depots[IdCar].Smooth;
        AccelerationTimeSpeed = CarManager.Instance.Depots[IdCar].AccelerationTimeSpeed;
        AccelerationTimeSmooth = CarManager.Instance.Depots[IdCar].AccelerationTimeSmooth;
    }
}
