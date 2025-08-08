using System;
using System.Collections; // 이너머레이터
using System.Collections.Generic; // 큐
using System.Text; // 스트링 빌더 때문
using TMPro; // 텍메프
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Dialog {
    public string character;
    public string content;

    public Dialog(string character, string content) {
        this.character = character;
        this.content = content;
    } // 어떻게 쓰는지 잘봐, 생성자
}

public class DialogManager : MonoBehaviour {

    #region MonoSingleton
    // 1) 자기 자신에 대한 인스턴스를 가진다. (전역)
    public static DialogManager Instance { get; private set; } // 프로퍼티
    // Instance는 값을 얻어올 수 있습니다.(접근 가능)
    // 수정은 할 수 없습니다.
    // 이름은 왠만하면 인스턴스.
    // 보통 싱글톤으로 만들어진 애들이 자기 자신을 표현할때 인스턴스라 함

    private void Awake() {
        // 2)
        if (Instance == null) {
            Instance = this; // 해당 인스턴스는 자기 자신입니다.
            DontDestroyOnLoad(Instance);
            // DDOL은 해당 위치에 있는 오브젝트가 씬이 넘어가도 파괴되지 않게
            // 따로 관리되는 씬의 영역
        }
        else Destroy(gameObject);
    }
    #endregion

    #region Field
    public TMP_Text diName;
    public TMP_Text diMessage;
    public GameObject diPanal;
    public float diTypingSpeed;

    //큐 란, 큐같다!
    private Queue<Dialog> queue = new Queue<Dialog>();
    private Coroutine typing;
    private bool isTyping;
    private Dialog current; // 현재의 대화 내용
    #endregion


    private void Update() {

        // 이벤트 시스템에 전달된 값이 존재하고, 그 값이 UI 위에서 눌려진 상황이라면?
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) {

            //작업x
            return;
        }

      
        // 스페이스 눌러서 정상적으로 작업 중인 경우
        // 대화 매니저 있고, 대화 중인경우
        if (Input.GetKeyDown(KeyCode.Space)) {
            if(isTyping) {
                CompleteLine(); // 라인을 실행 시킵니다.
            }
            else {
                NextLine(); // 다음 라인으로 이동합니다.
            }
        }
    }
    /// <summary>
    /// 아이이너머러블은 매개변수를 통합할 때 자주씁니다.
    /// List<T>나 Queue<T>처럼 열거 형태의 데이터를 다 매개변수로 받을 수 있습니다.
    /// </summary>
    /// <param name="lines">대화 데이터에 대한 열거형 묶음 데이터</param>
    public void StartLine(IEnumerable<Dialog> lines) {
        diName.text = "";
        diMessage.text = "";
        queue.Clear(); // 바는 아무거나, 다이얼로그를 적어도되고!
        foreach (var line in lines) {
            queue.Enqueue(line);
        }
        diPanal.SetActive(true);
    }

    // 기능 처리
    private void CompleteLine() {
        if (typing != null) StopCoroutine(typing);
        diMessage.text = current.content;
        isTyping = false;
    } // 안정성을 추가함

    // 다음 작업을 위한 함수
    private void NextLine() {
        if (queue.Count == 0) {
            DialogueExit(); // 큐에 남은게 없다면 대화의 종료
            return;         // 다음 작업할 내용이 더 없다면..
        }
        // 큐에 저장된 값을 하나 얻어옴
        current = queue.Dequeue();

        // 현재 대화 기준 캐릭터 이름으로 변경
        diName.text = current.character;
        

        // 코루틴이 남아있는 상태라면 멈춰줍니다.
        if (typing != null) StopCoroutine(typing);

        //현재 대화 데이터의 콘텐츠(대화 내용)을 기준으로 대화 타이핑을 시작
        typing = StartCoroutine(TypingDialogue(current.content));
        
    }

    private IEnumerator TypingDialogue(string line) {
        isTyping = true;   // 타이핑 진행 중임을 알림
        StringBuilder stringBuilder = new StringBuilder(line.Length);
        diMessage.text = ""; // 내용 비우기

        // string(문자열)은 문자(char)의 배열을 의미함
        // foreach (char c in line) {
        //     diMessage.text += c;
        // } // 원시적인 방법으로 한글자씩 출력

        foreach (char c in line) {
            // diMessage.text += c;의 기능
            stringBuilder.Append(c);
            diMessage.text = stringBuilder.ToString();
            yield return new WaitForSeconds(diTypingSpeed);
        }
        isTyping = false;
    }

    private void DialogueExit() {
        diPanal.SetActive(false); // 패널 좋료
    }
}

