using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushTaishiIwa : MonoBehaviour
{
    [SerializeField] List<GameObject> Button;

    private bool mouse_point;

    private int mouse_push_judge;
    // Start is called before the first frame update
    void Start()
    {
        mouse_point = false;
        mouse_push_judge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonPushJudge();
    }

    public void ButtonPushJudge(){
        if (Input.GetMouseButton(0) && mouse_point){
            Button[0].gameObject.SetActive(false);
            Button[1].gameObject.SetActive(true);
            mouse_push_judge = 1;
        } else {
            Button[0].gameObject.SetActive(true);
            Button[1].gameObject.SetActive(false);
            mouse_push_judge = 0;
        }
    }

    private void OnMouseEnter(){
        mouse_point = true;
    }

    private void OnMouseExit(){
        mouse_point = false;
    }

    public int GetButtonPush{
        get{return mouse_push_judge;}
        set{mouse_push_judge = value;}
    }
}
