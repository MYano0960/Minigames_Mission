using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJudgeMakiePaz : MonoBehaviour
{
    private int gamefail;

    private float gametime;
    private float fintime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        gamefail = 0;
        gametime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GameTimeJudge();
    }

    public void GameTimeJudge(){
        if (gametime >= fintime){
            gamefail = 1;
        }
    }

    public int GetGameFail{
        get{return gamefail;}
        set{gamefail = value;}
    }
}
