using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMoveHigh : MonoBehaviour
{
    Vector3 pos_high;

    private float velocity_high = 0.4f;

    private int gamefail;
    private int gameclear;

    private GameOverKawaK gameovercheck;
    private TimeJudgeKawaK timejudge;
    // Start is called before the first frame update
    void Start()
    {
        this.gameovercheck = FindObjectOfType<GameOverKawaK>();
        this.timejudge = FindObjectOfType<TimeJudgeKawaK>();

        pos_high = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gamefail = gameovercheck.GetGameFail;
        gameclear = timejudge.GetGameClear;

        pos_high.x -= velocity_high;
        this.transform.position = pos_high;

        GameFinishJudge();
    }

    public void GameFinishJudge(){
        if(gamefail == 1 || gameclear == 1){
            velocity_high = 0;
        }
    }
}
