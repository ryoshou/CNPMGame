using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public GameObject CarMain, CarLeft, CarRight,Popup,PopupSucces;
    public Slider SliderSpeed, SliderSmooth;
    public Text txtCost,MyCoin,Name, TxtRatingSpeed, TxtRatingTorqueSpeed,TxtSelect;
    public Button Select;
    protected int NumCar,CarNow,CurrentCoin;
    protected Color normarColor,SelectColor;
    protected GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        normarColor = Select.GetComponent<Button>().colors.highlightedColor;
        SelectColor = Select.GetComponent<Button>().colors.selectedColor;
        SliderSpeed.maxValue = 10;
        SliderSmooth.maxValue = 10;
        Player = GameObject.FindGameObjectWithTag("Player");
        //PlayerPrefs.SetInt("CURRENTCOIN", 800);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        NumCar = CarManager.Instance.Depots.Count;
        CarNow = PlayerPrefs.GetInt("CURRENTCAR", 0);
        MyCoin.text = PlayerPrefs.GetInt("CURRENTCOIN", 50) + "";
        CurrentCoin = PlayerPrefs.GetInt("CURRENTCOIN", 50);
        setProduct();
        
    }
    public void setProduct()
    {
        CarMain.GetComponent<Image>().sprite = CarManager.Instance.Depots[CarNow].prefap;
        if (CarNow > 0)
        {
            CarLeft.SetActive(true);
            CarLeft.GetComponent<Image>().sprite = CarManager.Instance.Depots[CarNow - 1].prefap;
        }
        else
        {
            CarLeft.SetActive(false);
        }
        if (CarNow < NumCar - 1)
        {
            CarRight.SetActive(true);
            CarRight.GetComponent<Image>().sprite = CarManager.Instance.Depots[CarNow + 1].prefap;
        }
        else
        {
            CarRight.SetActive(false);
        }
        if(CarManager.Instance.Depots[CarNow].isBuy==true)
        {
            TxtSelect.text = "Select";
            if(CarManager.Instance.Depots[CarNow].isSelect == true)
            {
                Select.GetComponent<Button>().Select();
                ColorBlock cb = Select.GetComponent<Button>().colors;
                cb.normalColor = SelectColor;
                Select.GetComponent<Button>().colors = cb;
            } 
            else
            {
                ColorBlock cb = Select.GetComponent<Button>().colors;
                cb.normalColor = normarColor;
                Select.GetComponent<Button>().colors = cb;
            }    
        }   
        else
        {
            TxtSelect.text = "Buy";
            ColorBlock cb = Select.GetComponent<Button>().colors;
            cb.normalColor = normarColor;
            Select.GetComponent<Button>().colors = cb;
        }
        txtCost.text = CarManager.Instance.Depots[CarNow].Cost+"";

        SliderSpeed.value = CarManager.Instance.Depots[CarNow].RatingSpeed;
        SliderSmooth.value = CarManager.Instance.Depots[CarNow].RatingSmooth;
        TxtRatingSpeed.text = CarManager.Instance.Depots[CarNow].RatingSpeed + "/10";
        TxtRatingTorqueSpeed.text = CarManager.Instance.Depots[CarNow].RatingSmooth + "/10";
        Name.text = CarManager.Instance.Depots[CarNow].NameCar;
    }
    public void Selected()
    {
        if(CarManager.Instance.Depots[CarNow].isBuy == false)
        {
            if(CurrentCoin>= CarManager.Instance.Depots[CarNow].Cost)
            {
                CarManager.Instance.Depots[CarNow].isBuy = true;
                PopupSucces.SetActive(true);
                setProduct();
                CurrentCoin -= (int)CarManager.Instance.Depots[CarNow].Cost;
                PlayerPrefs.SetInt("CURRENTCOIN", CurrentCoin);
                CarManager.Instance.Buycar(CarManager.Instance.Depots[CarNow]);
                MyCoin.text = CurrentCoin + "";
            }   
            else
            {
                Popup.SetActive(true);
            }    
        }   
        else
        {
            CarManager.Instance.Setselected(CarManager.Instance.Depots[CarNow]);
            PlayerPrefs.SetInt("CURRENTCAR", CarNow);
            ColorBlock cb = Select.GetComponent<Button>().colors;
            cb.normalColor = SelectColor;
            Select.GetComponent<Button>().colors = cb;
        }    
    }
    public void RightClick()
    {
        if (CarNow >= NumCar - 1)
            return;
        CarNow++;
        setProduct();
    }
    public void LectClick()
    {
        if (CarNow <=0)
            return;
        CarNow--;
        setProduct();
    }
}
