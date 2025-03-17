using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJudgeTenguIwa : MonoBehaviour
{
    private int rock_put1;
    private int rock_put2;

    private int time_restart;

    private bool rockput1_once;

    private float hold_time1 = 3.0f;
    private float hold_time2 = 3.0f;
    private float current_time;

    private RockPut rockput;
    // Start is called before the first frame update
    void Start()
    {
        rock_put1 = 0;
        rock_put2 = 0;
        rockput1_once = false;

        this.rockput = FindObjectOfType<RockPut>();
    }

    // Update is called once per frame
    void Update()
    {
        time_restart = rockput.GetTimeRestart;

        RockPutJudge();
        MemoryCurrentTime();
    }

    public void RockPutJudge(){
        if (rock_put1 == 0 && Time.time >= hold_time1 && !rockput1_once){
            rock_put1 = 1;
            rockput1_once = true;
        }
    }

    public void MemoryCurrentTime(){
        if (time_restart == 1){
            StartCoroutine(WaitTime());
        }
    }

    public int GetPutJudge1{
        get{return rock_put1;}
        set{rock_put1 = value;}
    }

    public int GetPutJudge2{
        get{return rock_put2;}
        set{rock_put2 = value;}
    }

    public int GetTimeRestart{
        get{return time_restart;}
        set{time_restart = value;}
    }

    private IEnumerator WaitTime(){
        yield return new WaitForSeconds(2.0f);
        time_restart = 0;
        rock_put1 = 0;
        yield return new WaitForSeconds(hold_time2);
        rock_put2 = 1;
        yield break;
    }
}
