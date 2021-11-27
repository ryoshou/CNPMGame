using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControll : MonoBehaviour
{
    public float Smooth = 8.0f;
    public float MaxSmooth = 12.0f;
    public float CurrentSmooth = 0.0f;
    public float Speed = 4.0f;
    public float MaxSpeed = 8.0f;
    public float AccelerationTimeSpeed = 1.5f;
    public float AccelerationTimeSmooth = 1.0f;
    float CurrentTime = 0.0f;
    float TotalTimeSpeed = 0.0f;
    float TotalTimeSmooth = 0.0f;
    public float CurrentSpeed = 0.0f;
    float MindSpeed = 0.0f;
    bool click = false;
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
            UpdateCurrentTime();
            click = true;
            MindSpeed = CurrentSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            CalculateSmooth();
            transform.Rotate(0, 0, CurrentSmooth * 0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            CalculateSmooth();
            transform.Rotate(0, 0, -CurrentSmooth * 0.1f);
        }
        if (Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.A))
        {
            UpdateCurrentTime();
            click = false;
            MindSpeed = CurrentSpeed;
        }

        TotalTimeSpeed = Time.time - CurrentTime;
        if (TotalTimeSpeed > AccelerationTimeSpeed)
            TotalTimeSpeed = AccelerationTimeSpeed;

        if (click == false)
        {
            CurrentSpeed = MindSpeed + (MaxSpeed - Speed) * (TotalTimeSpeed / AccelerationTimeSpeed);
            if (CurrentSpeed > MaxSpeed)
                CurrentSpeed = MaxSpeed;
        }
        else
        {
            CurrentSpeed = MindSpeed - ((MaxSpeed - Speed) * (TotalTimeSpeed / AccelerationTimeSpeed));
            if (CurrentSpeed < Speed)
                CurrentSpeed = Speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * CurrentSpeed * Time.deltaTime);
        }
    }
    void UpdateCurrentTime()
    {
        CurrentTime = Time.time;
    }
    void CalculateSmooth()
    {
        TotalTimeSmooth = Time.time - CurrentTime;
        if (TotalTimeSmooth > AccelerationTimeSmooth)
            TotalTimeSmooth = AccelerationTimeSmooth;
        CurrentSmooth = Smooth + (MaxSmooth - Smooth) * (TotalTimeSmooth / AccelerationTimeSmooth);
    }
}
