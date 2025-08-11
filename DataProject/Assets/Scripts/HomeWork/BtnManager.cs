using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour {
    public Text scoreText;
    public GameObject ScoreHighText;
    public GameObject TimeText;
    public Button againBtn;
    public Button stopBtn;
    void Start() {
        againBtn.onClick.AddListener(AgainTest);
        againBtn.onClick.AddListener(StopTest);
    }

    void AgainTest() {
        MouseRay.score = 0;
    }

    void StopTest() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 빌드 된 상황에선 게임 종료;
#endif
    }
    
    
}
