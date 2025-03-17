using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureJudge : MonoBehaviour
{
    [SerializeField] List<GameObject> Makie;
    [SerializeField] List<GameObject> MihonMakie;

    private int[] makie_num = new int[9];
    private float[] makie_rotation = new float[9];

    private int random_picture_sel;
    private int random_makie_rotate_sum;
    private int random_makie_sel;
    private int random_rotate_num;

    private int gameclear;

    private MakieCol makiecol;
    // Start is called before the first frame update
    void Start()
    {
        InitialSet();
        RotateMakieSel();
        MakieRotate();

        this.makiecol = FindObjectOfType<MakieCol>();
    }

    // Update is called once per frame
    void Update()
    {
        GameClearJudge();
    }

    public void InitialSet(){
        random_picture_sel = Random.Range(0, 2);
        gameclear = 0;

        MihonShowJudge();

        for (int i = 0; i <= 8; ++i){
            makie_num[i] = 0;
        }
    }

    public void RotateMakieSel(){
        random_makie_rotate_sum = Random.Range(1, 4);

        if (random_makie_rotate_sum == 1){
            random_makie_sel = Random.Range(0, 9);
            makie_num[random_makie_sel] = 1;
        } else {
            for (int i = 1; i <= random_makie_rotate_sum; ++i){
                StartCoroutine(MakieDecision());
            }
        }
    }

    public void MakieRotate(){
        for (int i = 0; i <= 8; ++i){
            if (makie_num[i] == 1){
                random_rotate_num = Random.Range(1, 4);
                Makie[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 90 * random_rotate_num);
            } else {
                Makie[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    public void MihonShowJudge(){
        if (random_picture_sel == 0){
            MihonMakie[0].gameObject.SetActive(true);
            MihonMakie[1].gameObject.SetActive(false);
        } else if (random_picture_sel == 1){
            MihonMakie[0].gameObject.SetActive(false);
            MihonMakie[1].gameObject.SetActive(true);
        }
    }

    public void GameClearJudge(){
        makie_num = makiecol.GetMakieCorrectNumRe;
        if (makie_num[0] == 0 && makie_num[1] == 0 && makie_num[2] == 0 && makie_num[3] == 0 && makie_num[4] == 0 && makie_num[5] == 0 && makie_num[6] == 0 && makie_num[7] == 0 && makie_num[8] == 0){
            gameclear = 1;
        }
    }

    IEnumerator MakieDecision(){
        random_makie_sel = Random.Range(0, 9);
        while (makie_num[random_makie_sel] == 1){
            random_makie_sel = Random.Range(0, 9);
        }
        makie_num[random_makie_sel] = 1;
        yield break;
    }

    public int[] GetMakieCorrectNum{
        get{return makie_num;}
        set{makie_num = value;}
    }

    public int GetPictKind{
        get{return random_picture_sel;}
        set{random_picture_sel = value;}
    }

    public int GetGameClear{
        get{return gameclear;}
        set{gameclear = value;}
    }
}
