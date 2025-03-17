using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJudgeKawaK : MonoBehaviour
{
    private int gameclear;

    private float gametime;
    private float fintime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        gametime = 0;
        gameclear = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GameTimeJudge();
    }

    public void GameTimeJudge(){
        if (gametime >= fintime){
            gameclear = 1;
        }
    }

    public int GetGameClear{
        get{return gameclear;}
        set{gameclear = value;}
    }
}
