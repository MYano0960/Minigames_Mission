using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointIwadumi : MonoBehaviour
{
    private int gamefail1;
    private int gamefail2;
    // Start is called before the first frame update
    void Start()
    {
        gamefail1 = 0;
        gamefail2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name == "Rock1_1" || col.gameObject.name == "Rock1_2" || col.gameObject.name == "Rock1_3"){
            gamefail1 = 1;
        } else if (col.gameObject.name == "Rock2_1" || col.gameObject.name == "Rock2_2" || col.gameObject.name == "Rock2_3"){
            gamefail2 = 1;
        }
        Destroy(col.gameObject);
    }

    public int GetGameFail1{
        get{return gamefail1;}
        set{gamefail1 = value;}
    }

    public int GetGameFail2{
        get{return gamefail2;}
        set{gamefail2 = value;}
    }
}

