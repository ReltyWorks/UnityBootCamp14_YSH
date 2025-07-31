using UnityEngine;
using UnityEngine.Events;
/*
유니티의 입력 시스템
A. Input Manager - 폴링 기반 처리(함수)
Edit -> Project Settings -> input
Input.GetAxis("키 이름") -1~1까지의 '실수' 부정확함
Input.GetAxisRaw("키 이름") -1, 1, 0 을 반환, 반올림이 아닌, 0을 기준으로 조금만 바뀌어도 -1, 1 반환함
Input.GetButton("버튼 이름") 해당 버튼을 누른 만큼 true (누르고 있으면 계속 올라감)
Input.GetButtonDown("버튼 이름") 해당 버튼을 눌렀을 때 1번 true
Input.GetButtonUp("버튼 이름") 해당 버튼이 때졌을 때 1번 true

마우스 입력 0 왼쪽, 1 오른쪽 ,2 중앙(휠)
Input.mousePosition마우스의 화면내의 위치

Unity Input System
유니티 2019버전 이후부터 New Input System
1. 멀티 플랫폼 지원(다양한 디바이스에서 동일한 코드로 입력 보장)
2. 동적 입력 바인딩(사용자가 게임 내에서 키 매핑 수정 가능)
3. 이벤트 기반의 입력(기존의 레거시는 폴링 방식, 현재의 인풋 시스템은 이벤트 기반)
4. 입력 액션 시스템(액션을 통해 다양한 입력에 대한 처리를 한 곳에서 관리 가능)
*/



[ExecuteInEditMode]
public class PlayerStat : MonoBehaviour
{
    public enum Job {
        무직, 전사, 마법사, 도둑,
    }

    [Header("<Status>")]
    public string name = "Player";
    public int level = 1;
    public Job job = Job.무직;
    public int str = 0;
    public int wis = 0;
    public int dex = 0;

    [Header("<Editor>")]
    [Space(30)]
    public bool tryEdit = false;
    public bool valuePlus = true;

    [Space(10)]
    public UnityEvent Editor;


    public void Update() {
        if (!Application.isPlaying && tryEdit) {
            Editor.Invoke(); // Invoke라는 함수를 통해서 action에 등록된 함수를 실행
        }
    }

    public void StrEdit() {
        if (valuePlus) str++;
        else str--;
    }
    public void WisEdit() {
        if (valuePlus) wis++;
        else wis--;
    }
    public void DexEdit() {
        if (valuePlus) dex++;
        else dex--;
    }
}
