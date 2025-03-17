using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJudgePoint : MonoBehaviour
{
    private int success_num;
    private int gamefail;
    private int judge_num;

    // Start is called before the first frame update
    void Start()
    {
        success_num = 0;
        gamefail = 0;
        judge_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Success"){
            ++success_num;
        } else if (col.gameObject.tag == "Fail"){
            gamefail = 1;
        }
        ++judge_num;
        Destroy(col.gameObject);
    }

    public int GetJudgeNum{
        get{return judge_num;}
        set{judge_num = value;}
    }

    public int GetSuccessNum{
        get{return success_num;}
        set{success_num = value;}
    }

    public int GetGameFail{
        get{return gamefail;}
        set{gamefail = value;}
    }
}
