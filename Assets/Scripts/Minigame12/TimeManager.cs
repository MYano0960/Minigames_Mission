using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using TMPro;

namespace Minigame12{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField]TextMeshProUGUI TextTime;
        [SerializeField]CanvasGroup CG_TextTime;

        private float alpha_TextTime = 0f;
        private float GameTime;
        private float[] canClickTime = {3.0f, 2.0f, 1.0f};

        public async UniTask Timer(int index, CancellationToken token){
            // ボタンの入力のための制限時間を管理する。
            GameTime = canClickTime[index];

            while (GameTime > 0){
                if (token.IsCancellationRequested) return;

                await UniTask.Yield(PlayerLoopTiming.Update, token);
                GameTime -= Time.deltaTime;
                TextTime.text = GameTime.ToString("F0");
            }
        }

        public void ChangeTimeTextAlpha(){
            alpha_TextTime = 1 - alpha_TextTime;
            CG_TextTime.alpha = alpha_TextTime;
        }
    }
}