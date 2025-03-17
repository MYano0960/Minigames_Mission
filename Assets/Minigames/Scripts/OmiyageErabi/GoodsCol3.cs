using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsCol3 : MonoBehaviour
{
    Rigidbody2D rb;

    private bool tableput;
    private bool holdjudge;
    private bool not_dupli;
    private static bool isQuitting = false;

    private int entry_goods3;
    private int gamefinjudge;

    Vector3 mygravity;

    Vector3 thisPosition;
    Vector3 worldPosition;
    Vector3 g_point3;

    public GameObject thisobj;

    private GameOverJudgeOmiyageE gameoverjudge;
    // Start is called before the first frame update
    void Start()
    {
        BoolSet();
        entry_goods3 = 1;

        rb = GetComponent<Rigidbody2D>();

        g_point3 = GameObject.Find("G_Point3").transform.position;

        this.gameoverjudge = FindObjectOfType<GameOverJudgeOmiyageE>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gamefinjudge = gameoverjudge.GetGameFinJudge;
        
        if (tableput && !holdjudge){
            mygravity = new Vector3(0, 9.81f, 0);
            rb.AddForce(mygravity);
        } else {
            mygravity = new Vector3(0, - 9.81f, 0);
            rb.AddForce(mygravity);
        }
    }

    public void BoolSet(){
        tableput = true;
        holdjudge = false;
        not_dupli = false;
    }

    void OnMouseDrag()
    {
        if (gamefinjudge == 0){
            thisPosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
            worldPosition.z = 0f;
            this.transform.position = worldPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name == "Table" && !holdjudge){
            rb.linearVelocity = new Vector2(0, 0);
            tableput = true;
        } else if (col.gameObject.name == "Table" && holdjudge){
            not_dupli = true;
        } else if (col.gameObject.name == "Box"){
            entry_goods3 = 3;
            Destroy(thisobj);
        }
    }

    private void OnTriggerStay2D(Collider2D col) 
    {
        if (col.gameObject.name == "Table" && !holdjudge){
            rb.linearVelocity = new Vector2(0, 0);
            tableput = true;
        } else if (col.gameObject.name == "Table" && holdjudge){
            not_dupli = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) 
    {
        if (col.gameObject.name == "Table"){
            rb.linearVelocity = new Vector2(0, 0);
            tableput = false;
            holdjudge = true;
            if (!not_dupli){
                if (!isQuitting){
                    Instantiate(thisobj, new Vector3(g_point3.x, g_point3.y, 0), Quaternion.identity);
                }
            }
        }
    }

    private void OnApplicationQuit(){
	    isQuitting = true;
    }

    public int GetEntry3{
        get{return entry_goods3;}
        set{entry_goods3 = value;}
    }
}
