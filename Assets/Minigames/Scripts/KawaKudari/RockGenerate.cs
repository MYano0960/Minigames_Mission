using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerate : MonoBehaviour
{
    [SerializeField] List<GameObject> RockList; 

    Vector3 r_point1;
    Vector3 r_point2;
    Vector3 r_point3;

    private int pos_judge;
    private int pos_judge_ctr;
    private int rock_select;
    
    private int frame = 0;
    private int generateframe;

    private int no_rock1;
    private int no_rock2;
    private int no_rock3;
    // Start is called before the first frame update
    void Start()
    {
        generateframe = 100;

        no_rock1 = 0;
        no_rock2 = 0;
        no_rock3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        R_Point();
        FrameNum();
        FrameNumJudge();
    }

    public void R_Point(){
        r_point1 = GameObject.Find("R_Point1").transform.position;
        r_point2 = GameObject.Find("R_Point2").transform.position;
        r_point3 = GameObject.Find("R_Point3").transform.position;
    }

    public void FrameNum(){
        generateframe = Random.Range(95, 100);
        ++frame;
    }

    public void FrameNumJudge(){
        if(frame > generateframe)
        {
            frame = 0;
            pos_judge = Random.Range(1, 4);
            rock_select = Random.Range(0, 3);

            NoRockJudge();
            PosJudge();
        }
    }

    public void NoRockJudge(){
        if(no_rock1 >= 1){
            pos_judge_ctr = Random.Range(0, 2);
            if(pos_judge_ctr == 0){
                pos_judge = 2;
                if(no_rock2 != 0){
                    pos_judge = 3;
                }
            } else if(pos_judge_ctr == 1){
                pos_judge = 3;
                if(no_rock3 != 0){
                    pos_judge = 2;
                }
            }
        } else if(no_rock2 >= 1){
            pos_judge_ctr = Random.Range(0, 2);
            if(pos_judge_ctr == 0){
                pos_judge = 1;
                if(no_rock1 != 0){
                    pos_judge = 3;
                }
            }else if(pos_judge_ctr == 1){
                pos_judge = 3;
                if(no_rock3 != 0){
                    pos_judge = 1;
                }
            }
        } else if(no_rock3 >= 1){
            pos_judge_ctr = Random.Range(0, 2);
            if(pos_judge_ctr == 0){
                pos_judge = 1;
                if(no_rock1 != 0){
                    pos_judge = 2;
                }
            } else if(pos_judge_ctr == 1){
                pos_judge = 2;
                if(no_rock1 != 0){
                    pos_judge = 2;
                }
            }
        }
    }

    public void PosJudge(){
        if(pos_judge == 1){
            Instantiate(RockList[rock_select], new Vector3(r_point1.x, r_point1.y, 0), Quaternion.identity);
            ++no_rock1;
            no_rock2 = 0;
            no_rock3 = 0;
        } else if(pos_judge == 2){
            Instantiate(RockList[rock_select], new Vector3(r_point2.x, r_point2.y, 0), Quaternion.identity);
            ++no_rock2;
            no_rock1 = 0;
            no_rock3 = 0;
        } else if(pos_judge == 3){
            Instantiate(RockList[rock_select], new Vector3(r_point3.x, r_point3.y, 0), Quaternion.identity);
            ++no_rock3;
            no_rock1 = 0;
            no_rock2 = 0;
        }
    }
}
