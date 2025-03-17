using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakieCol : MonoBehaviour
{
    [SerializeField] List<GameObject> PictKind;

    private int[] makie_num = new int[9];

    private int random_picture_sel;
    private int correct_makie;

    private bool pict_sel_once;
    private bool makie_answer_set_once;
    private bool mouse_point;

    public GameObject thisobj;

    public PictureJudge picturejudge;
    // Start is called before the first frame update
    void Start()
    {
        pict_sel_once = false;
        makie_answer_set_once = false;
        correct_makie = 0;
    }

    // Update is called once per frame
    void Update()
    {
        random_picture_sel = picturejudge.GetPictKind;
        makie_num = picturejudge.GetMakieCorrectNum;

        PictKindSel();
        AnswerSet();
        RotateMakie();
        CorrectAnswerJudge();
    }

    public void PictKindSel(){
        if (!pict_sel_once){
            if (random_picture_sel == 0){
                PictKind[0].gameObject.SetActive(true);
                PictKind[1].gameObject.SetActive(false);
            } else if (random_picture_sel == 1){
                PictKind[0].gameObject.SetActive(false);
                PictKind[1].gameObject.SetActive(true);
            }
            pict_sel_once = true;
        }
    }

    public void AnswerSet(){
        if (!makie_answer_set_once){
            if ((makie_num[0] == 1 && thisobj.name == "Makie1") || (makie_num[1] == 1 && thisobj.name == "Makie2") || (makie_num[2] == 1 && thisobj.name == "Makie3") || (makie_num[3] == 1 && thisobj.name == "Makie4") || (makie_num[4] == 1 && thisobj.name == "Makie5") || (makie_num[5] == 1 && thisobj.name == "Makie6") ||(makie_num[6] == 1 && thisobj.name == "Makie7") || (makie_num[7] == 1 && thisobj.name == "Makie8") || (makie_num[8] == 1 && thisobj.name == "Makie9")){
                correct_makie = 1;
            }
            makie_answer_set_once = true;
        }
    }

    public void RotateMakie(){
        if (Input.GetMouseButtonDown(0) && mouse_point){
            if (correct_makie == 1){
                thisobj.gameObject.transform.eulerAngles += new Vector3(0, 0, 90);
            } else {
                thisobj.gameObject.transform.eulerAngles += new Vector3(0, 0, 0);
            }
        }
    }

    public void CorrectAnswerJudge(){
        if (correct_makie == 1 && thisobj.transform.localEulerAngles.z < 90.0f){
            correct_makie = 0;
            switch (thisobj.name){
                case "Makie1":
                    makie_num[0] = 0;
                    break;
                case "Makie2":
                    makie_num[1] = 0;
                    break;
                case "Makie3":
                    makie_num[2] = 0;
                    break;
                case "Makie4":
                    makie_num[3] = 0;
                    break;
                case "Makie5":
                    makie_num[4] = 0;
                    break;
                case "Makie6":
                    makie_num[5] = 0;
                    break;
                case "Makie7":
                    makie_num[6] = 0;
                    break;
                case "Makie8":
                    makie_num[7] = 0;
                    break;
                case "Makie9":
                    makie_num[8] = 0;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnMouseEnter(){
        mouse_point = true;
    }

    private void OnMouseExit(){
        mouse_point = false;
    }

    public int[] GetMakieCorrectNumRe{
        get{return makie_num;}
        set{makie_num = value;}
    }
}
