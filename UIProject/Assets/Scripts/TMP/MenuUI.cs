using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {
    public Button startButton;
    public Button ruleButton;
    public Button exitButton;

    public GameObject ruleUI;

    private void Start() {
        startButton.onClick.AddListener(GameStart);
        ruleButton.onClick.AddListener(RuleView);
        exitButton.onClick.AddListener(GameExit);
    }
    private void GameStart() {
        // 씬 이동 유의사항 : 씬이 유니티 에디터에서 등록 되어 있어야 합니다.
        SceneManager.LoadScene("SampleScene");
    }
    private void RuleView() {
        // ruleUI.SetActive(true); // 컴포넌트에서 이미 구현함
    }
    private void GameExit() { // 전처리기 코드는 말 그대로 전(먼저)에 처리하라는 코드다
#if UNITY_EDITOR // 전처리기 코드는 관례적으로 아래와 같이 들여쓰기를 처음부터 시작
        // EditorApplication.Exit(0); // 에디터 꺼짐
        EditorApplication.isPlaying = false; // 테스트 실행을 멈춘다.
#else
        Application.Quit(); // 빌드 된 상황에선 게임 종료;
#endif
    }
}
