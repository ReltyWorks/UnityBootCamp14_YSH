using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {
    public Button startBtn;
    public Button quitBtn;

    private void Start() {
        startBtn.onClick.AddListener(GameStart);
        quitBtn.onClick.AddListener(GameExit);
    }

    private void GameStart() {
        SceneManager.LoadScene("QuizScene");
    }
    private void GameExit() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // 테스트 실행을 멈춘다.
#else
        Application.Quit(); // 빌드 된 상황에선 게임 종료;
#endif
    }
}