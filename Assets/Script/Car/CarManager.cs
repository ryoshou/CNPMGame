using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [System.Serializable]
    public class depot
    {
        public int id;
        public Sprite prefap;
        public float Smooth = 8.0f;
        public float MaxSmooth = 12.0f;
        public float Speed = 4.0f;
        public float MaxSpeed = 8.0f;
        public float AccelerationTimeSpeed = 1.5f;
        public float AccelerationTimeSmooth = 1.0f;
        public bool isBuy = false,isSelect = false;
        public string NameCar;
        public float Cost = 50;
        public int RatingSpeed, RatingSmooth;
    }
    #region
    public static CarManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public List<depot> Depots;
    // Start is called before the first frame update
    void Start()
    {
        foreach (depot car in Depots)
        {
            int isbuy = -1;
            int isSelect = -1;
            if (car == Depots[0])
            {
                isbuy = PlayerPrefs.GetInt(car.id + "_ISBUY", 1);
                isSelect = PlayerPrefs.GetInt(car.id + "_ISSelect", 1);
            }
            else
            {
                isbuy = PlayerPrefs.GetInt(car.id + "_ISBUY", 0);
                isSelect = PlayerPrefs.GetInt(car.id + "_ISSelect", 0);
            }
            //buy
            if(isbuy == 1)
            {
                car.isBuy = true;
            }    
            else
            {
                car.isBuy = false;
            }  
            //select
            if (isSelect == 1)
            {
                car.isSelect = true;
            }
            else
            {
                car.isSelect = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setselected(depot mycar)
    {
        foreach(depot car in Depots)
        {
            if(car == mycar)
            {
                car.isSelect = true;
                PlayerPrefs.SetInt(car.id + "_ISSelect", 1);
            } 
            else
            {
                car.isSelect = false;
                PlayerPrefs.SetInt(car.id + "_ISSelect", 0);
            }    
        }    
    }
    public void Buycar(depot mycar)
    {
        foreach (depot car in Depots)
        {
            if (car == mycar)
            {
                car.isBuy = true;
                PlayerPrefs.SetInt(car.id+"_ISBUY", 1);
            }

        }
    }
}
