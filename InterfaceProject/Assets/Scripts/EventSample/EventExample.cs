using System;
using UnityEngine;
// C# Event 526 page

// event : 특정 상황이 발생했을 때 알림을 보내는 메커니즘
// 1. 플레이어가 죽었을 때, 알림 전달 > 메소드 호출

// Action : 매개변수 없고 리턴값 없음

/*
public class Tester : MonoBehaviour {
    void Start() {
        EventExample eventExample = new EventExample();
        eventExample.onDeath?.Invoke();
        // eventExample.onStart?.Invoke(); <- 오류뜸
        // event Action의 경우 외부에서 호출 불가능
        eventExample.onDeath = null; // 구독한거 다 해제
        // onStart는 안됨, 즉 event Action은 내수용임
        eventExample.onStart += Sample; // 구독은 가능
        eventExample.onStart -= Sample; // 해제도 가능
        // 정리하자면, event Action는 내부의 함수인지 확인해서 써라
    }
    private void Sample() { }
}
                    Action      vs      event Action
외부 호출               O                       X
외부 대입               O                       X
구독 기능               O                       O
구독 해제               O                       O
주 용도            내부로직, 콜백            이벤트 알림

쉽게 생각하면, event Action는 외부에서 수정되었을때 문제가 생길 수 있을때
안정성만 체크해서 사용하면됨! 안전필요하면 event Action!
*/

public class EventExample : MonoBehaviour {

    // Action vs event Action?? 위의 Tester 확인!
    public Action onDeath;
    public event Action onStart;

    void Start () {
        // 액션은 +=를 통해 함수(메서드)를 액션에 등록할 수 있습니다. (구독)
        // 액션은 -=을 통해 함수(메서드)를 액션에서 제거할 수 있습니다. (해제)
        // 액션의 기능을 호출하면 등록되어있는 함수가 순차적으로 호출됩니다.
        onStart += Ready;
        onStart += Fight;

        onDeath += Damaged;
        onDeath += Dead;

        onStart?.Invoke(); // Invoke();는 액션에 등록된 기능을 수행하는 코드
        onDeath();

        // 둘의 차이? 없음. 문법 스타일 차이
        // Invoke 방식이면 null 체크 가능, 외부에서의 호출, 안전성 요구시 추천
        // 함수 형태면 따로 설계, 내부 코드이거나 단순 호출일 경우 해당 방식 추천
    }
    private void Ready() {
        Debug.Log("<color=cyan><b>Ready??</b></color>");
    }
    private void Fight() {
        Debug.Log("<color=yellow><b>Fight!!</b></color>");
    }

    private void Damaged() {
        Debug.Log("<color=red><b>Critical Damage!!</b></color>");
    }
    private void Dead() {
        Debug.Log("<color=blue><b>A Hero is Fallen.</b></color>");
    }
}
