using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    Rigidbody2D rb;

    private float random_velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        random_velocity = Random.Range(8.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject != null){
            rb.linearVelocity = new Vector3 (random_velocity * - 1.0f, random_velocity * - 1.0f, 0);
        } else if (this.gameObject == null){
            rb.linearVelocity = new Vector3 (0, 0, 0);
        }
    }
}
