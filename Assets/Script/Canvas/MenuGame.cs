using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGame : MonoBehaviour
{
    public GameObject MenuSetting;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openSetting()
    {
        MenuSetting.SetActive(!MenuSetting.active);
    }
}
