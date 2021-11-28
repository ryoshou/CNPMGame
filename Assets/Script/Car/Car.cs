using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Smooth = 8.0f;
    public float MaxSmooth = 12.0f;
    public float Speed = 4.0f;
    public float MaxSpeed = 8.0f;
    public float AccelerationTimeSpeed = 1.5f;
    public float AccelerationTimeSmooth = 1.0f;
    public float CurrentSmooth = 0.0f;
    public float CurrentSpeed = 0.0f;
    float CurrentTime = 0.0f;
    float TotalTimeSpeed = 0.0f;
    float TotalTimeSmooth = 0.0f;
    protected float MindSpeed = 0.0f;
    protected float MindSmood = 0.0f;
    public bool click = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void CalculateSmooth()
    {
        TotalTimeSmooth = Time.time - CurrentTime;
        if (TotalTimeSmooth > AccelerationTimeSmooth)
            TotalTimeSmooth = AccelerationTimeSmooth;
        CurrentSmooth = MindSmood + (MaxSmooth - Smooth) * (TotalTimeSmooth / AccelerationTimeSmooth);
        if (CurrentSmooth > MaxSmooth)
            CurrentSmooth = MaxSmooth;
    }
    protected void StartDrift()
    {
        TotalTimeSmooth = Time.time - CurrentTime;
        if (TotalTimeSmooth > AccelerationTimeSmooth)
            TotalTimeSmooth = AccelerationTimeSmooth;
        CurrentSmooth = Smooth + (MaxSmooth - Smooth) * (TotalTimeSmooth / AccelerationTimeSmooth);
        MindSmood = CurrentSmooth;
        UpdateCurrentTime();
        MindSpeed = CurrentSpeed;
    }
    protected void DriftLeft()
    {
        CalculateSmooth();
        transform.Rotate(0, 0, CurrentSmooth * 0.1f);
    }
    protected void DriftRight()
    {
        CalculateSmooth();
        transform.Rotate(0, 0, -CurrentSmooth * 0.1f);
    }
    protected void SetTotalTime()
    {
        TotalTimeSpeed = Time.time - CurrentTime;
        if (TotalTimeSpeed > AccelerationTimeSpeed)
            TotalTimeSpeed = AccelerationTimeSpeed;
    }
    protected void acceleration()
    {
        SetTotalTime();
        CurrentSpeed = MindSpeed + (MaxSpeed - Speed) * (TotalTimeSpeed / AccelerationTimeSpeed);
        if (CurrentSpeed > MaxSpeed)
            CurrentSpeed = MaxSpeed;
    }
    protected void deceleration()
    {
        SetTotalTime();
        CurrentSpeed = MindSpeed - ((MaxSpeed - Speed) * (TotalTimeSpeed / AccelerationTimeSpeed));
        if (CurrentSpeed < Speed)
            CurrentSpeed = Speed;
    }
    protected void GoUp()
    {
        transform.Translate(Vector2.up * CurrentSpeed * Time.deltaTime);
    }
    protected void UpdateCurrentTime()
    {
        CurrentTime = Time.time;
    }
}
