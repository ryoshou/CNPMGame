using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    protected Animator Anim;
    public float TimeExplode = 0.45f;
    // Start is called before the first frame update
    public void Hit()
    {
        Anim = this.GetComponent<Animator>();
        Anim.SetBool("Hit", true);
        StartCoroutine(Reset(TimeExplode));
    }

    private IEnumerator Reset(float second)
    {
        yield return new WaitForSeconds(second);
        Anim.SetBool("Hit", false);
        this.gameObject.SetActive(false);
    }
}
