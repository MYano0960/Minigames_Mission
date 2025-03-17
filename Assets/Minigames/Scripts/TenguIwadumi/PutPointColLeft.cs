using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPointColLeft : MonoBehaviour
{
    Rigidbody2D rb;

    private int touch_wall_left;

    private Vector3 pos;
    private Vector3 putpoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        touch_wall_left = 0;

        putpoint = GameObject.Find("PutPoint").transform.position;
        pos = this.transform.position;
        pos.y = putpoint.y;
        this.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        putpoint = GameObject.Find("PutPoint").transform.position;

        pos.x = putpoint.x - 3.5f;
        this.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2"){
            touch_wall_left = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2"){
            touch_wall_left = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2"){
            touch_wall_left = 0;
        }
    }

    public int GetPutColLeft{
        get{return touch_wall_left;}
        set{touch_wall_left = value;}
    }
}
