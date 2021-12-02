using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelTap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject Menu;
    public GameObject MenuSetting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (MenuSetting.active == false) 
        PlayGame();
    }
    public void PlayGame()
    {
        MenuSetting.SetActive(false);
        Menu.SetActive(false);
        GameObject Canvas = GameObject.FindGameObjectWithTag("CanVas");
        Canvas.GetComponent<Canvas>().Playgame();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }
}
