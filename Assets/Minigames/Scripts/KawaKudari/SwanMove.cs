using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwanMove : MonoBehaviour
{
    private float MoveSpeed;
    private Vector2 thisObjPos;
    // Start is called before the first frame update
    void Start()
    {
        string thisObjName = this.gameObject.name;
        MoveSpeedJudge(thisObjName);
        thisObjPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisObjPos.x -= MoveSpeed;
        this.transform.position = thisObjPos;
    }

    private void MoveSpeedJudge(string thisObjName){
        if (thisObjName == "Swan1"){
            MoveSpeed = 25f;
        } else if (thisObjName == "Swan2"){
            MoveSpeed = 30f;
        } else if (thisObjName == "Swan3"){
            MoveSpeed = 40f;
        }
    }
}
