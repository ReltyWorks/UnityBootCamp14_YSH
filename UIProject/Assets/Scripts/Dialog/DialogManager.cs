using System;
using System.Collections; // �̳ʸӷ�����
using System.Collections.Generic; // ť
using System.Text; // ��Ʈ�� ���� ����
using TMPro; // �ظ���
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Dialog {
    public string character;
    public string content;

    public Dialog(string character, string content) {
        this.character = character;
        this.content = content;
    } // ��� ������ �ߺ�, ������
}

public class DialogManager : MonoBehaviour {

    #region MonoSingleton
    // 1) �ڱ� �ڽſ� ���� �ν��Ͻ��� ������. (����)
    public static DialogManager Instance { get; private set; } // ������Ƽ
    // Instance�� ���� ���� �� �ֽ��ϴ�.(���� ����)
    // ������ �� �� �����ϴ�.
    // �̸��� �ظ��ϸ� �ν��Ͻ�.
    // ���� �̱������� ������� �ֵ��� �ڱ� �ڽ��� ǥ���Ҷ� �ν��Ͻ��� ��

    private void Awake() {
        // 2)
        if (Instance == null) {
            Instance = this; // �ش� �ν��Ͻ��� �ڱ� �ڽ��Դϴ�.
            DontDestroyOnLoad(Instance);
            // DDOL�� �ش� ��ġ�� �ִ� ������Ʈ�� ���� �Ѿ�� �ı����� �ʰ�
            // ���� �����Ǵ� ���� ����
        }
        else Destroy(gameObject);
    }
    #endregion

    #region Field
    public TMP_Text diName;
    public TMP_Text diMessage;
    public GameObject diPanal;
    public float diTypingSpeed;

    //ť ��, ť����!
    private Queue<Dialog> queue = new Queue<Dialog>();
    private Coroutine typing;
    private bool isTyping;
    private Dialog current; // ������ ��ȭ ����
    #endregion


    private void Update() {

        // �̺�Ʈ �ý��ۿ� ���޵� ���� �����ϰ�, �� ���� UI ������ ������ ��Ȳ�̶��?
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) {

            //�۾�x
            return;
        }

      
        // �����̽� ������ ���������� �۾� ���� ���
        // ��ȭ �Ŵ��� �ְ�, ��ȭ ���ΰ��
        if (Input.GetKeyDown(KeyCode.Space)) {
            if(isTyping) {
                CompleteLine(); // ������ ���� ��ŵ�ϴ�.
            }
            else {
                NextLine(); // ���� �������� �̵��մϴ�.
            }
        }
    }
    /// <summary>
    /// �����̳ʸӷ����� �Ű������� ������ �� ���־��ϴ�.
    /// List<T>�� Queue<T>ó�� ���� ������ �����͸� �� �Ű������� ���� �� �ֽ��ϴ�.
    /// </summary>
    /// <param name="lines">��ȭ �����Ϳ� ���� ������ ���� ������</param>
    public void StartLine(IEnumerable<Dialog> lines) {
        diName.text = "";
        diMessage.text = "";
        queue.Clear(); // �ٴ� �ƹ��ų�, ���̾�α׸� ����ǰ�!
        foreach (var line in lines) {
            queue.Enqueue(line);
        }
        diPanal.SetActive(true);
    }

    // ��� ó��
    private void CompleteLine() {
        if (typing != null) StopCoroutine(typing);
        diMessage.text = current.content;
        isTyping = false;
    } // �������� �߰���

    // ���� �۾��� ���� �Լ�
    private void NextLine() {
        if (queue.Count == 0) {
            DialogueExit(); // ť�� ������ ���ٸ� ��ȭ�� ����
            return;         // ���� �۾��� ������ �� ���ٸ�..
        }
        // ť�� ����� ���� �ϳ� ����
        current = queue.Dequeue();

        // ���� ��ȭ ���� ĳ���� �̸����� ����
        diName.text = current.character;
        

        // �ڷ�ƾ�� �����ִ� ���¶�� �����ݴϴ�.
        if (typing != null) StopCoroutine(typing);

        //���� ��ȭ �������� ������(��ȭ ����)�� �������� ��ȭ Ÿ������ ����
        typing = StartCoroutine(TypingDialogue(current.content));
        
    }

    private IEnumerator TypingDialogue(string line) {
        isTyping = true;   // Ÿ���� ���� ������ �˸�
        StringBuilder stringBuilder = new StringBuilder(line.Length);
        diMessage.text = ""; // ���� ����

        // string(���ڿ�)�� ����(char)�� �迭�� �ǹ���
        // foreach (char c in line) {
        //     diMessage.text += c;
        // } // �������� ������� �ѱ��ھ� ���

        foreach (char c in line) {
            // diMessage.text += c;�� ���
            stringBuilder.Append(c);
            diMessage.text = stringBuilder.ToString();
            yield return new WaitForSeconds(diTypingSpeed);
        }
        isTyping = false;
    }

    private void DialogueExit() {
        diPanal.SetActive(false); // �г� ����
    }
}

