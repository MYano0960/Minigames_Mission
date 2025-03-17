using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPut : MonoBehaviour
{
    private int rock_generate1;
    private int rock_generate2;

    private int rockput1;
    private int rockput2;

    private int success_judge;
    private int time_restart;
    private int putpoint_again;
    private bool restart_once;

    public GameObject rock1_1;
    public GameObject rock1_2;
    public GameObject rock1_3;
    public GameObject rock2_1;
    public GameObject rock2_2;
    public GameObject rock2_3;
    
    private Vector3 pos;
    private Vector3 generete_point;

    private TimeJudgeTenguIwa timejudge;
    private RockThrow1 rockthrow1;
    // Start is called before the first frame update
    void Start()
    {
        RockActiveSet();
        RockRandomNum();
        RockGenerateJudge1();
        RockGenerateJudge2();

        time_restart = 0;
        restart_once = false; 
        putpoint_again = 0;

        this.timejudge = FindObjectOfType<TimeJudgeTenguIwa>();
        this.rockthrow1 = FindObjectOfType<RockThrow1>();
    }

    // Update is called once per frame
    void Update()
    {
        BoolSet();
        generete_point.x = GameObject.Find("GeneretePoint").transform.position.x;

        RockGenerateAct1();
        WaitTimeRestart();
        RockGenerateAct2();
    }

    public void RockActiveSet(){
        rock1_1.gameObject.SetActive(false);
        rock1_2.gameObject.SetActive(false);
        rock1_3.gameObject.SetActive(false);
        rock2_1.gameObject.SetActive(false);
        rock2_2.gameObject.SetActive(false);
        rock2_3.gameObject.SetActive(false);
    }

    public void RockRandomNum(){
        rock_generate1 = Random.Range(1, 4);;
        rock_generate2 = Random.Range(1, 4);
    }

    public void RockGenerateJudge1(){
        generete_point.y = GameObject.Find("GeneretePoint").transform.position.y;
        if (rock_generate1 == 1){
            rock1_1.gameObject.SetActive(true);
        } else if (rock_generate1 == 2){
            rock1_2.gameObject.SetActive(true);
        } else if (rock_generate1 == 3){
            rock1_3.gameObject.SetActive(true);
        }
    }

    public void RockGenerateJudge2(){
        if (rock_generate2 == 1){
            rock2_1.gameObject.SetActive(true);
        } else if (rock_generate2 == 2){
            rock2_2.gameObject.SetActive(true);
        } else if (rock_generate2 == 3){
            rock2_3.gameObject.SetActive(true);
        }
    }

    public void BoolSet(){
        rockput1 = timejudge.GetPutJudge1;
        rockput2 = timejudge.GetPutJudge2;
        success_judge = rockthrow1.GetSuccess1;
        time_restart = timejudge.GetTimeRestart;
    }

    public void RockGenerateAct1(){
        if (rockput1 == 0 && success_judge == 0){
            if (rock_generate1 == 1){
                rock1_1.transform.position = generete_point;
            } else if (rock_generate1 == 2){
                rock1_2.transform.position = generete_point;
            } else if (rock_generate1 == 3){
                rock1_3.transform.position = generete_point;
            }
        }
    }

    public void WaitTimeRestart(){
        if (success_judge == 1 && !restart_once){
            time_restart = 1;
            restart_once = true;
        }
    }

    public void RockGenerateAct2(){
        if (rockput2 == 0 && success_judge == 1 && time_restart == 0){
            if (rock_generate2 == 1){
                rock2_1.transform.position = generete_point;
                if (rock_generate1 == 1){
                    rock2_1.transform.rotation = Quaternion.Euler(0, 0, -138.67f);
                } else {
                    rock2_1.transform.rotation = Quaternion.Euler(0, 0, -178.425f);
                }
            } else if (rock_generate2 == 2){
                rock2_2.transform.position = generete_point;
                if (rock_generate1 == 1){
                    rock2_2.transform.rotation = Quaternion.Euler(0, 0, 245.925f);
                } else if (rock_generate1 == 2){
                    rock2_2.transform.rotation = Quaternion.Euler(0, 0, 379.976f);
                } else if (rock_generate1 == 3){
                    rock2_2.transform.rotation = Quaternion.Euler(0, 0, 148.262f);
                }
            } else if (rock_generate2 == 3){
                rock2_3.transform.position = generete_point;
                if (rock_generate1 == 1){
                    rock2_3.transform.rotation = Quaternion.Euler(0, 0, -542.894f);
                } else if (rock_generate1 == 2){
                    rock2_3.transform.rotation = Quaternion.Euler(0, 0, -467.113f);
                } else if (rock_generate1 == 3){
                    rock2_3.transform.rotation = Quaternion.Euler(0, 0, -560.23f);
                }
            }
            putpoint_again = 1;
        }
    }

    public int GetTimeRestart{
        get{return time_restart;}
        set{time_restart = value;}
    }

    public int GetPutPointAgain{
        get{return putpoint_again;}
        set{putpoint_again = value;}
    }

    public int GetRockGenerate1{
        get{return rock_generate1;}
        set{rock_generate1 = value;}
    }

    public int GetRockGenerate2{
        get{return rock_generate2;}
        set{rock_generate2 = value;}
    }
}
