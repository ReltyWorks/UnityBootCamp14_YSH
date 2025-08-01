using UnityEngine;
/*
유니티에서 사용되는 이벤트 함수(생명 주기)
유니티에서는 스크립트의 실행, 활성화, 프레임 당 호출 등
상황에 맞게 작업할 수 있는 작업 공간이 존재

Tip) 프로그래밍에서 함수는 특정 하나의 기능을
수행하기 위해서 명령문들을 모아놓은 명령 집합체

여긴 유니티 기본함수
*/

public class EventSample : MonoBehaviour
{
// 스크립트 내에서 이벤트 함수를 작성하고,
// 내부에 진행할 명령문을 작성하면 상황에 맞게 해당 기능이 수행됨
// 주로 요 순서로 코드를 작성함(함수)

    private void Awake() {
        Debug.Log("[Awake]");
        Debug.Log("-씬(스크립트)이 시작될 때 '한번'만 호출되는 영역입니다.");
        Debug.Log("-해당 스크립트가 비활성화(컴포넌트는 되어있어야함)되어 있어도 이 위치의 작업은 실행됩니다.");
        Debug.Log("-해당 영역에서 코루틴으로 실행이 불가능합니다.");
        Debug.Log("-각 스크립트 기준 한 번만 호출이 되고 다른 개채의 초기화가 완료 된 후 호출되는 영역이기 때문에"); 
        Debug.Log("다른 컴포넌트에 대한 참조를 만들어야 하는 경우 이 위치에서 만들면 안전하게 처리됩니다.");
    // 코루틴(Coroutine) : 코드를 일시 중지하고 특정 조건이 충족될 때까지
    // 실행을 delay 시킬 수 있는 기능 (ex. 3초 뒤에 오브젝트를 파괴/포션을 먹은 후의 포션 쿨타임)
    }

    private void OnEnable() { // 반대의 개념은 OnDisable/온 디세이블, 은 비활성화 될 때
        Debug.Log("[OnEnable]"); // 온 인에이블
        Debug.Log("-해당 위치는 오브젝트 또는 스크립트가 활성화 될 때 호출됩니다.");
        Debug.Log("-이벤트(함수 이벤트가 아닌 게임 로직)에 대한 연결에 사용됩니다.");
        Debug.Log("-해당 영역에서 코루틴으로 실행이 불가능합니다.");
    }
    // 스크립트를 껏다 키는 방식은 왠만하면 하지마라, 위험
    // 차라리 오브젝트를 껏다 키는 방식을 사용해라

    void Start() {
        Debug.Log("[Start]");
        Debug.Log("-모든 스크립트의 'Awake'가 다 실행된 이후 실행되는 영역입니다.");
        Debug.Log("-해당 스크립트가 활성화될 때 실행됩니다.");
        Debug.Log("-해당 영역에서 코루틴으로 실행이 가능합니다.");
    // Awake, Start의 공통점
    // 둘 다 기본적으로 값에 대한 초기화(할당)를 수행하는 위치입니다.
    // 어떤 것을 사용해도 상관은 없으나 상황에 따라 설계합니다.
    // Awake : 변수 초기화, 값 참조
    // Start : 게임 로직에 대한 실행, 초기화된 데이터를 기반으로 작업 수행, 코루틴 작업
    // 해당 상황에 대한 판단을 위해 Sample1, Sample2 파일을 통한 예시로 확인해봅시다.
    }

    void Update()
    {
        // 화면에 렌더링되는 주기가 1초에 약 60번정도 호출됩니다.
        // (하드웨어 성능에 따라 차이가 날 수 있습니다.)

        // Time.deltaTime을 통해 이전 프레임 ~ 현재 프레임 까지의 시간 차이로 보정 값을 주거나
        // 정규화/단위 벡터를 이용해 작업을 처리합니다.
        // 단위 벡터 : 벡터의 크기가 1인 상태

        // 기본적으로 계산에 보정 값들이 많이 사용됩니다.
        // 프로그램 내에서 핵심적으로 계속 사용되는 메인 로직을 짜는 위치로 사용됩니다.
        // ex) 키 입력 등을 기반으로 움직임(지속적안 업데이트가 요구되는 경우)

        // 업데이트를 대체할 수 있는 수단
        // 1. 상황에 맞는 유니티 생명 주기 코드
        // 2. 코루틴
        // 3. 이벤트 시스템(버튼 클릭/ 충돌 감지 등등)
        // 4. C#의 가상 함수 개념(Update를 대신해 특정 클래스에서 업데이트 로직을 처리함)
        //      특정 하나의 관리 클래스(manager)에 Update의 로직을 위임해 관리해서 사용

        // 업데이트는 써야하는 기능이고, 가장 많이 사용되는 영역입니다.
        // 따라서 업데이트에서 무조건 실행되야하는 상황이 아니라면
        // 다른 영역에서 작업을 하게 설계하는 것이 업데이트의 부담을 줄여줄 수 있고
        // 이게 성능의 향상으로 이어집니다. 역설적으로 상기의 이유가
        // 업데이트의 사용을 피하면 피할수록 성능이 올라가긴 합니다.
        // 단, 제대로 알고 사용합니다.
    } // 주로 키입력

    private void FixedUpdate() {
        // 일정한 발생 주기가 보장되야 하는 로직에서 사용됩니다. (ex. 물리연산(Rigidbody))
        // 프레임을 기반으로 처리되는 것이 아닌 Fixed TimeStep이라는
        // 설정된 값에 의해 (기본 0.02초) 일정 간격으로 호출됩니다.

        // TimeScale이 0으로 설정된 경우 멈춥니다.

    } // 주로 물리연산

    private void LateUpdate() {
        // 모든 Update 함수(FixedUpdate 포함)가 호출된 다음에 마지막으로 호출되는 영역입니다.

        // 후처리 작업에 사용됩니다.
        // LateUpdate가 여러개일 경우 상황에 맞는 호출 순서가 중요합니다.
    } // 주로 카메라 워크
}
