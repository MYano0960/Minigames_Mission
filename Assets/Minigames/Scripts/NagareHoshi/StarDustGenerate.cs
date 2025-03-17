using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDustGenerate : MonoBehaviour
{
    [SerializeField] List<GameObject> Star;
    [SerializeField] List<GameObject> Dummy;

    private int random_generate;
    private int dummy_random_generate;

    private bool start_judge;

    private float wait_time;
    private float wait_fintime;
    private float dum_wait_time;
    private float dum_wait_fintime;

    private Vector3 g_pos;

    public GameObject generate_point;
    // Start is called before the first frame update
    void Start()
    {
        wait_fintime = 500.0f;
        dum_wait_fintime = 300.0f;

        start_judge = false;
        dummy_random_generate = 8; 

        g_pos = generate_point.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StarGenerate();
        DummyGenerate();
    }

    public void StarGenerate(){
        StartCoroutine(WaitTime());
        if (wait_time >= wait_fintime){
            random_generate = Random.Range(0, 10);
            Instantiate(Star[random_generate], new Vector3(g_pos.x, g_pos.y, g_pos.z), Quaternion.identity);
            wait_time = 0;
            wait_fintime = Random.Range(600.0f, 800.0f);
            start_judge = true;
        }
    }

    public void DummyGenerate(){
        if (start_judge){
            StartCoroutine(DummyWaitTime());
            if (dum_wait_time >= dum_wait_fintime){
                if (dummy_random_generate <= 2){
                    Instantiate(Dummy[dummy_random_generate], new Vector3(g_pos.x, g_pos.y, g_pos.z), Quaternion.identity);
                }
                dum_wait_time = 0;
                dum_wait_fintime = Random.Range(250.0f, 400.0f);
                dummy_random_generate = Random.Range(0, 8);
            }
        }
    }

    IEnumerator WaitTime(){
        while (wait_time < wait_fintime){
            wait_time += 0.01f;
            yield return null;
        }
    }

    IEnumerator DummyWaitTime(){
        while (dum_wait_time < dum_wait_fintime){
            dum_wait_time += 0.01f;
            yield return null;
        }
    }
}
