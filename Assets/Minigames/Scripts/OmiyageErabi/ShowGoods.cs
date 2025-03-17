using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGoods : MonoBehaviour
{
    private int correct_goods;

    private GameObject goods1;
    private GameObject goods2;
    private GameObject goods3;
    private GameObject goods4;
    // Start is called before the first frame update
    void Start()
    {
        GoodsSet();
        GoodsActive();
        CorrectGoodsJudge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoodsSet(){
        goods1 = GameObject.Find("Show_Goods1");
        goods2 = GameObject.Find("Show_Goods2");
        goods3 = GameObject.Find("Show_Goods3");
        goods4 = GameObject.Find("Show_Goods4");
    }

    public void GoodsActive(){
        goods1.gameObject.SetActive(false);
        goods2.gameObject.SetActive(false);
        goods3.gameObject.SetActive(false);
        goods4.gameObject.SetActive(false);
    }

    public void CorrectGoodsJudge(){
        correct_goods = Random.Range(1, 5);
        if (correct_goods == 1){
            goods1.gameObject.SetActive(true);
        } else if (correct_goods == 2){
            goods2.gameObject.SetActive(true);
        } else if (correct_goods == 3){
            goods3.gameObject.SetActive(true);
        } else if (correct_goods == 4){
            goods4.gameObject.SetActive(true);
        }
    }

    public int GetGoodsSel{
        get{return correct_goods;}
        set{correct_goods = value;}
    }
}
