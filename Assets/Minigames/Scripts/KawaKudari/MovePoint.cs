using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    private MovePoint1 movepoint1;
    private MovePoint2 movepoint2;
    private MovePoint3 movepoint3;

    private int mousepoint1;
    private int mousepoint2;
    private int mousepoint3;

    private int click_judge1;
    private int click_judge2;
    private int click_judge3;
    // Start is called before the first frame update
    void Start()
    {
        this.movepoint1 = FindObjectOfType<MovePoint1>();
        this.movepoint2 = FindObjectOfType<MovePoint2>();
        this.movepoint3 = FindObjectOfType<MovePoint3>();

        click_judge1 = 1;
        click_judge2 = 0;
        click_judge3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MousePoint();
        ClickJudge();
    }

    public void MousePoint(){
        mousepoint1 = movepoint1.GetClickJudge1;
        mousepoint2 = movepoint2.GetClickJudge2;
        mousepoint3 = movepoint3.GetClickJudge3;
    }

    public void ClickJudge(){
        if (Input.GetMouseButton(0) && mousepoint1 == 1)
        {
            click_judge1 = 1;
            click_judge2 = 0;
            click_judge3 = 0;
        }
        else if (Input.GetMouseButton(0) && mousepoint2 == 1)
        {
            click_judge1 = 0;
            click_judge2 = 1;
            click_judge3 = 0;
        }
        else if (Input.GetMouseButton(0) && mousepoint3 == 1)
        {
            click_judge1 = 0;
            click_judge2 = 0;
            click_judge3 = 1;
        }
    }

    public int GetMovePoint1{
        get{return click_judge1;}
        set{click_judge1 = value;}
    }

    public int GetMovePoint2{
        get{return click_judge2;}
        set{click_judge2 = value;}
    }

    public int GetMovePoint3{
        get{return click_judge3;}
        set{click_judge3 = value;}
    }
}
