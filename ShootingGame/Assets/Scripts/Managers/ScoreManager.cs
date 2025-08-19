using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public TMP_Text scoreText;
    private int score;

    public static ScoreManager Instance = null;

    private void Awake() {
        if(Instance == null) Instance = this;
    }

    public void SetScore(int value) {
        score += value;
        SetScoreText(score);

        if (score > FileManager.Instance.GetBest()) {
            FileManager.Instance.SetBest(score);
        }
    }

    private void SetScoreText(int score) => scoreText.text = $"Score : {score}";
    public int GetScore() => score;
}
