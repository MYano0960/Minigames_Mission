using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnkiUeki : MonoBehaviour
{
    private bool[] answer;
    private int gameover;
    private int thisButtonNum;

    private float gametime;
    private float resultTime;
    private const float gameStartTime = 1.0f;
    private const float gameFinTime = 6.0f;

    private Image[] Img_button;
    private List<int> answer_num = new List<int>();
    [SerializeField]private List<Button> Block;
    [SerializeField]private List<GameObject> button_array;
    [SerializeField]private List<GameObject> Tree, Result;
    [SerializeField]private TimeUI timeUI;
    [SerializeField]private AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        gametime = 0;
        resultTime = 0;
        gameover = -1;
        thisButtonNum = -1;
        answer = new bool[9];
        Img_button = new Image[9];
        for (int i=0;i<answer.Length;i++){
            answer[i] = true;
            Tree[i].SetActive(false);
            Img_button[i] = Block[i].GetComponent<Image>();
        } 

        for (int i=0;i<Result.Count;i++){
            Result[i].SetActive(false);
        }

        StartCoroutine(AnswerProcess());
    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;
        GameProcess();
        GameFinish();
    }

    public void OnButtonClick(){
        GameObject clickedObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        thisButtonNum = button_array.IndexOf(clickedObject.gameObject);
    }

    private void GameProcess(){
        if (GameStart()){
            timeUI.enabled = true;
            for (int i=0;i<answer.Length;i++){
                ButtonColoring(i, 1.0f);
            }

            if (ButtonClick()){
                if (CorrectClick()){
                    answer[thisButtonNum] = true;
                    Tree[thisButtonNum].SetActive(true);
                    SE.PlayOneShot(SE.clip);
                    thisButtonNum = -1;
                } else {
                    gameover = 1;
                }
            } else {
                if (GameClear()){
                    gameover = 0;
                } else if (TimeOver()){
                    gameover = 1;
                }
            }
        } else {
            timeUI.enabled = false;
            for (int i=0;i<answer.Length;i++){
                ButtonColoring(i, 0);
            }
        }
    }

    private bool GameStart(){
        if (gametime >= gameStartTime){
            return true;
        }
        return false;
    }

    private bool ButtonClick(){
        if (thisButtonNum != -1 && gameover == -1){
            return true;
        }
        return false;
    }

    private bool CorrectClick(){
        if (!answer[thisButtonNum]){
            return true;
        }
        return false;
    }

    private bool GameClear(){
        if (answer[0] && answer[1] && answer[2] && answer[3] && answer[4] && answer[5] && answer[6] && answer[7] && answer[8]){
            return true;
        }
        return false;
    }

    private bool TimeOver(){
        if (gametime >= gameFinTime){
            return true;
        }
        return false;
    }

    private void ButtonColoring(int i, float color_num){
        if (!answer[i]){
            Img_button[i].color = new Color(color_num, color_num, color_num, 1.0f);    
        }
    }

    private void GameFinish(){
        if (GameFinishJudge()){
            if (resultTime == 0){
                resultTime = gametime;
            }

            timeUI.enabled = false;
            if (gametime >= resultTime + 1.0f){
                Result[gameover].SetActive(true);
                if (gameover == 1){
                    for (int i=0;i<answer.Length;i++){
                        Tree[i].SetActive(false);
                    }
                }
            }
        }
    }

    private bool GameFinishJudge(){
        if (gameover == 0 || gameover == 1){
            return true;
        }
        return false;
    }

    private IEnumerator AnswerProcess(){
        int answer_sum;
        int count = 0;
        answer_sum = Random.Range(4, 6);
        while (count < answer_sum){
            int rand_answer = Random.Range(0, 9);
            if (answer[rand_answer]){
                answer[rand_answer] = false;
                answer_num.Add(rand_answer);
                count++;
            }
            yield return null;
        }
    }
}
