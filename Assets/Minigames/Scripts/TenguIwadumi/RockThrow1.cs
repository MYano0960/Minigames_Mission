using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow1 : MonoBehaviour
{
    Rigidbody2D rb;
    
    private int success1;

    private int rock_generate1;

    private float judging_time;
    private float judging_fintime = 300f;

    private float fix_thispos;

    private bool putjudge;

    private Vector3 put_pos;

    private RockPut rockput;

    public GameObject fixpoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;

        this.rockput = FindObjectOfType<RockPut>();
        rock_generate1 = rockput.GetRockGenerate1;

        putjudge = false;

        success1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PutSuccessJudge();
    }

    public void PutSuccessJudge(){
        if (putjudge && (rb.linearVelocity.x < 2.0f && rb.linearVelocity.x > - 2.0f) && (rb.linearVelocity.y < 1.0f && rb.linearVelocity.y > - 1.0f)){
            StartCoroutine(SuccessJudgeTime());
            if (judging_time >= judging_fintime){
                success1 = 1;
                rb.linearVelocity = new Vector3 (0, 0, 0);
                rb.isKinematic = true;
                put_pos = fixpoint.transform.position;
                if (rock_generate1 == 1){
                    this.transform.rotation = Quaternion.Euler(0, 0, 82.289f);
                } else if (rock_generate1 == 2){
                    this.transform.rotation = Quaternion.Euler(0, 0, 120.621f);
                } else if (rock_generate1 == 3){
                    this.transform.rotation = Quaternion.Euler(0, 0, -33.619f);
                }
                this.transform.position = put_pos;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        } else if (success1 == 1){
            put_pos = fixpoint.transform.position;
            this.transform.position = put_pos;
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
        if (col.gameObject.name == "PutPoint"){
            putjudge = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "PutPoint"){
            putjudge = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "PutPoint"){
            putjudge = false;
        }
    }

    public int GetSuccess1{
        get{return success1;}
        set{success1 = value;}
    }
}
