using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMove : MonoBehaviour
{
    private int cryjudge;
    private int movejudge;

    private float movetime;
    private float movefintime = 3.0f;

    private Vector3 pos;

    private Vector3 movepoint1;
    private Vector3 movepoint2;
    private Vector3 movepoint3;
    private Vector3 movepoint4;

    private GameOverJudgeKomoriU gameoverjudge;
    // Start is called before the first frame update
    void Start()
    {
        this.gameoverjudge = FindObjectOfType<GameOverJudgeKomoriU>();

        pos = this.transform.position;
        
        movejudge = 1;
    }

    // Update is called once per frame
    void Update()
    {
        cryjudge = gameoverjudge.GetCryJudge;

        MovePointSet();
        MoveCtrl();
    }

    public void MovePointSet(){
        movepoint1 = GameObject.Find("MovePoint1").transform.position;
        movepoint2 = GameObject.Find("MovePoint2").transform.position;
        movepoint3 = GameObject.Find("MovePoint3").transform.position;
        movepoint4 = GameObject.Find("MovePoint4").transform.position;
    }

    public void MoveCtrl(){
        StartCoroutine(MoveTime());
        if (cryjudge == 1 && movetime >= movefintime){
            if (movejudge == 1){
                pos = movepoint1;
                this.transform.position = pos;
                movejudge = 2;
            } else if (movejudge == 2){
                pos = movepoint2;
                this.transform.position = pos;
                movejudge = 3;
            } else if (movejudge == 3){
                pos = movepoint3;
                this.transform.position = pos;
                movejudge = 4;
            } else if (movejudge == 4){
                pos = movepoint4;
                this.transform.position = pos;
                movejudge = 1;
            }
            movetime = 0;
        }
    }

    IEnumerator MoveTime(){
        while (movetime < movefintime){
            movetime += 0.1f;
            yield return null;
        }
    }
}
