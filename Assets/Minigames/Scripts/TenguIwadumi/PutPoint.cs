using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPoint : MonoBehaviour
{
    Rigidbody2D rb;

    private bool move_waiting;
    private bool fix_judge;
    private bool center_put_judge;
    private bool center_return;

    private int rockput1;
    private int rockput2;
    private int move_again;
    
    private int random_move_judge;
    private int random_move_vector_judge;

    private int touch_wall_left;
    private int touch_wall_right;

    private float move_speed = 5.0f;
    private float move_time;
    private float move_fintime;

    private float memory_pos;

    private Vector3 pos;

    private TimeJudgeTenguIwa timejudge;
    private PutPointColLeft putpointcolleft;
    private PutPointColRight putpointcolright;
    private RockPut rockput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pos.y = this.transform.position.y;
        memory_pos = pos.y;

        BoolSet();
        ScriptSet();
    }

    // Update is called once per frame
    void Update()
    {
        GetBoolSet();
        RockPutJudge();
    }

    public void BoolSet(){
        move_waiting = false;
        fix_judge = false;
        center_put_judge = true;
        center_return = false;
    }

    public void ScriptSet(){
        this.timejudge = FindObjectOfType<TimeJudgeTenguIwa>();
        this.putpointcolleft = FindObjectOfType<PutPointColLeft>();
        this.putpointcolright = FindObjectOfType<PutPointColRight>();
        this.rockput = FindObjectOfType<RockPut>();
    }

    public void GetBoolSet(){
        rockput1 = timejudge.GetPutJudge1;
        rockput2 = timejudge.GetPutJudge2;
        touch_wall_left = putpointcolleft.GetPutColLeft;
        touch_wall_right = putpointcolright.GetPutColRight;
        move_again = rockput.GetPutPointAgain;
    }

    public void RockPutJudge(){
        if (rockput1 == 1 || (rockput2 == 1 && move_again == 1)){
            RockFix();
        } else if (rockput1 == 0 || (rockput2 == 0 && move_again == 1)){
            PosDecide();
            RandomNum();
            MoveVectorJudge();
            StartCoroutine(MoveTime());
            MoveWaitJudge();
        }
    }

    public void RockFix(){
        if (!fix_judge){
            pos.x = this.transform.position.x;
            fix_judge = true;
        } else {
            this.transform.position = pos;
            rb.linearVelocity = new Vector3 (0, 0, 0);
            MoveAgain();
        }
    }

    public void MoveAgain(){
        if (rockput2 == 0 && move_again == 1){
            fix_judge = false;
        }
    }

    public void PosDecide(){
        pos.x = this.transform.position.x;
        pos.y = memory_pos;
        this.transform.position = pos;
    }

    public void RandomNum(){
        random_move_vector_judge = Random.Range(0, 2);
        random_move_judge = Random.Range(0, 5);
    }

    public void MoveVectorJudge(){
        if (!move_waiting){
            if (touch_wall_left == 0 && touch_wall_right == 0){
                if (random_move_vector_judge == 0){
                    rb.linearVelocity = new Vector3 (move_speed, 0, 0);
                } else if (random_move_vector_judge == 1){
                    rb.linearVelocity = new Vector3 (-1 * move_speed, 0, 0);
                }
                center_put_judge = true;
            } else if (touch_wall_left == 1 && touch_wall_right == 0){
                rb.linearVelocity = new Vector3 (move_speed, 0, 0);
                center_put_judge = false;
            } else if (touch_wall_left == 0 && touch_wall_right == 1){
                rb.linearVelocity = new Vector3 (-1 * move_speed, 0, 0);
                center_put_judge = false;
            }
            move_waiting = true;
        }
    }

    public void MoveWaitJudge(){
        CenterReturnJudge();
        MoveFinJudge();
    }

    public void CenterReturnJudge(){
        if (center_put_judge && !center_return && (touch_wall_right == 1 || touch_wall_left == 1)){
            move_time = move_fintime - 0.1f;
            center_return = true;
        }
    }

    public void MoveFinJudge(){
        if (move_time >= move_fintime){
            move_waiting = false;
            center_return = false;
            move_time = 0;
        }
    }

    IEnumerator MoveTime(){
        if (touch_wall_right == 0 && touch_wall_left == 0){
            switch (random_move_judge){
            case 0:
                move_fintime = 60.0f;
                break;
            case 1:
                move_fintime = 65.0f;
                break;
            case 2:
                move_fintime = 70.0f;
                break;
            case 3:
                move_fintime = 75.0f;
                break;
            case 4:
                move_fintime = 80.0f;
                break;
            default:
                break;
            }
        } else if (touch_wall_right == 1 || touch_wall_left == 1){
            move_fintime = 10.0f;
        }

        while (move_time < move_fintime){
            move_time += 0.01f;
            yield return null;
        }
    }

    public float GetPutPointPosX{
        get{return pos.x;}
        set{pos.x = value;}
    }
}
