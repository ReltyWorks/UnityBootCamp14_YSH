using UnityEngine;
using TMPro;

public class TextMashProSample : MonoBehaviour {
    // TMP�� ����ϴ� UI ������Ʈ
    public TextMeshProUGUI textUI;

    private void Start() {
        textUI.text = "<size=150%>�ȳ��ϻ��!</size>\n<s>�� �� ���</s>";
    } // <>���� ������ ��ġ �ؽ�Ʈ��� ��!?
      // HTML �±� ���� ���� ����

    public void SetText(bool warning) {
        if (warning) {
            textUI.text = "<color=red><b>WARNING!!!</b></color>";
        }
        else {
            textUI.text = "<color=green>NORMAL</color>";
        }
    }
}


