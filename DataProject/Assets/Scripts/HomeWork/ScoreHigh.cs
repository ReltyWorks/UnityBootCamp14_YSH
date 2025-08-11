using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreHigh : MonoBehaviour {
    private Text scoreHighText;
    private int scoreHigh;

    void Start() {
        scoreHighText = GetComponent<Text>();
        scoreHigh = PlayerPrefs.GetInt("ScoreHigh", 0);
        scoreHighText.text = $"Score High : {scoreHigh}";
    }

    private void Update() {
        if (Timer.gameTimer <= 0) GameEnd();
    }

    public void GameEnd() {
        if (MouseRay.score > scoreHigh ) {
            scoreHigh = MouseRay.score;
            scoreHighText.text = $"Score High : {scoreHigh}";
            PlayerPrefs.SetInt("ScoreHigh", scoreHigh);
            PlayerPrefs.Save();
        }
    }
}
