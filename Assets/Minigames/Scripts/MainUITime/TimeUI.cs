using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField]private float minigame_Time;
    private float speed_Obj = 0.01f;
    private float tmp_Time = 0;
    private float finTime;

    private int theObj_num;
    private bool start_del;

    private GameObject[] timeObj;
    [SerializeField]private SpriteRenderer[] sr;
    // Start is called before the first frame update
    void Start()
    {
        timeObj = new GameObject[5];
        finTime = minigame_Time / 5.0f;
        theObj_num = 4;
        start_del = false;

        for (int i=0;i<timeObj.Length;i++){
            timeObj[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tmp_Time += Time.deltaTime;
        if (start_del){
            if (theObj_num >= 0){
                if (tmp_Time <= finTime){
                    timeObj[theObj_num].transform.position = new Vector3(timeObj[theObj_num].transform.position.x, timeObj[theObj_num].transform.position.y+speed_Obj, timeObj[theObj_num].transform.position.z);
                    sr[theObj_num].color -= new Color(0, 0, 0, 0.01f);
                } else if (tmp_Time > finTime){
                    tmp_Time = 0;
                    sr[theObj_num].color = new Color(0, 0, 0, 0);
                    theObj_num--;
                }
            }
        } else if (tmp_Time > finTime && !start_del){
            start_del = true;
        }
    }
}
