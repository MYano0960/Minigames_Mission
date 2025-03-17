using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 pos;

    Vector3 point1;
    Vector3 point2;
    Vector3 point3;

    private int click_judge1;
    private int click_judge2;
    private int click_judge3;

    private MovePoint movepoint;
    // Start is called before the first frame update
    void Start()
    {
        this.movepoint = FindObjectOfType<MovePoint>();
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerClickJudge();
        MovePoint();
        PlayerMoveJudge();
    }

    public void PlayerClickJudge(){
        click_judge1 = movepoint.GetMovePoint1;
        click_judge2 = movepoint.GetMovePoint2;
        click_judge3 = movepoint.GetMovePoint3;
    }

    public void MovePoint(){
        point1 = GameObject.Find("Point1").transform.position;
        point2 = GameObject.Find("Point2").transform.position;
        point3 = GameObject.Find("Point3").transform.position;
    }

    public void PlayerMoveJudge(){
        if(click_judge1 == 1)
        {
            pos = point1;
            this.transform.position = pos;
        }
        else if(click_judge2 == 1)
        {
            pos = point2;
            this.transform.position = pos;
        }
        else if(click_judge3 == 1)
        {
            pos = point3;
            this.transform.position = pos;
        }
    }
}
