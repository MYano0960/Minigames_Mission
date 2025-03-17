using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJudgeTenguIwa : MonoBehaviour
{
    private int gamefail1;
    private int gamefail2;
    private int success1;
    private int success2;

    private float gametime;
    private float result_Time;

    private RockThrow1 rockthrow1;
    private RockThrow2 rockthrow2;
    private DestroyPointIwadumi destroypoint;
    [SerializeField]private List<GameObject> Result;
    // Start is called before the first frame update
    void Start()
    {
        gametime = 0;
        result_Time = 0;
        ScriptSet();
        ScriptEnable();
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GetBoolSet();
        if ((success1 == 1 && success2 == 1) || gamefail1 == 1 || gamefail2 == 1){
            if (result_Time == 0){
                result_Time = gametime;
            }

            GameOverJudge();

            if (gametime >= result_Time + 1.0f){
                if (success1 == 1 && success2 == 1){
                    Result[0].SetActive(true);
                } else if (gamefail1 == 1 || gamefail2 == 1){
                    Result[1].SetActive(true);
                }
            }
        }
    }

    public void ScriptEnable(){
        GameObject.Find("Player").GetComponent<TenguMove>().enabled = true;
        GameObject.Find("PutPoint").GetComponent<PutPoint>().enabled = true;
        GameObject.Find("Player").GetComponent<TimeJudgeTenguIwa>().enabled = true;
    }

    public void ScriptSet(){
        this.rockthrow1 = FindObjectOfType<RockThrow1>();
        this.rockthrow2 = FindObjectOfType<RockThrow2>();
        this.destroypoint = FindObjectOfType<DestroyPointIwadumi>();
    }

    public void GetBoolSet(){
        success1 = rockthrow1.GetSuccess1;
        success2 = rockthrow2.GetSuccess2;

        gamefail1 = destroypoint.GetGameFail1;
        gamefail2 = destroypoint.GetGameFail2;
    }

    public void GameOverJudge(){
        GameObject.Find("Player").GetComponent<TenguMove>().enabled = false;
        GameObject.Find("PutPoint").GetComponent<PutPoint>().enabled = false;
        GameObject.Find("Player").GetComponent<TimeJudgeTenguIwa>().enabled = false;
    }
}
