using UnityEngine;
/*
중요 클래스 Mathf
유니티에서 수학 관련으로 제공되는 유틸리티 클래스
게임 개발에서 사용될 수 있는 수학 연산에 대한 정적 메소드와 상수를 제공합니다.

ex)정적 메소드 : static 키워드로 구성된 해당 메소드는 클래스명.메소드명()
                 으로 사용이 가능합니다. Mathf.Abs(-5);
https://docs.unity3d.com/kr/2021.1/Manual/class-Mathf.html
*/
public class MathfSample : MonoBehaviour {
    // 기본적으로 사용되는 메소드
    float abs = -5;
    float ceil = 4.1f;
    float floor = 4.6f;
    float round = 4.5f;
    float clamp;
    float clamp01;
    float pow = 2;
    float sqrt = 4;

    void Start() {
        Debug.Log(Mathf.Abs(abs));      // 절댓값(absolute number)
        Debug.Log(Mathf.Ceil(ceil));    // 올림(소수점과 상관없이 값을 올림 처리합니다)
        Debug.Log(Mathf.Floor(floor));  // 내림(소수점과 상관없이 값을 내림 처리합니다)
        Debug.Log(Mathf.Round(round));  // 반올림(5이하면 내리고 초과면 올립니다.)
        Debug.Log(Mathf.Clamp(7, 0, 4));// 현재 전달받은 값 = 7, 최소 = 0, 최대 = 4, 결과 > 4
        // 클램프는 값을 제한하는 코드다. 값, 최소, 최대 순으로 값을 입력합니다.
        Debug.Log(Mathf.Clamp01(5));    // 현재 전달 받은 값 = 5, 최소 = 0, 최대 = 1 (자동설정)
        // 벗어나면 0~1로 처리, 퍼센트 개념의 값을 처리할 때 자주 사용되는 코드
        // Clamp vs Clamp01
        // Clamp => 체력, 점수, 속도 등의 능력치 개념에서의 범위 제한
        // Clamp01 => 비율(퍼센트), 보간 값(t), 알파 값(색깔에서의 투명도)
        Debug.Log("제곱" + Mathf.Pow(pow, 2)); // 값, 제곱 수(지수)를 전달받아서 해당 수의 거듭 제곱을 계산합니다.
        Debug.Log("제곱근" + Mathf.Pow(pow, 0.5f)); // Mathf.Sqrt()로 계산하는 거보다 연산이 매우 느림.
        Debug.Log("지수가 음수일 경우 값은 역수 형태로 계산합니다." + Mathf.Pow(pow, -2f)); // 2의 -2 제곱 => 1/4
        Debug.Log(Mathf.Sqrt(sqrt)); // 값을 전달받아, 제곱근을 계산합니다.
    }
}
