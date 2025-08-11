using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int gameTime = 60;
    public static float gameTimer = 0f;
    private Text timerText;

    void Start() {
        gameTimer = gameTime;
        timerText = gameObject.GetComponent<Text>();
    }

    void Update() {
        gameTimer -= Time.deltaTime;

        if (gameTimer <= 0) {
            Time.timeScale = 0; // 사실 이걸로도 기능은 다함. 그러나 업데이트를 그만 사용하고 싶었다.
            timerText.text = $"TicTok! : {0}";
            this.enabled = false;
        }
        timerText.text = $"TicTok! : {Mathf.CeilToInt(gameTimer)}";
    }
}
