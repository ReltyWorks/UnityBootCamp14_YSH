using UnityEngine;
using UnityEngine.Events;
// 유니티 Event, EventArgs를 사용하기 위해선
// UnityEngine.Events 네임스페이스 연결이 필수입니다.

// C#의 Event와의 차이점
// 1. 인스펙터에서 확인이 가능하다.
// 2. 추가 제거 기능을 +=, -=로 하지 않고 AddListener와 RemoveLister로 진행합니다

//                    UnityAction            vs            UnityEvent
// 타입                 delegate                              class
// 기능                 함수 참조                  에디터에서 핸들러 직접 등록 가능
// 구독                   +, -                   AddListener(), RemoveListener()
// 사용할 상황        스크립트 코드 내 처리             인스펙터용 이벤트 시스템
// 속도                   빠름                 느림(연결 정보에 대한 파싱 후 런타임 실행 방식)
// 메모리                 적음                                  많음
// GC 발생 여부            낮음                                 높음
// 편의성              자체 설계 해야함                 바로 사용 가능, 쉽고 편함

// UnityAction은 UnityEvent를 사용하는 코드를 설계할 때 효과적입니다.
// 일반 delegate는 UnityAction<T>와 같이 타입에 대한 설정이 안되어있어
// 따로 만들어서 사용해야 합니다.

// 유니티 작업 시 사용할 수 있는 delegate 형태 데이터 선택
// 1. C# delegate
// 2. Unity UnityAction
// 3. C# Func<T>, Action<T>

// 이 다양한 delegate들을
// 언제 어떤걸 사용해야 하는가?

// 고성능을 원한다. -> C# delegate
// 콜백 -> Aciton, UnityAction
// UnityEvent와의 인스펙터 연결 -> UnityAction
// 이벤트 시그니처 필요(유연하게 설계 원함) -> delegate, Func, Action

// 이벤트 시그니처 - 호출되는지에 정의한 함수의 형태
// ex. C#의 EventHandler의 선언
// ex. delegate void EventHandler(object sender, EventArgs e);
// 시그니처
// 1. 반환타입 (void)
// 2. 매개변수 (object, EventArgs)

public class EventSample3 : MonoBehaviour {
    public UnityEvent OnKButtonEnter;
    public UnityAction OnAction;

    void Start() {
        // OnKButtonEnter += Sample(); 오류!
        OnKButtonEnter.AddListener(Sample);
        // AddListener(UnityAction call)의
        // UnityAction는 메소드라 이해하면 편함

        OnAction += Sample2;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            OnKButtonEnter?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            OnAction?.Invoke();
        }
    }
    
    private void Sample() {
        Debug.Log("<color=cyan>Sample3_Sample 실행</color>");
    }
    private void Sample2() {
        Debug.Log("<color=red>Sample3_Sample2 실행</color>");
    }
}
