using UnityEngine;
using UnityEngine.UI;

// 키를 입력하면 텍스트에 특정 메세지가 나오도록 하는 코드

public class LegacyExample : MonoBehaviour {

    public Text text;

    KeyCode key;

    private void Start() {
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        //기본적인 활용!
        //if (Input.GetKeyDown(KeyCode.Space)) { // Space 키
        //    text.text = "pata";
        //}
        //if (Input.GetKeyDown(KeyCode.Return)) { // Enter 키
        //    text.text = "pong";
        //}
        //if (Input.GetKeyDown(KeyCode.Escape)) { // ESC 키
        //    text.text = "";
        //}

        // KeyCode 형태의 데이터 전체를 조사합니다.
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(key)) {
                switch (key) { // 이넘과 스위치는 잘 어울림
                    case KeyCode.Escape:
                        text.text = "";
                        break;
                    case KeyCode.Space:
                        text.text = "pata";
                        break;
                    case KeyCode.Return:
                        text.text = "pong";
                        break;
                }
            }
        }
    }
}
