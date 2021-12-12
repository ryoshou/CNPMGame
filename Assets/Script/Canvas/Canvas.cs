using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Canvas : MonoBehaviour
{
    public GameObject Player;
    public GameObject PanelInGame;
    public float MaxSpeed = 15.0f;
    public Slider SliderSpeed;
    public Text TxtSpeed;
    public Text Score;
    public Text Gold,MyGold;
    public GameObject PanelGameover;
    public float TimeInstruire = 2.0f;
    public GameObject U_instruction;
    public GameObject PanelPauseGame;
    public GameObject btnPause, btnResume;
    protected float CurrentTime = 0;
    protected int CurrentGold = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        CurrentGold = 0;
        CurrentTime = Time.time;
        SliderSpeed.maxValue = MaxSpeed;
        PanelGameover.SetActive(false);
        MyGold.text = PlayerPrefs.GetInt("CURRENTCOIN", 50) + "";
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
        PanelInGame.SetActive(true);
        U_instruction.SetActive(true);
        U_instruction.GetComponent<u_instruction>().start();
    }
    private IEnumerator Gameover(float second)
    {
        yield return new WaitForSeconds(second);
        PauseGame();
        if (Player.active == false && PanelGameover.active == false)
        {
            PanelGameover.SetActive(true);
            int gold = PlayerPrefs.GetInt("CURRENTCOIN", 50) + CurrentGold;
            PlayerPrefs.SetInt("CURRENTCOIN", gold);
            MyGold.text = gold + "";
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
    public void BackHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TIN");
    }
    public void startGameover(float TimeDie)
    {
        StartCoroutine(Gameover(TimeDie));
    }
    public void GameAgain()
    {
        //Reset canvas
        Playgame();
        PanelGameover.SetActive(false);
        CurrentTime = Time.time;
        CurrentGold = 0;
        PanelPauseGame.SetActive(false);
        btnPause.SetActive(true);
        btnResume.SetActive(false);
        //Reset player
        Player.SetActive(true);
        Player.GetComponent<UserControll>().IsDie = false;
        //Reset Enemy
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject obj in Enemys)
        {
            obj.SetActive(false);
        }    
    }
}
