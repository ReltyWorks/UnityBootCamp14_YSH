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
            Time.timeScale = 0; // ��� �̰ɷε� ����� ����. �׷��� ������Ʈ�� �׸� ����ϰ� �;���.
            timerText.text = $"TicTok! : {0}";
            this.enabled = false;
        }
        timerText.text = $"TicTok! : {Mathf.CeilToInt(gameTimer)}";
    }
}
