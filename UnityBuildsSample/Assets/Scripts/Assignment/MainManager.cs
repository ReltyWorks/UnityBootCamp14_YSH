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
        EditorApplication.isPlaying = false; // �׽�Ʈ ������ �����.
#else
        Application.Quit(); // ���� �� ��Ȳ���� ���� ����;
#endif
    }
}