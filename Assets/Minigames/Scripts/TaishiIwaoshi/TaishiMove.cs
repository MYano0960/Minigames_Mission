using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaishiMove : MonoBehaviour
{
    private int mouse_push_judge;
    private int gamefail;
    private int gameclear;
    private int taishi_step;

    private float push_time;
    private float overpush_time;
    private float cool_time;
    private float push_fintime = 3.0f;
    private float overpush_fintime = 5.0f;
    private float cool_fintime = 10.0f;

    private bool cooltime_judge;
    private bool overpush_time_reset;

    private Vector3 pos;
    private Vector3 goal_pos;

    public GameObject goal;

    public ButtonPushTaishiIwa buttonpush;

    [SerializeField]private List<GameObject> Taishi;
    // Start is called before the first frame update
    void Start()
    {
        BoolSet();

        pos = this.transform.position;
        goal_pos = goal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Taishi[taishi_step].SetActive(true);
        Taishi[1-taishi_step].SetActive(false);

        mouse_push_judge = buttonpush.GetButtonPush;
        if (mouse_push_judge == 1 && !cooltime_judge){
            StartCoroutine(PushTime());
            MousePushJudge();
        } else {
            MouseUpFailJudge();
        }
        GameClear();
    }

    public void BoolSet(){
        taishi_step = 0;
        push_time = 0;
        overpush_time = 0;
        cool_time = 0;
        cooltime_judge = false;
        overpush_time_reset = false;
        gamefail = 0;
        gameclear = 0;
    }

    public void MousePushJudge(){
        if (push_time >= push_fintime){
            StartCoroutine(OverPushTime());
            OverPushTimeJudge();
        }
    }

    public void MouseUpFailJudge(){
        if (Input.GetMouseButtonUp(0) && push_time < push_fintime){
            push_time = push_fintime - 0.001f;
            gamefail = 1;
        } else {
            CoolTimeJudge();
        }
    }

    public void OverPushTimeJudge(){
        if (overpush_time_reset){
            push_time = 0;
            overpush_time = 0;
            pos = this.transform.position;
            overpush_time_reset = false;
            taishi_step = 1 - taishi_step;
        } else if (overpush_time >= overpush_fintime){
            gamefail = 1;
        }
    }

    public void CoolTimeJudge(){
        if (cooltime_judge){
            StartCoroutine(CoolTime());
            if (cool_time < cool_fintime){
                cooltime_judge = true;
            } else if (cool_time >= cool_fintime){
                cool_time = 0;
                cooltime_judge = false;
            }
        }
    }

    public void GameClear(){
        if (pos.x >= goal_pos.x){
            gameclear = 1;
        }
    }

    IEnumerator CoolTime(){
        while (cool_time < cool_fintime){
            cool_time += 0.001f;
            yield return null;
        }
    }

    IEnumerator OverPushTime(){
        while (overpush_time < overpush_fintime){
            overpush_time += 0.001f;
            if (Input.GetMouseButtonUp(0)){
                overpush_time_reset = true;
                cooltime_judge = true;
                yield break;
            } else {
                yield return null;
            }
        }
    }

    IEnumerator PushTime(){
        while (push_time < push_fintime){
            push_time += 0.001f;
            this.transform.position += new Vector3 (0.0005f, 0, 0);
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
}
