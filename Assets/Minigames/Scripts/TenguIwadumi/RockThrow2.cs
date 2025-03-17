using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow2 : MonoBehaviour
{
    Rigidbody2D rb;
    
    private int success2;

    private float judging_time;
    private float judging_fintime = 300f;

    private float fix_thispos;

    private bool putjudge;
    private bool check_fixpos_const;

    private Vector3 put_pos;
    private Vector3 putpoint_pos;

    public GameObject putpoint;
    public GameObject thisobj;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;

        putjudge = false;
        check_fixpos_const = false;

        success2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisobj != null){
            putpoint_pos = putpoint.transform.position;
            PutSuccessJudge();
        }
    }

    public void PutSuccessJudge(){
        if (putjudge && (rb.linearVelocity.x < 2.0f && rb.linearVelocity.x > - 2.0f) && (rb.linearVelocity.y < 1.0f && rb.linearVelocity.y > - 1.0f)){
            StartCoroutine(SuccessJudgeTime());
            if (judging_time >= judging_fintime){
                success2 = 1;
                rb.linearVelocity = new Vector3 (0, 0, 0);
                rb.isKinematic = true;
                put_pos = this.transform.position;
                if (!check_fixpos_const){
                    check_fixpos_const = true;
                    fix_thispos = put_pos.x - putpoint_pos.x;
                }
                put_pos.x = putpoint_pos.x + fix_thispos;
                this.transform.position = put_pos;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        } else {
            judging_time = 0;
        }
    }

    IEnumerator SuccessJudgeTime(){
        while (judging_time < judging_fintime){
            judging_time += 0.01f;
            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "PutPoint" || col.gameObject.name == "Rock1_1" || col.gameObject.name == "Rock1_2" || col.gameObject.name == "Rock1_3"){
            putjudge = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "PutPoint" || col.gameObject.name == "Rock1_1" || col.gameObject.name == "Rock1_2" || col.gameObject.name == "Rock1_3"){
            putjudge = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "PutPoint" || col.gameObject.name == "Rock1_1" || col.gameObject.name == "Rock1_2" || col.gameObject.name == "Rock1_3"){
            putjudge = false;
        }
    }

    public int GetSuccess2{
        get{return success2;}
        set{success2 = value;}
    }
}
