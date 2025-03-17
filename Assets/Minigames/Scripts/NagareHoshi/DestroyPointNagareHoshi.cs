using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointNagareHoshi : MonoBehaviour
{
    private int correct_sum;
    // Start is called before the first frame update
    void Start()
    {
        correct_sum = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Star1(Clone)" || col.gameObject.name == "Star7(Clone)" || col.gameObject.name == "Star8(Clone)" || col.gameObject.name == "Star9(Clone)" || col.gameObject.name == "Star10(Clone)"){
            correct_sum += 1;
        } else if (col.gameObject.name == "Star2(Clone)" || col.gameObject.name == "Star3(Clone)"){
            correct_sum += 3;
        } else if (col.gameObject.name == "Star4(Clone)" || col.gameObject.name == "Star5(Clone)" || col.gameObject.name == "Star6(Clone)"){
            correct_sum += 5;
        }
        Destroy(col.gameObject);
    }

    public int GetCorrectNum{
        get{return correct_sum;}
        set{correct_sum = value;}
    }
}
