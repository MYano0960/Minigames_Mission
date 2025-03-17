using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMoveMed : MonoBehaviour
{
    Vector3 pos_med;

    private float velocity_med = 0.35f;

    private int gamefail;
    private int gameclear;

    private GameOverKawaK gameovercheck;
    private TimeJudgeKawaK timejudge;
    // Start is called before the first frame update
    void Start()
    {
        this.gameovercheck = FindObjectOfType<GameOverKawaK>();
        this.timejudge = FindObjectOfType<TimeJudgeKawaK>();

        pos_med = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gamefail = gameovercheck.GetGameFail;
        gameclear = timejudge.GetGameClear;

        pos_med.x -= velocity_med;
        this.transform.position = pos_med;

        GameFinishJudge();
    }

    public void GameFinishJudge(){
        if(gamefail == 1 || gameclear == 1){
            velocity_med = 0;
        }
    }
}
