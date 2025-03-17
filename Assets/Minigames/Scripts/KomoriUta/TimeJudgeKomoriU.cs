using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJudgeKomoriU : MonoBehaviour
{
    private int singjudge;
    private int singtime_sel;

    private int gameclear;
    private int gamefail;
    private int gameclear_not_over;

    private bool oversingjudge;

    private float gametime;
    private float singtime;

    private float singfintime;
    private float oversingtime;
    private float fintime = 2000.0f;

    private SingASong singasong;
    // Start is called before the first frame update
    void Start()
    {
        TimeSet();
        BoolSet();

        this.singasong = FindObjectOfType<SingASong>();
        SingFinTimeJudge();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GameTime());
        singjudge = singasong.GetSingJudge;
        SingLengthJudge();
    }

    public void TimeSet(){
        gametime = 0;
        singtime = 0;
    }

    public void BoolSet(){
        gameclear = 0;
        gamefail = 0;
        gameclear_not_over = 0;
        oversingjudge = false;
    }

    public void SingFinTimeJudge(){
        singtime_sel = Random.Range(3, 6);
        if (singtime_sel == 3){
            singfintime = 450.0f;
            oversingtime = singfintime + 150.0f;
            fintime = 1350.0f;
        } else if (singtime_sel == 4){
            singfintime = 550.0f;
            oversingtime = singfintime + 120.0f;
            fintime = 1450.0f;
        } else if (singtime_sel == 5){
            singfintime = 650.0f;
            oversingtime = singfintime + 100.0f;
            fintime = 1550.0f;
        }
    }

    public void SingLengthJudge(){
        if (fintime - gametime >= oversingtime && !oversingjudge){
            SingJudge();
        } else if (fintime - gametime < oversingtime || oversingjudge && gameclear == 0){
            gamefail = 1;
        }
    }

    public void SingJudge(){
        if (singjudge == 1){
            StartCoroutine(SingTime());
            GameClearJudge();
        } else if (singjudge == 0){
            if (singtime > singfintime && singtime <= oversingtime){
                gameclear_not_over = 1;
            } else {
                singtime = 0;
            }
        }
    }

    public void GameClearJudge(){
        if (singtime > singfintime){
            OverSingJudge();
        }
    }

    public void OverSingJudge(){
        StartCoroutine(OverSingTime());
        if (singtime > oversingtime){
            oversingjudge = true;
            gameclear = 0;
        } else if (singtime <= oversingtime){
            oversingjudge = false;
            gameclear = 1;
        }
    }

    IEnumerator GameTime(){
        while (gametime < fintime){
            gametime += 0.001f;
            yield return null;
        }
    }

    IEnumerator SingTime(){
        while (singtime < singfintime){
            singtime += 0.002f;
            yield return null;
        }
    }

    IEnumerator OverSingTime(){
        while (singtime < oversingtime){
            singtime += 0.002f;
            yield return null;
        }
    }

    public int GetGameFail{
        get{return gamefail;}
        set{gamefail = value;}
    }

    public int GetGameClear{
        get{return gameclear;}
        set{gameclear = value;}
    }

    public int GetNotOver{
        get{return gameclear_not_over;}
        set{gameclear_not_over = value;}
    }
}
