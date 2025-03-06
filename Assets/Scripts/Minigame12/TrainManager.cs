using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine.UI;

namespace Minigame12{
    public class TrainManager : MonoBehaviour
    {
        [SerializeField] List<CanvasGroup> List_CG_Train;
        [SerializeField] GameObject Obj_Train;
        [SerializeField] List<Transform> List_Tf_MovePoint_Up;
        [SerializeField] List<Transform> List_Tf_MovePoint_Down;

        public void ShowAnswerTrain(int answerNum){
            for (int i=0; i<List_CG_Train.Count; i++){
                if (i == answerNum) List_CG_Train[i].alpha = 1;
                else List_CG_Train[i].alpha = 0;
            }
        }

        public async UniTask PrepareTrain(){
            const float StartPos = -1200f;
            const float len = 900.0f;
            const float waitFinTime = 0.8f;
            float waitTime = 0;
            Obj_Train.transform.localPosition = new Vector2(StartPos, 0);
            Obj_Train.transform.eulerAngles = new Vector3(0, 0, 0);
            while (waitTime < waitFinTime){
                await UniTask.Yield(PlayerLoopTiming.Update);
                waitTime += Time.deltaTime;
                Obj_Train.transform.localPosition = new Vector2(StartPos+(len/waitFinTime)*waitTime, 232f);
            }
            await UniTask.Delay(TimeSpan.FromSeconds(0.5));
        }

        public async UniTask MovetoChangePoint(){
            const float endPos = 350.0f;
            const float waitFinTime = 0.5f;
            float waitTime = 0;
            Vector3 StartPos = Obj_Train.transform.localPosition;
            float len = endPos - StartPos.x;
            while (waitTime < waitFinTime){
                await UniTask.Yield(PlayerLoopTiming.Update);
                waitTime += Time.deltaTime;
                Obj_Train.transform.localPosition = new Vector2(StartPos.x + (len/waitFinTime)*waitTime, 232f); 
            }
        }

        public async UniTask BranchTrainMove(int index){
            if (index == 1){
                await MoveStraight();
            } else {
                bool isMoveUp;
                if (index == 0) isMoveUp = true;
                else isMoveUp = false;
                await MoveCurved(isMoveUp);
            }
        }

        private async UniTask MoveStraight(){
            const float endPos = 1300.0f;
            const float waitFinTime = 0.5f;
            float waitTime = 0;
            Vector3 StartPos = Obj_Train.transform.localPosition;
            float len = endPos - StartPos.x;
            while (waitTime < waitFinTime){
                await UniTask.Yield(PlayerLoopTiming.Update);
                waitTime += Time.deltaTime;
                Obj_Train.transform.localPosition = new Vector2(StartPos.x + (len/waitFinTime)*waitTime, 232f); 
            }
        }

        private async UniTask MoveCurved(bool isMoveUp){
            List<Transform> List_MovePoint = new List<Transform>();
            const float waitFinTime = 0.5f/6.0f;
            if (isMoveUp) List_MovePoint = List_Tf_MovePoint_Up;
            else List_MovePoint = List_Tf_MovePoint_Down;

            for (int i=0; i<List_MovePoint.Count; i++){
                float waitTime = 0;
                Vector2 startPos = Obj_Train.transform.localPosition;
                Vector2 endPos = List_MovePoint[i].localPosition;
                float angle = Mathf.Atan2(endPos.y - startPos.y, endPos.x - startPos.x) * Mathf.Rad2Deg;

                while (waitTime < waitFinTime){
                    await UniTask.Yield(PlayerLoopTiming.Update);
                    waitTime += Time.deltaTime;
                    float t = waitTime / waitFinTime;
                    Obj_Train.transform.localPosition = Vector2.Lerp(startPos, endPos, t);
                    Obj_Train.transform.eulerAngles = new Vector3(0, 0, angle);
                }
                Obj_Train.transform.localPosition = endPos;
                Obj_Train.transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
}