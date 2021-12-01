using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Canvas : MonoBehaviour
{
    public GameObject Player;
    public float MaxSpeed = 15.0f;
    public Slider SliderSpeed;
    public Text TxtSpeed;
    public Text Score;
    public GameObject BtnPlayGame;
    // Start is called before the first frame update
    void Start()
    {
        SliderSpeed.maxValue = MaxSpeed;
        BtnPlayGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            TxtSpeed.text = (int)(Player.GetComponent<UserControll>().CurrentSpeed*10) + "KM/H";
            SliderSpeed.value = Player.GetComponent<UserControll>().CurrentSpeed;
            Score.text = (int)Time.time+"";
        }
        if(Player==null&& BtnPlayGame.active == false)
        {
            Debug.Log("aaa");
            BtnPlayGame.SetActive(true);
        }
    }
    public void Playgame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TIN");
    }
}
