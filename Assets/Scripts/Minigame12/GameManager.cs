using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine.UI;

namespace Minigame12{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]ButtonManager buttonManager;
        [SerializeField]TimeManager timeManager;
        [SerializeField]TrainManager trainManager;

        [SerializeField]List<CanvasGroup> List_CG_Star;
        [SerializeField]CanvasGroup CG_Clear;
        [SerializeField]CanvasGroup CG_Fail;

        private CancellationTokenSource cts;

        void Start(){
            ResetCancellationToken();
            GameProcess().Forget();
        }

        private void ResetCancellationToken(){
            // メモリリークを防ぐためにCancellationTokenを毎回リセットする。
            cts?.Cancel();
            cts?.Dispose();
            cts = new CancellationTokenSource();
        }

        public async UniTaskVoid GameProcess(){
            // ゲーム進行を管理する。
            const int countFinishNum = 3;
            bool isClear = true;

            for (int count = 0; count < countFinishNum; count++){
                // ボタン入力を3回行う。回が進むごとに制限時間が短くなる。
                ResetCancellationToken();
                int answerNum = UnityEngine.Random.Range(0, 3);
                await PrepareProcess(answerNum);
                ChangeGameMode();
                
                await UniTask.WhenAny(
                    // ボタン入力か制限時間に達した際に正解判定に移行する。
                    buttonManager.CheckTouched(cts.Token),
                    timeManager.Timer(count, cts.Token)
                );
                cts?.Cancel();

                ChangeGameMode();
                await UniTask.Delay(TimeSpan.FromSeconds(0.2));
                await MoveAnimation();
                await UniTask.Delay(TimeSpan.FromSeconds(0.5));
                List_CG_Star[count].alpha = 1;

                if (isCorrect(answerNum)) {
                    buttonManager.ResetTouched();
                    ResetCancellationToken();
                } else {
                    isClear = false;
                    break;
                }
            }

            if (isClear) CG_Clear.alpha = 1;
            else CG_Fail.alpha = 1;
        }

        private async UniTask PrepareProcess(int answerNum){
            trainManager.ShowAnswerTrain(answerNum);
            await trainManager.PrepareTrain();
        }

        private async UniTask MoveAnimation(){
            await trainManager.MovetoChangePoint();
            await trainManager.BranchTrainMove(buttonManager.GetButtonNum());
        }

        private void ChangeGameMode(){
            timeManager.ChangeTimeTextAlpha();
            buttonManager.ChangeButtonInteract();
        }

        private bool isCorrect(int answerNum){
            return buttonManager.GetButtonNum() == answerNum;
        }

        private void OnDestroy(){
            cts?.Cancel();
            cts?.Dispose();
        }
    }
}