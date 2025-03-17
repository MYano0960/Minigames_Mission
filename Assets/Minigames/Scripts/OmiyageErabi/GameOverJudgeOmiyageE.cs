using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJudgeOmiyageE : MonoBehaviour
{
    private bool entryjudge;

    private int correct_goods;
    private int entry_goods;

    private int gameclear;
    private int gamefail;
    private int gamefailjudge;
    private int gamefinjudge;

    private float gametime;
    private float result_Time;

    private ShowGoods showgoods;

    private GoodsCol1 goodscol1;
    private GoodsCol2 goodscol2;
    private GoodsCol3 goodscol3;
    private GoodsCol4 goodscol4;

    private TimeJudgeOmiyageE timejudge;
    [SerializeField]private TimeUI timeUI;
    [SerializeField]private List<GameObject> Result;
    // Start is called before the first frame update
    void Start()
    {
        ScriptsSet();
        BoolSet();
        gametime = 0;
        result_Time = 0;
        for (int i=0;i<Result.Count;i++){
            Result[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        correct_goods = showgoods.GetGoodsSel;
        gamefailjudge = timejudge.GetGameFailJudge;
        gametime += Time.deltaTime;

        GameFinJudge();
    }

    public void ScriptsSet(){
        this.showgoods = FindObjectOfType<ShowGoods>();
        this.goodscol1 = FindObjectOfType<GoodsCol1>();
        this.goodscol2 = FindObjectOfType<GoodsCol2>();
        this.goodscol3 = FindObjectOfType<GoodsCol3>();
        this.goodscol4 = FindObjectOfType<GoodsCol4>();
        this.timejudge = FindObjectOfType<TimeJudgeOmiyageE>();
        timeUI.enabled = true;
    }

    public void BoolSet(){
        gameclear = 0;
        gamefail = 0;
        gamefinjudge = 0;

        entryjudge = false;
    }

    public void GameFinJudge(){
        if (gameclear == 0 && gamefail == 0){
            if (correct_goods == entry_goods && entryjudge){
                gameclear = 1;
            } else if (correct_goods != entry_goods && entryjudge || gamefailjudge == 1){
                gamefail = 1;
            }
        } else if (gameclear == 1 || gamefail == 1){
            gamefinjudge = 1;
            timeUI.enabled = false;
            if (result_Time == 0){
                result_Time = gametime;
            }

            if (gametime >= result_Time + 1.0f){
                if (gameclear == 1){
                    Result[0].SetActive(true);
                } else if (gamefail == 1){
                    Result[1].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name == "Sel_Goods1"){
            entry_goods = goodscol1.GetEntry1;
        } else if (col.gameObject.name == "Sel_Goods2"){
            entry_goods = goodscol2.GetEntry2;
        } else if (col.gameObject.name == "Sel_Goods3"){
            entry_goods = goodscol3.GetEntry3;
        } else if (col.gameObject.name == "Sel_Goods4"){
            entry_goods = goodscol4.GetEntry4;
        }

        entryjudge = true;
    }

    public int GetGameFinJudge{
        get{return gamefinjudge;}
        set{gamefinjudge = value;}
    }
}
