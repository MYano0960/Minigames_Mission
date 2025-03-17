using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJudgeTokusanMono : MonoBehaviour
{
    private int gamefail;
    private int destory_gamefail;
    private int success_num;
    private int success_sum;
    private int judge_num;
    private int destroy_judge_num;

    private int gameoversuccess;
    private int gameoverfail;

    private float gametime;
    private float result_Time;

    public ItemGenerate itemgenerate;
    public ItemJudgePoint itemjudge;
    public DestroyPointTokusanMono destroypoint;
    [SerializeField]private List<GameObject> Result;
    // Start is called before the first frame update
    void Start()
    {
        gameoversuccess = 0;
        gameoverfail = 0;
        for (int i=0;i<Result.Count;i++){
            Result[i].SetActive(false);
        }

        GameObject.Find("Item").GetComponent<ItemGenerate>().enabled = true;
        GameObject.Find("Button").GetComponent<ButtonPush>().enabled = true;
        GameObject.Find("MovePoint").GetComponent<MovePointTokusanM>().enabled = true;
        GameObject.Find("ItemJudgePoint").GetComponent<ItemJudgePoint>().enabled = true;
        GameObject.Find("DestroyPoint").GetComponent<DestroyPointTokusanMono>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GetBoolSet();
        GameOverFail();
        GameOverClear();
        GameOverProcess();
    }

    public void GetBoolSet(){
        gamefail = itemjudge.GetGameFail;
        destory_gamefail = destroypoint.GetDestroyGameFail;
        success_num = itemjudge.GetSuccessNum;
        success_sum = itemgenerate.GetSuccessSum;
        judge_num = itemjudge.GetJudgeNum;
        destroy_judge_num = destroypoint.GetDestroyJudgeNum;
    }

    public void GameOverFail(){
        if (gamefail == 1 || destory_gamefail == 1){
            if (result_Time == 0){
                result_Time = gametime;
            }

            gameoverfail = 1;

            if (gametime >= result_Time + 1.0f){
                Result[1].SetActive(true);
            }
        }
    }

    public void GameOverClear(){
        if (judge_num + destroy_judge_num == 3){
            if (success_num == success_sum){
                if (result_Time == 0){
                    result_Time = gametime;
                }

                gameoversuccess = 1;

                if (gametime >= result_Time + 1.0f){
                    Result[0].SetActive(true);
                }
            }
        }
    }

    public void GameOverProcess(){
        if (gameoverfail == 1 || gameoversuccess == 1){
            GameObject.Find("Item").GetComponent<ItemGenerate>().enabled = false;
            GameObject.Find("Button").GetComponent<ButtonPush>().enabled = false;
            GameObject.Find("MovePoint").GetComponent<MovePointTokusanM>().enabled = false;
            GameObject.Find("ItemJudgePoint").GetComponent<ItemJudgePoint>().enabled = false;
            GameObject.Find("DestroyPoint").GetComponent<DestroyPointTokusanMono>().enabled = false;
        }
    }
}
