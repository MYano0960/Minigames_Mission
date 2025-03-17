using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotaruTori : MonoBehaviour
{
    private int gameover;

    private float startPosx, startPosy;
    private float speed;
    private float gametime;
    private float resultTime;
    private const float gameFinTime = 5.0f;
    private float waitTime, waitFinTime;

    private bool fadeout;

    private Vector2[] RPointPos, GPointPos;
    private Color col;

    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private List<GameObject> RPoint, GPoint, Result;
    [SerializeField]private GameObject Net;
    [SerializeField]private Image Light;
    [SerializeField]private TimeUI timeUI;
    [SerializeField]private AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        timeUI.enabled = true;
        fadeout = false;
        gametime = 0;
        resultTime = 0;
        gameover = -1;
        speed = 0;
        waitTime = 0;
        waitFinTime = 0;
        col.a = 1.0f;

        for (int i=0;i<Result.Count;i++){
            Result[i].SetActive(false);
        }

        RPointPos = new Vector2[2];
        for (int i=0;i<RPointPos.Length;i++){
            RPointPos[i] = RPoint[i].transform.position;
        }

        GenerateProcess();

        Net.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gametime += Time.deltaTime;
        LightCtr();
        GameProcess();
        GameFinish();
    }

    public void OnButtonClick(){
        if (GameContinue()){
            gameover = 0;
            SE.PlayOneShot(SE.clip);
        }
    }

    private void GenerateProcess(){
        GPointPos = new Vector2[4];
        for (int i=0;i<GPointPos.Length;i++){
            GPointPos[i] = GPoint[i].transform.position;
        }

        int rand_GPoint = Random.Range(0, 4);
        this.transform.position = GPointPos[rand_GPoint];
    }

    private void GameProcess(){
        if (!TimeOver()){
            if (HotaruReturnNum(this.transform.position.x, this.transform.position.y) == -1){
                if (EnoughWait()){
                    speed = MoveSpeed();
                    MoveVector(speed);
                    waitFinTime = WaitTime(speed);
                    waitTime = 0;
                } else {
                    waitTime += 1f;
                }
            } else {
                StartCoroutine(ReturnMove(HotaruReturnNum(this.transform.position.x, this.transform.position.y)));
            }
        } else {
            if (GameContinue()){
                gameover = 1;
            }
        }
    }

    private bool TimeOver(){
        if (gametime >= gameFinTime){
            return true;
        }
        return false;
    }

    private bool GameContinue(){
        if (gameover == -1){
            return true;
        }
        return false;
    }

    private int HotaruReturnNum(float thisPosX, float thisPosY){
        if (thisPosX > RPointPos[0].x && thisPosY < RPointPos[0].y && thisPosY > RPointPos[1].y){
            return 0;
        } else if (thisPosX < RPointPos[1].x && thisPosY < RPointPos[0].y && thisPosY > RPointPos[1].y){
            return 1;
        } else if (thisPosY > RPointPos[0].y && thisPosX < RPointPos[0].x && thisPosX > RPointPos[1].x){
            return 2;
        } else if (thisPosY < RPointPos[1].y && thisPosX < RPointPos[0].x && thisPosX > RPointPos[1].x){
            return 3;
        } else if (thisPosX > RPointPos[0].x && thisPosX > RPointPos[0].y){
            return 4;
        } else if (thisPosX < RPointPos[1].x && thisPosX > RPointPos[0].y){
            return 5;
        } else if (thisPosX < RPointPos[1].x && thisPosX < RPointPos[1].y){
            return 6;
        } else if (thisPosX > RPointPos[0].x && thisPosX < RPointPos[1].y){
            return 7;
        } else {
            return -1;
        }
    }

    private bool EnoughWait(){
        if (waitTime >= waitFinTime){
            return true;
        }
        return false;
    }

    private float MoveSpeed(){
        int rand_num = Random.Range(0, 8);
        switch (rand_num){
            case 0:
                return 1000.0f;
            case 1:
                return 1150.0f;
            case 2:
                return 1250.0f;
            case 3:
                return 1350.0f;
            case 4:
                return -1000.0f;
            case 5:
                return -1150.0f;
            case 6:
                return -1250.0f;
            case 7:
                return -1350.0f;
            default:
                return 0;
        }
    }

    private void MoveVector(float moveSpeed){
        int rand_num = Random.Range(0, 8);
        switch (rand_num){
            case 0:
                rb.linearVelocity = new Vector2(0, 0) * moveSpeed;
                break;
            case 1:
                rb.linearVelocity = new Vector2(1f, 0) * moveSpeed;
                break;
            case 2:
                rb.linearVelocity = new Vector2(0, 1f) * moveSpeed;
                break;
            case 3:
                rb.linearVelocity = new Vector2(1f, 1f) * moveSpeed;
                break;
            case 4:
                rb.linearVelocity = new Vector2(1f, -1f) * moveSpeed;
                break;
            case 5:
                rb.linearVelocity = new Vector2(1f, 2f) * moveSpeed;
                break;
            case 6:
                rb.linearVelocity = new Vector2(2f, 1f) * moveSpeed;
                break;
            case 7:
                rb.linearVelocity = new Vector2(2f, -1f) * moveSpeed;
                break;
            case 8:
                rb.linearVelocity = new Vector2(1f, -2f) * moveSpeed;
                break;
            default:
                rb.linearVelocity = new Vector2(0, 0);
                break;
        }
    }

    private float WaitTime(float speed){
        switch (speed){
            case 1000.0f:
                return Random.Range(20.0f, 48.0f);
            case -1000.0f:
                return Random.Range(20.0f, 48.0f);
            case 1150.0f:
                return Random.Range(20.0f, 46.0f);
            case -1150.0f:
                return Random.Range(20.0f, 46.0f);
            case 1250.0f:
                return Random.Range(20.0f, 42.0f);
            case -1250.0f:
                return Random.Range(20.0f, 42.0f);
            case 1350.0f:
                return Random.Range(20.0f, 40.0f);
            case -1350.0f:
                return Random.Range(20.0f, 40.0f);
            default:
                return 0;
        }
    }

    private IEnumerator ReturnMove(int ReturnNum){
        const float Rspeed = 1500.0f;
        switch (ReturnNum){
            case 0:
                rb.linearVelocity = new Vector2(-Rspeed, 0);
                break;
            case 1:
                rb.linearVelocity = new Vector2(Rspeed, 0);
                break;
            case 2:
                rb.linearVelocity = new Vector2(0, -Rspeed);
                break;
            case 3:
                rb.linearVelocity = new Vector2(0, Rspeed);
                break;
            case 4:
                rb.linearVelocity = new Vector2(-Rspeed, -Rspeed);
                break;
            case 5:
                rb.linearVelocity = new Vector2(Rspeed, -Rspeed);
                break;
            case 6:
                rb.linearVelocity = new Vector2(Rspeed, Rspeed);
                break;
            case 7:
                rb.linearVelocity = new Vector2(-Rspeed, Rspeed);
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1.5f);
    }

    private void GameFinish(){
        if (GameFinishJudge()){
            rb.linearVelocity = new Vector2(0, 0);
            timeUI.enabled = false;
            if (GameClear()){
                Net.SetActive(true);
                NetMove();
            } else {
                ResultShow();
            }
        }
    }

    private bool GameFinishJudge(){
        if (gameover == 0 || gameover == 1){
            return true;
        }
        return false;
    }

    private bool GameClear(){
        if (gameover == 0){
            return true;
        }
        return false;
    }

    private void NetMove(){
        Invoke("ResultShow", 1.5f);
    }

    private void ResultShow(){
        if (resultTime == 0){
            resultTime = gametime;
        }

        if (gametime >= resultTime + 1.0f){
            Result[gameover].SetActive(true);
        }
    }

    private IEnumerator MoveKeep(float waitFinTime){
        waitTime = 0;
        while (waitTime < waitFinTime){
            waitTime += 1f;
            yield return null;
        }
    }

    private void LightCtr(){
        if (ColorLowDepth()){
            fadeout = false;
        } else if (ColorHighDepth()){
            fadeout = true;
        }

        if (!fadeout){
            col.a += 0.005f;
        } else {
            col.a -= 0.005f;
        }
        Light.color = new Color(1.0f, 1.0f, 1.0f, col.a);
    }

    private bool ColorLowDepth(){
        if (col.a <= 0.4f){
            return true;
        }
        return false;
    }

    private bool ColorHighDepth(){
        if (col.a >= 1.0f){
            return true;
        }
        return false;
    }
}
