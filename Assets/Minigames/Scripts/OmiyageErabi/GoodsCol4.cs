using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsCol4 : MonoBehaviour
{
    Rigidbody2D rb;

    private bool tableput;
    private bool holdjudge;
    private bool not_dupli;
    private static bool isQuitting = false;

    private int entry_goods4;
    private int gamefinjudge;

    Vector3 mygravity;

    Vector3 thisPosition;
    Vector3 worldPosition;
    Vector3 g_point4;

    public GameObject thisobj;

    private GameOverJudgeOmiyageE gameoverjudge;
    // Start is called before the first frame update
    void Start()
    {
        BoolSet();
        entry_goods4 = 0;

        rb = GetComponent<Rigidbody2D>();

        g_point4 = GameObject.Find("G_Point4").transform.position;

        this.gameoverjudge = FindObjectOfType<GameOverJudgeOmiyageE>();
    }

    public void BoolSet(){
        tableput = true;
        holdjudge = false;
        not_dupli = false;
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
            entry_goods4 = 4;
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
                    Instantiate(thisobj, new Vector3(g_point4.x, g_point4.y, 0), Quaternion.identity);
                }
            }
        }
    }

    private void OnApplicationQuit(){
	    isQuitting = true;
    }

    public int GetEntry4{
        get{return entry_goods4;}
        set{entry_goods4 = value;}
    }
}
