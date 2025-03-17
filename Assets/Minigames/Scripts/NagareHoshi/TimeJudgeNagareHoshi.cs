using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJudgeNagareHoshi : MonoBehaviour
{
    private int gamefin;

    private float gametime;
    private float generate_fintime = 13.0f;
    private float fintime = 15.0f;

    [SerializeField]private TimeUI timeUI;
    // Start is called before the first frame update
    void Start()
    {
        gamefin = 0;
        gametime = 0;
        GameObject.Find("GeneratePoint").GetComponent<StarDustGenerate>().enabled = true;
        timeUI.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GameTimeJudge();
    }

    public void GameTimeJudge(){
        if (gametime >= fintime){
            gamefin = 1;
            timeUI.enabled = false;
        } else if (gametime < fintime && gametime >= generate_fintime){
            GameObject.Find("GeneratePoint").GetComponent<StarDustGenerate>().enabled = false;
        }
    }

    public int GetGameFin{
        get{return gamefin;}
        set{gamefin = value;}
    }
}
