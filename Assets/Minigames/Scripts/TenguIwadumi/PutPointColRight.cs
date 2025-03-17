using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPointColRight : MonoBehaviour
{
    Rigidbody2D rb;

    private int touch_wall_right;

    private Vector3 pos;
    private Vector3 putpoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        touch_wall_right = 0;

        putpoint = GameObject.Find("PutPoint").transform.position;
        pos = this.transform.position;
        pos.y = putpoint.y;
        this.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        putpoint = GameObject.Find("PutPoint").transform.position;

        pos.x = putpoint.x + 3.5f;
        this.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2"){
            touch_wall_right = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2"){
            touch_wall_right = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2"){
            touch_wall_right = 0;
        }
    }

    public int GetPutColRight{
        get{return touch_wall_right;}
        set{touch_wall_right = value;}
    }
}
