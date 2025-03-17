using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJudgeKomoriU : MonoBehaviour
{
    private int gameclear;
    private int gamefail;
    private int gameclear_not_over;

    private int cryjudge;

    private float gametime;
    private float result_Time;

    private TimeJudgeKomoriU timejudge;

    private GameObject baby;
    private GameObject baby_cry;

    private GameObject button_on;
    private GameObject button_off;
    [SerializeField]private List<GameObject> Result;
    // Start is called before the first frame update
    void Start()
    {
        this.timejudge = FindObjectOfType<TimeJudgeKomoriU>();
        gametime = 0;
        result_Time = 0;
        
        ButtonSet();
        BabySet();
        for (int i=0;i<Result.Count;i++){
            Result[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GameFinishJudge();
    }

    public void ButtonSet(){
        GameObject.Find("Button").GetComponent<SingASong>().enabled = true;
        button_on = GameObject.Find("sing_b");
        button_off = GameObject.Find("sing");
    }

    public void BabySet(){
        baby = transform.Find("baby_a").gameObject;
        baby_cry = transform.Find("baby_b").gameObject;
        baby.gameObject.SetActive(false);
        baby_cry.gameObject.SetActive(true);
        cryjudge = 1;
    }

    public void GameFinishJudge(){
        TimeSet();

        if (gameclear == 1){
            baby.gameObject.SetActive(true);
            baby_cry.gameObject.SetActive(false);
            cryjudge = 0;
            if (gameclear_not_over == 1){
                ButtonJudge();
            }
        } else if (gamefail == 1){
            baby.gameObject.SetActive(false);
            baby_cry.gameObject.SetActive(true);
            cryjudge = 1;
            ButtonJudge();
        }
    }

    public void TimeSet(){
        gameclear = timejudge.GetGameClear;
        gamefail = timejudge.GetGameFail;
        gameclear_not_over = timejudge.GetNotOver;
    }

    public void ButtonJudge(){
        button_on.gameObject.SetActive(false);
        button_off.gameObject.SetActive(true);
        GameObject.Find("Button").GetComponent<SingASong>().enabled = false;
    }

    public int GetCryJudge{
        get{return cryjudge;}
        set{cryjudge = value;}
    }
}
