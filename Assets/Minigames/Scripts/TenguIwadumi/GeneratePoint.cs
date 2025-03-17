using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePoint : MonoBehaviour
{
    private Vector3 pos;

    private float player_pos_x;

    private TenguMove tengumove;
    // Start is called before the first frame update
    void Start()
    {
        this.tengumove = FindObjectOfType<TenguMove>();
    }

    // Update is called once per frame
    void Update()
    {
        player_pos_x = tengumove.GetTenguPosX;
        pos.x = player_pos_x;
        this.transform.position = pos;
    }
}
