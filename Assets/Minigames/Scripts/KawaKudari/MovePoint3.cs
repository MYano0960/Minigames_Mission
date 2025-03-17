using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint3 : MonoBehaviour
{
    private int mousepoint3 = 0;

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
        mousepoint3 = 1;
    }

    void OnMouseExit()
    {
        mousepoint3 = 0;
    }

    public int GetClickJudge3{
        get{return mousepoint3;}
        set{mousepoint3 = value;}
    }
}
