using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJudgeTaishiIwa : MonoBehaviour
{
    private int gamefail;
    private int gameclear;
    private int gamefail_timeover;

    private float gametime;
    private float result_Time;

    public TaishiMove taishimove;
    public TimeJudgeTaishiIwa timejudge;
    [SerializeField]private TimeUI timeUI;
    [SerializeField]private List<GameObject> Result;
    // Start is called before the first frame update
    void Start()
    {
        gametime = 0;
        result_Time = 0;
        InitialScriptActive();
        for (int i=0;i<Result.Count;i++){
            Result[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GetBoolSet();
        GameOverJudge();
    }

    public void InitialScriptActive(){
        GameObject.Find("Player").GetComponent<TaishiMove>().enabled = true;
        GameObject.Find("Player").GetComponent<TimeJudgeTaishiIwa>().enabled = true;
        GameObject.Find("Button").GetComponent<ButtonPushTaishiIwa>().enabled = true;
        timeUI.enabled = true;
    }

    public void GetBoolSet(){
        gamefail = taishimove.GetGameFail;
        gameclear = taishimove.GetGameClear;
        gamefail_timeover = timejudge.GetGameFailTimeOver;
    }

    public void GameOverJudge(){
        if (gamefail == 1 || gameclear == 1 || gamefail_timeover == 1){
            if (result_Time == 0){
                result_Time = gametime;
            }

            GameObject.Find("Player").GetComponent<TaishiMove>().enabled = false;
            GameObject.Find("Player").GetComponent<TimeJudgeTaishiIwa>().enabled = false;
            GameObject.Find("Button").GetComponent<ButtonPushTaishiIwa>().enabled = false;
            timeUI.enabled = false;

            if (gametime >= result_Time + 1.0f){
                if (gameclear == 1){
                    Result[0].SetActive(true);
                } else if (gamefail == 1 || gamefail_timeover == 1){
                    Result[1].SetActive(true);
                }
            }
        } else {
            GameObject.Find("Player").GetComponent<TaishiMove>().enabled = true;
            GameObject.Find("Player").GetComponent<TimeJudgeTaishiIwa>().enabled = true;
            GameObject.Find("Button").GetComponent<ButtonPushTaishiIwa>().enabled = true;
        }
    }
}
