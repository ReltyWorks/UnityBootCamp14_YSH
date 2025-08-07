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
        // �� �̵� ���ǻ��� : ���� ����Ƽ �����Ϳ��� ��� �Ǿ� �־�� �մϴ�.
        SceneManager.LoadScene("SampleScene");
    }
    private void RuleView() {
        // ruleUI.SetActive(true); // ������Ʈ���� �̹� ������
    }
    private void GameExit() { // ��ó���� �ڵ�� �� �״�� ��(����)�� ó���϶�� �ڵ��
#if UNITY_EDITOR // ��ó���� �ڵ�� ���������� �Ʒ��� ���� �鿩���⸦ ó������ ����
        // EditorApplication.Exit(0); // ������ ����
        EditorApplication.isPlaying = false; // �׽�Ʈ ������ �����.
#else
        Application.Quit(); // ���� �� ��Ȳ���� ���� ����;
#endif
    }
}
