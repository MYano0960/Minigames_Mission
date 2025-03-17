using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingASong : MonoBehaviour
{
    Rigidbody2D rb;

    private bool mousepoint;

    private int singjudge;

    private GameObject button_on;
    private GameObject button_off;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        singjudge = 0;

        ButtonSet();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonClickJudge();
    }

    public void ButtonSet(){
        mousepoint = false;
        button_on = transform.Find("sing_b").gameObject;
        button_off = transform.Find("sing").gameObject;
        button_on.gameObject.SetActive(false);
        button_off.gameObject.SetActive(true);
    }

    public void ButtonClickJudge(){
        if (Input.GetMouseButton(0) && mousepoint){
            button_on.gameObject.SetActive(true);
            button_off.gameObject.SetActive(false);
            singjudge = 1;
        } else {
            button_on.gameObject.SetActive(false);
            button_off.gameObject.SetActive(true);
            singjudge = 0;
        }
    }

    private void OnMouseEnter(){
        mousepoint = true;
    }

    private void OnMouseExit(){
        mousepoint = false;
    }

    public int GetSingJudge{
        get{return singjudge;}
        set{singjudge = value;}
    }
}
