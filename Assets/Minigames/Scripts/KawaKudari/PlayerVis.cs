using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVis : MonoBehaviour
{
    Vector3 pos;

    Vector3 point_fail1;
    Vector3 point_fail2;
    Vector3 point_fail3;

    private int gamefail;
    private int click_judge1;
    private int click_judge2;
    private int click_judge3;

    private GameObject boat_play;
    private GameObject boat_fail;

    private GameOverKawaK gameovercheck;
    private MovePoint movepoint;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;

        this.gameovercheck = FindObjectOfType<GameOverKawaK>();
        this.movepoint = FindObjectOfType<MovePoint>();

        boat_play = transform.Find("boat_play").gameObject;
        boat_fail = transform.Find("boat_fail").gameObject;

        boat_play.gameObject.SetActive(true);
        boat_fail.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gamefail = gameovercheck.GetGameFail;

        ClickJudge();
        PointFail();
        PlayerVisJudge();
    }

    public void ClickJudge(){
        click_judge1 = movepoint.GetMovePoint1;
        click_judge2 = movepoint.GetMovePoint2;
        click_judge3 = movepoint.GetMovePoint3;
    }

    public void PointFail(){
        point_fail1 = GameObject.Find("FailPoint1").transform.position;
        point_fail2 = GameObject.Find("FailPoint2").transform.position;
        point_fail3 = GameObject.Find("FailPoint3").transform.position;
    }

    public void PlayerVisJudge(){
        if (gamefail == 1){
            boat_play.gameObject.SetActive(false);
            boat_fail.gameObject.SetActive(true);
            if(click_judge1 == 1)
            {
                pos = point_fail1;
                this.transform.position = pos;
            }
            else if(click_judge2 == 1)
            {
                pos = point_fail2;
                this.transform.position = pos;
            }
            else if(click_judge3 == 1)
            {
                pos = point_fail3;
                this.transform.position = pos;
            }
        }
    }
}
