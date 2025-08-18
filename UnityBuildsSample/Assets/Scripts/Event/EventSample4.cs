using UnityEngine;
using System;

// 1. EventArgs를 상속한 커스텀 클래스 만들기

public class DamageEventArgs : EventArgs {
    // 전달할 값에 대한 설계
    // 프로퍼티로 작업하며, get기능만 주로 활성화 합니다.
    public int Value { get; } // Value에 대한 접근만 가능
    public string eventName { get; }

    // EventArgs에 대한 생성이 발생하면 값이 설정됩니다.(생성자)
    public DamageEventArgs(int value, string name ) {
        Value = value;
        eventName = name;
    }
}

public class EventSample4 : MonoBehaviour {
    public event EventHandler<DamageEventArgs> OnDamage;
    // 데미지를 받았을 때에 대한 이벤트 핸들러

    public void TakeDamage(int value, string name) {
        // 전달받은 값을 기준으로 데미지 이벤트 매개변수를 생성해
        // 핸들러 호출 시의 정보로 전달합니다.
        OnDamage?.Invoke(this, new DamageEventArgs(value, name));

        Debug.Log($"<color=white>[{name}] 플레이어가 {value} 데미지를 받았습니다.</color>");
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.A)) {
            TakeDamage(UnityEngine.Random.Range(10, 200), "날벼락");
        }
    }
}
