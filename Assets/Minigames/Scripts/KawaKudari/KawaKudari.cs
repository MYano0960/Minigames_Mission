using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KawaKudari : MonoBehaviour
{
    private int gameover;

    private float gametime;
    private const float gameFinTime = 10.0f;
    private float generateTime, generateFinTime;

    [SerializeField]private List<GameObject> Boat, Swan;
    [SerializeField]private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        gametime = 0;
        generateTime = 0;
        generateFinTime = Random.Range(3.0f, 5.0f);
        gameover = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gametime += Time.deltaTime;
        if (!TimeOver()){
            if (generateTime >= generateFinTime){
                generateTime = 0;
                generateFinTime = Random.Range(5.0f, 10.0f);
            }
        } else {
            if (GameContinue()){
                gameover = 0;
            }
        }
    }

    public void OnButtonClick(){
        if (GameContinue()){
            GameObject clickedObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            this.transform.position = new Vector2(260.0f, clickedObject.transform.position.y + 50.0f);
        }
    }

    private bool TimeOver(){
        if (gametime >= gameFinTime){
            return true;
        }
        return false;
    }

    private bool GameContinue(){
        if (gameover == -1){
            return true;
        }
        return false;
    }

    private void ImageInstant(){
        // GameObject prefab = (GameObject)Instantiate();
        // prefab.transform.SetParent(canvas.transform, false); 
    }

    private void OnTriggerEnter2D(Collider2D col){
        // if (col.gameObject){

        // }
    }
}
