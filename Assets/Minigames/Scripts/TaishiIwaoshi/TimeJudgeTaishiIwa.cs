using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJudgeTaishiIwa : MonoBehaviour
{
    private int gamefail_timeover;

    private float gametime;
    private float fintime = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        gametime = 0;
        gamefail_timeover = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GameTimeJudge();
    }

    public void GameTimeJudge(){
        if (gametime >= fintime){
            gamefail_timeover = 1;
        }
    }

    public int GetGameFailTimeOver{
        get{return gamefail_timeover;}
        set{gamefail_timeover = value;}
    }
}
