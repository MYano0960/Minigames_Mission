using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPointPos : MonoBehaviour
{
    private Vector3 pos;

    private int rock_generate1;
    private int rock_generate2;

    private float putpoint_pos_x;

    private RockPut rockput;
    private PutPoint putpoint;
    // Start is called before the first frame update
    void Start()
    {
        this.putpoint = FindObjectOfType<PutPoint>();
        this.rockput = FindObjectOfType<RockPut>();
    }

    // Update is called once per frame
    void Update()
    {
        putpoint_pos_x = putpoint.GetPutPointPosX;
        rock_generate1 = rockput.GetRockGenerate1;
        rock_generate2 = rockput.GetRockGenerate2;

        if (rock_generate1 == 1){
            if (rock_generate2 == 1){
                pos.x = putpoint_pos_x + 1.8f;
                pos.y = -1.95f;
            } else if (rock_generate2 == 2){
                pos.x = putpoint_pos_x + 1.8f;
                pos.y = -1.95f;
            } else if (rock_generate2 == 3){
                pos.x = putpoint_pos_x + 1.8f;
                pos.y = -1.95f;
            }
        } else if (rock_generate1 == 2){
            pos.x = putpoint_pos_x + 1.5f;
            pos.y = -2.3f;
        } else if (rock_generate1 == 3){
            if (rock_generate2 == 1){
                pos.x = putpoint_pos_x - 0.5f;
                pos.y = -2.2f;
            } else if (rock_generate2 == 2){
                pos.x = putpoint_pos_x - 1.2f;
                pos.y = -2.3f;
            } else if (rock_generate2 == 3){
                pos.x = putpoint_pos_x - 1.6f;
                pos.y = -2.55f;
            }
        }
        this.transform.position = pos;
    }
}
