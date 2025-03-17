using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint2 : MonoBehaviour
{
    private int mousepoint2 = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        mousepoint2 = 1;
    }

    void OnMouseExit()
    {
        mousepoint2 = 0;
    }

    public int GetClickJudge2{
        get{return mousepoint2;}
        set{mousepoint2 = value;}
    }
}
