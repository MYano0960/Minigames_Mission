using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJudgePicturePazu : MonoBehaviour
{
    private int gameclear;
    private int gamefail;

    private float gametime;
    private float result_Time;

    public PictureJudge picturejudge;
    public TimeJudgeMakiePaz timejudge;
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
        gameclear = picturejudge.GetGameClear;
        gamefail = timejudge.GetGameFail;

        gametime += Time.deltaTime;
        GameFin();
    }

    public void InitialScriptActive(){
        this.GetComponent<PictureJudge>().enabled = true;
        this.GetComponent<TimeJudgeMakiePaz>().enabled = true;
        timeUI.enabled = true;
        GameObject.Find("Makie1").GetComponent<MakieCol>().enabled = true;
        GameObject.Find("Makie2").GetComponent<MakieCol>().enabled = true;
        GameObject.Find("Makie3").GetComponent<MakieCol>().enabled = true;
        GameObject.Find("Makie4").GetComponent<MakieCol>().enabled = true;
        GameObject.Find("Makie5").GetComponent<MakieCol>().enabled = true;
        GameObject.Find("Makie6").GetComponent<MakieCol>().enabled = true;
        GameObject.Find("Makie7").GetComponent<MakieCol>().enabled = true;
        GameObject.Find("Makie8").GetComponent<MakieCol>().enabled = true;
        GameObject.Find("Makie9").GetComponent<MakieCol>().enabled = true;
    }

    public void GameFin(){
        if (gameclear == 1 || gamefail == 1){
            if (result_Time == 0){
                result_Time = gametime;
            }

            this.GetComponent<PictureJudge>().enabled = false;
            this.GetComponent<TimeJudgeMakiePaz>().enabled = false;
            timeUI.enabled = false;
            GameObject.Find("Makie1").GetComponent<MakieCol>().enabled = false;
            GameObject.Find("Makie2").GetComponent<MakieCol>().enabled = false;
            GameObject.Find("Makie3").GetComponent<MakieCol>().enabled = false;
            GameObject.Find("Makie4").GetComponent<MakieCol>().enabled = false;
            GameObject.Find("Makie5").GetComponent<MakieCol>().enabled = false;
            GameObject.Find("Makie6").GetComponent<MakieCol>().enabled = false;
            GameObject.Find("Makie7").GetComponent<MakieCol>().enabled = false;
            GameObject.Find("Makie8").GetComponent<MakieCol>().enabled = false;
            GameObject.Find("Makie9").GetComponent<MakieCol>().enabled = false;

            if (gametime >= result_Time + 1.0f){
                if (gameclear == 1){
                    Result[0].SetActive(true);
                } else if (gamefail == 1){
                    Result[1].SetActive(true);
                }
            }
        }
    }
}
