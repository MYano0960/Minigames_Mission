using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverKawaK : MonoBehaviour
{
    private int gamefail;
    private int gameclear;

    private float gametime;
    private float result_Time;

    public GameObject rock_low;
    public GameObject rock_med;
    public GameObject rock_high;
    public GameObject rock;

    private TimeJudgeKawaK timejudge;
    [SerializeField]private TimeUI timeUI;
    [SerializeField]private List<GameObject> Result;
    // Start is called before the first frame update
    void Start()
    {
        gamefail = 0;
        gametime = 0;
        result_Time = 0;

        GetComponent<PlayerMove>().enabled = true;
        rock.GetComponent<RockGenerate>().enabled = true;
        timeUI.enabled = true;
        
        this.timejudge = FindObjectOfType<TimeJudgeKawaK>();
        for (int i=0;i<Result.Count;i++){
            Result[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        gameclear = timejudge.GetGameClear;
        GameFinishJudge();
    }

    private void GameFinishJudge(){
        if (gamefail == 1 || gameclear == 1){
            if (result_Time == 0){
                result_Time = gametime;
            }

            GetComponent<PlayerMove>().enabled = false;
            rock.GetComponent<RockGenerate>().enabled = false;
            timeUI.enabled = false;

            if (gametime >= result_Time + 1.0f){
                if (gamefail == 1){
                    Result[1].SetActive(true);
                } else if (gameclear == 1){
                    Result[0].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Rock")
        {
            gamefail = 1;
        }
    }

    public int GetGameFail{
        get{return gamefail;}
        set{gamefail = value;}
    }
}
