using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointTokusanMono : MonoBehaviour
{
    private int destory_gamefail;

    private int destroy_judge_num;
    // Start is called before the first frame update
    void Start()
    {
        destory_gamefail = 0;
        destroy_judge_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Success"){
            destory_gamefail = 1;
        }
        ++destroy_judge_num;
        Destroy(col.gameObject);
    }

    public int GetDestroyGameFail{
        get{return destory_gamefail;}
        set{destory_gamefail = value;}
    }

    public int GetDestroyJudgeNum{
        get{return destroy_judge_num;}
        set{destroy_judge_num = value;}
    }
}
