using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint1 : MonoBehaviour
{
    private int mousepoint1 = 0;

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
        mousepoint1 = 1;
    }

    void OnMouseExit()
    {
        mousepoint1 = 0;
    }

    public int GetClickJudge1{
        get{return mousepoint1;}
        set{mousepoint1 = value;}
    }
}
