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
    public Text Gold;
    public GameObject BtnPlayGame;
    protected float CurrentTime = 0;
    protected int CurrentGold = 0;
    // Start is called before the first frame update
    void Start()
    {
        CurrentGold = 0;
        CurrentTime = Time.time;
        SliderSpeed.maxValue = MaxSpeed;
        BtnPlayGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.active==true)
        {
            TxtSpeed.text = (int)(Player.GetComponent<UserControll>().CurrentSpeed*10) + "KM/H";
            SliderSpeed.value = Player.GetComponent<UserControll>().CurrentSpeed;
            Score.text = (int)(Time.time-CurrentTime)+"";
        }
    }
    public void Playgame()
    {
        ResumeGame();
        UnityEngine.SceneManagement.SceneManager.LoadScene("TIN");
    }
    public void Again()
    {
        PauseGame();
        if (Player.active==false && BtnPlayGame.active == false)
        {
            BtnPlayGame.SetActive(true);
        }
    }
    public void AddGold()
    {
        Gold.text = ++CurrentGold + "";
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
