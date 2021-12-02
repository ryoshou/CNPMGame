using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class u_instruction : MonoBehaviour
{
    public float TimeOut = 2.5f;
    protected GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Player.transform.position;
    }
    public void start()
    {
        StartCoroutine(End(TimeOut));
    }
    private IEnumerator End(float second)
    {
        yield return new WaitForSeconds(second);
        this.gameObject.SetActive(false);
    }
}
