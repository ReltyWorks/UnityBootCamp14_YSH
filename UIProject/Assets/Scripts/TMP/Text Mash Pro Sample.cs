using UnityEngine;
using TMPro;

public class TextMashProSample : MonoBehaviour {
    // TMP를 사용하는 UI 컴포넌트
    public TextMeshProUGUI textUI;

    private void Start() {
        textUI.text = "<size=150%>안녕하살법!</size>\n<s>이 말 취소</s>";
    } // <>안의 내용은 리치 텍스트라고 함!?
      // HTML 태그 같은 느낌 제공

    public void SetText(bool warning) {
        if (warning) {
            textUI.text = "<color=red><b>WARNING!!!</b></color>";
        }
        else {
            textUI.text = "<color=green>NORMAL</color>";
        }
    }
}


