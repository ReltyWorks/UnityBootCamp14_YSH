using UnityEngine;
using UnityEngine.UI;

// Ű�� �Է��ϸ� �ؽ�Ʈ�� Ư�� �޼����� �������� �ϴ� �ڵ�

public class LegacyExample : MonoBehaviour {

    public Text text;

    KeyCode key;

    private void Start() {
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        //�⺻���� Ȱ��!
        //if (Input.GetKeyDown(KeyCode.Space)) { // Space Ű
        //    text.text = "pata";
        //}
        //if (Input.GetKeyDown(KeyCode.Return)) { // Enter Ű
        //    text.text = "pong";
        //}
        //if (Input.GetKeyDown(KeyCode.Escape)) { // ESC Ű
        //    text.text = "";
        //}

        // KeyCode ������ ������ ��ü�� �����մϴ�.
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(key)) {
                switch (key) { // �̳Ѱ� ����ġ�� �� ��︲
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
