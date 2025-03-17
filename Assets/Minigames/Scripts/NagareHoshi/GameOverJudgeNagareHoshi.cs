using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJudgeNagareHoshi : MonoBehaviour
{
    private int gamefin;

    private int gameclear;
    private int gamefail;

    private int answer_push_sum;
    private int correct_sum;

    private float gametime;
    private float result_Time;

    public ButtonPushNagareHoshi buttonpush;
    public DestroyPointNagareHoshi destroypoint;
    public TimeJudgeNagareHoshi timejudge;
    [SerializeField]private List<GameObject> Result;
    // Start is called before the first frame update
    void Start()
    {
        InitialScriptActive();

        gameclear = 0;
        gamefail = 0;
        gametime = 0;
        result_Time = 0;
        for (int i=0;i<Result.Count;i++){
            Result[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gamefin = timejudge.GetGameFin;
        answer_push_sum = buttonpush.GetButtonPushSum;
        correct_sum = destroypoint.GetCorrectNum;
        gametime += Time.deltaTime;

        if (gamefin == 1){
            if (answer_push_sum >= correct_sum - 3 && answer_push_sum <= correct_sum + 2){
                gameclear = 1;
                if (result_Time == 0){
                    result_Time = gametime;
                }
            } else {
                gamefail = 1;
                if (result_Time == 0){
                    result_Time = gametime;
                }
            }
            GameOverScriptActive();
        }

        if (gametime >= result_Time + 1.0f){
            if (gameclear == 1){
                Result[0].SetActive(true);
            } else if (gamefail == 1){
                Result[1].SetActive(true);
            }
        }
    }

    public void InitialScriptActive(){
        GameObject.Find("Star1").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star2").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star3").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star4").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star5").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star6").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star7").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star8").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star9").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Star10").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Dum1").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Dum2").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Dum3").GetComponent<StarMove>().enabled = true;
        GameObject.Find("Button").GetComponent<ButtonPushNagareHoshi>().enabled = true;
        GameObject.Find("GeneratePoint").GetComponent<TimeJudgeNagareHoshi>().enabled = true;
        GameObject.Find("DestroyPoint").GetComponent<DestroyPointNagareHoshi>().enabled = true;
    }

    public void GameOverScriptActive(){
        GameObject.Find("Star1").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star2").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star3").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star4").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star5").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star6").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star7").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star8").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star9").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Star10").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Dum1").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Dum2").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Dum3").GetComponent<StarMove>().enabled = false;
        GameObject.Find("Button").GetComponent<ButtonPushNagareHoshi>().enabled = false;
        GameObject.Find("GeneratePoint").GetComponent<TimeJudgeNagareHoshi>().enabled = false;
        GameObject.Find("DestroyPoint").GetComponent<DestroyPointNagareHoshi>().enabled = false;
    }

    public int GetGameFail{
        get{return gamefail;}
        set{gamefail = value;}
    }

    public int GetGameClear{
        get{return gameclear;}
        set{gameclear = value;}
    }
}
