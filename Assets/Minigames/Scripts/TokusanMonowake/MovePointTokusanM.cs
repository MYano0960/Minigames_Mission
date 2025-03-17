using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointTokusanM : MonoBehaviour
{
    [SerializeField] List<GameObject> Move_point;

    private int mouse_push_judge;

    public ButtonPush buttonpush;
    // Start is called before the first frame update
    void Start()
    {
        Move_point[0].gameObject.SetActive(false);
        Move_point[1].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        mouse_push_judge = buttonpush.GetButtonPush;
        ButtonPushInteraction();
    }

    public void ButtonPushInteraction(){
        if (mouse_push_judge == 0){
            Move_point[0].gameObject.SetActive(false);
            Move_point[1].gameObject.SetActive(true);
        } else if (mouse_push_judge == 1){
            Move_point[0].gameObject.SetActive(true);
            Move_point[1].gameObject.SetActive(false);
        }
    }
}
