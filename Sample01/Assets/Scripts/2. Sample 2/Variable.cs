

using System;
using UnityEngine;
// 이 파일은 유니티 인스펙터에서 변수에 대한 표현을 확인하는 코드

// 이넘은 원래 상수에 이름을 붙일 수 있는 
public enum TYPE {
    불, 물, 풀
} // 이넘을 선언까지 하면, 유니티 인스펙터에서 선택할 수 있게 된다?

// 플래그는 여러개를 선택하는 기능!
// 값을 2의 제곱수로 표현
[Flags] // 이넘 앞에 플래그스를 붙이면 비트연산 사용가능? 빈번하게 쓰인다.
public enum TYPE2 { // 비트연산이 성능이 가장 좋다.
    독 = 1 << 0,
    고스트 = 1 << 1, // 1에서 1칸 이동하겠습니다.(비트 연산)
    드래곤 = 1 << 2, // 0b100
    얼음 = 0b1000,
    비행 = 16,
    바위 = 1 << 5,
    에스퍼,
}


public class Variable : MonoBehaviour
{
    // 유니티에서 자주 사용되는 C# 기본 데이터 타입 (primitive)
    // 정수(int) -2,147,483,648 ~ 2,147,483,647
    // 실수(float)
    // 논리(bool)
    // 문자열(string)
    // 널 값 허용(nullable) : 자료형?로 작성하면 해당 값은 null을 사용할 수 있음.

    public int Integer;
    public float Float;
    public string Sentence;

    public TYPE type;
    public bool isDead;

    public TYPE2 type2;

    // 변수명을 카멜표기법으로 작성시 대문자 앞에 띄어쓰기를 넣어줌

}
