using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguMove : MonoBehaviour
{
    Rigidbody2D rb;

    private bool wall1_touch;
    private bool wall2_touch;

    private Vector3 pos;

    private Vector3 return_point1;
    private Vector3 return_point2;

    Vector3 thisPosition;
    Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        wall1_touch = false;
        wall2_touch = false;

        return_point1 = GameObject.Find("R_Point1").transform.position;
        return_point2 = GameObject.Find("R_Point2").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;
        WallTouch();
    }

    public void WallTouch(){
        if (wall1_touch){
            pos = return_point1;
            this.transform.position = pos;
        } else if (wall2_touch){
            pos = return_point2;
            this.transform.position = pos;
        }
    }

    void OnMouseDrag()
    {
        if (!wall1_touch && !wall2_touch){
            thisPosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
            worldPosition.y = this.transform.position.y;
            worldPosition.z = 0;
            this.transform.position = worldPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name == "Wall1"){
            wall1_touch = true;
        } else if (col.gameObject.name == "Wall2"){
            wall2_touch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) 
    {
        if (col.gameObject.name == "Wall1"){
            wall1_touch = false;
        } else if (col.gameObject.name == "Wall2"){
            wall2_touch = false;
        }
    }

    public float GetTenguPosX{
        get{return pos.x;}
        set{pos.x = value;}
    }
}
