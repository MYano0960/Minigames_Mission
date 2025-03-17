using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJudgeOmiyageE : MonoBehaviour
{
    private int gamefailjudge;
    private float gametime;
    private float fintime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        gametime = 0;
        gamefailjudge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GameTimeJudge();
    }

    public void GameTimeJudge(){
        if (gametime >= fintime){
            gamefailjudge = 1;
        }
    }

    public int GetGameFailJudge{
        get{return gamefailjudge;}
        set{gamefailjudge = value;}
    }
}
