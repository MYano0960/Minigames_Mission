using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMoveLow : MonoBehaviour
{
    Vector3 pos_low;

    private float velocity_low = 0.3f;

    private int gamefail;
    private int gameclear;

    private GameOverKawaK gameovercheck;
    private TimeJudgeKawaK timejudge;
    // Start is called before the first frame update
    void Start()
    {
        this.gameovercheck = FindObjectOfType<GameOverKawaK>();
        this.timejudge = FindObjectOfType<TimeJudgeKawaK>();

        pos_low = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gamefail = gameovercheck.GetGameFail;
        gameclear = timejudge.GetGameClear;

        pos_low.x -= velocity_low;
        this.transform.position = pos_low;

        GameFinishJudge();
    }

    public void GameFinishJudge(){
        if(gamefail == 1 || gameclear == 1){
            velocity_low = 0;
        }
    }
}
