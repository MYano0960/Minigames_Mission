using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Minigame12{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField]List<GameObject> List_Buttons;
        [SerializeField]List<GameObject> List_Change_Point;
        [SerializeField]CanvasGroup CG_Buttons;

        private int index = -1;
        private bool isTouched = false;
        private bool isInteract = false;

        public void OnButtonTouch(){
            // 3色のボタンのどれかをタッチし、線路を切り換える。
            GameObject clickedObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            if (clickedObject != null){
                index = List_Buttons.IndexOf(clickedObject);
                ChangeRail(index);
                isTouched = true;
            } else {
                return;
            }
        }

        public void ChangeRail(int index){
            // ボタン入力直後、進行方向が切り替わる。
            float[] EndPos = new float[List_Change_Point.Count];
            EndPos = Array_ChoosedPos(index);
            for (int i=0;i<List_Change_Point.Count; i++){
                List_Change_Point[i].transform.localEulerAngles = new Vector3(0, 0, EndPos[i]);
            }
        }

        private float[] Array_ChoosedPos(int index){
            // 切り換えポイントの角度を進行方向に合わせて変更する。
            if (index == 0) return new float[] { 0, 24.0f };
            else if (index == 1) return new float[] { 0.0f, 0.0f };
            else return new float[] { -24.0f, 0 };
        }

        public async UniTask CheckTouched(CancellationToken token){
            // どれか1つのボタンをタッチすると列車が進む。
            while (!isTouched){
                if (token.IsCancellationRequested) return;
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        public void ResetTouched(){
            // 正解した場合入力されていない最初の状態に戻る。
            isTouched = false;
        }

        public void ChangeButtonInteract(){
            // ボタンにアタッチしたCanvasGroupのInteractableのオンオフを切り換える。
            isInteract = !isInteract;
            CG_Buttons.interactable = isInteract;
        }

        public int GetButtonNum(){
            // GameManagerクラスに入力されたボタンの情報を送る。
            return index;
        }
    }
}