using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsCol2 : MonoBehaviour
{
    Rigidbody2D rb;

    private bool tableput;
    private bool holdjudge;
    private bool not_dupli;
    private static bool isQuitting = false;

    private int entry_goods2;
    private int gamefinjudge;

    Vector3 mygravity;

    Vector3 thisPosition;
    Vector3 worldPosition;
    Vector3 g_point2;

    public GameObject thisobj;

    private GameOverJudgeOmiyageE gameoverjudge;
    // Start is called before the first frame update
    void Start()
    {
        BoolSet();
        entry_goods2 = 0;

        rb = GetComponent<Rigidbody2D>();

        g_point2 = GameObject.Find("G_Point2").transform.position;

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
            entry_goods2 = 2;
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
                    Instantiate(thisobj, new Vector3(g_point2.x, g_point2.y, 0), Quaternion.identity);
                }
            }
        }
    }

    private void OnApplicationQuit(){
	    isQuitting = true;
    }

    public int GetEntry2{
        get{return entry_goods2;}
        set{entry_goods2 = value;}
    }
}
