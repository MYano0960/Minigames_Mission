using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerate : MonoBehaviour
{
    [SerializeField] List<GameObject> ItemList;

    private int item_select;
    private int success_sum;
    private int generate_fin;

    private int judge_num;
    private int destroy_judge_num;

    private int gamefail;
    private int destory_gamefail;

    private bool generate1;
    private bool generate2;
    private bool generate3;

    private Vector3 generate_pos;

    public GameObject generate_point;

    public ItemJudgePoint itemjudge;
    public DestroyPointTokusanMono destroypoint;
    // Start is called before the first frame update
    void Start()
    {
        generate_pos = generate_point.transform.position;
        success_sum = 0;

        generate_fin = 0;

        generate1 = false;
        generate2 = false;
        generate3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (generate_fin <= 3){
            GetJudgeNum();
            if (judge_num + destroy_judge_num == 0 && generate_fin == 0){
                if (!generate1){
                    StartCoroutine(TimeJudge1());
                    generate1 = true;
                }
                ++generate_fin;
            } else if (judge_num + destroy_judge_num == 1 && generate_fin == 1){
                if (!generate2){
                    StartCoroutine(TimeJudge2());
                    generate2 = true;
                }
                ++generate_fin;
            } else if (judge_num + destroy_judge_num == 2 && generate_fin == 2){
                if (!generate3){
                    StartCoroutine(TimeJudge3());
                    generate3 = true;
                }
                ++generate_fin;
            }
        }
    }

    public void GetJudgeNum(){
        judge_num = itemjudge.GetJudgeNum;
        destroy_judge_num = destroypoint.GetDestroyJudgeNum;
    }

    private IEnumerator TimeJudge1(){
        item_select = Random.Range(0, 7);
        SuccessSum();
        yield return new WaitForSeconds(2.0f);
        Instantiate(ItemList[item_select], new Vector3(generate_pos.x, generate_pos.y, 0), Quaternion.identity);
        yield break;
    }

    private IEnumerator TimeJudge2(){
        item_select = Random.Range(0, 7);
        SuccessSum();
        GetFailJudge();
        yield return new WaitForSeconds(1.0f);
        if (gamefail == 0 && destory_gamefail == 0){
            Instantiate(ItemList[item_select], new Vector3(generate_pos.x, generate_pos.y, 0), Quaternion.identity);
            yield break;
        } else {
            yield break;
        }
    }

    private IEnumerator TimeJudge3(){
        item_select = Random.Range(0, 7);
        SuccessSum();
        GetFailJudge();
        yield return new WaitForSeconds(1.0f);
        if (gamefail == 0 && destory_gamefail == 0){
            Instantiate(ItemList[item_select], new Vector3(generate_pos.x, generate_pos.y, 0), Quaternion.identity);
            yield break;
        } else {
            yield break;
        }
    }

    public void SuccessSum(){
        if (item_select <= 3){
            ++success_sum;
        }
    }

    public void GetFailJudge(){
        gamefail = itemjudge.GetGameFail;
        destory_gamefail = destroypoint.GetDestroyGameFail;
    }

    public int GetSuccessSum{
        get{return success_sum;}
        set{success_sum = value;}
    }
}
