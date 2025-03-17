using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushNagareHoshi : MonoBehaviour
{
    [SerializeField] List<GameObject> Button;

    private bool mouse_point;
    private bool push_count_judge;

    private int answer_push_sum;
    // Start is called before the first frame update
    void Start()
    {
        mouse_point = false;
        push_count_judge = true;
        answer_push_sum = 0;
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
            if (push_count_judge){
                answer_push_sum += 1;
                push_count_judge = false;
            }
        } else {
            Button[0].gameObject.SetActive(true);
            Button[1].gameObject.SetActive(false);
            push_count_judge = true;
        }
    }

    private void OnMouseEnter(){
        mouse_point = true;
    }

    private void OnMouseExit(){
        mouse_point = false;
    }

    public int GetButtonPushSum{
        get{return answer_push_sum;}
        set{answer_push_sum = value;}
    }
}
