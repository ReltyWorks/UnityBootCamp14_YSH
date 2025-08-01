using UnityEngine;
/*
기즈모 - 유니티 씬창에서 무브툴을 누르면 나오는 화살표들



*/




public class VectorSample : MonoBehaviour
{
    public Vector3 A = new Vector3(); // x, y, z가 자동적으로 0(영점)
    public Vector3 B = new Vector3(3, 4); // x와 y에 대한 정보 전달, z는 자동적으로 0
    public Vector3 C = new Vector3(5, 6, 7); // 하나는 안되고 두개나 세개를 넣어야함, 두개가 되는 이유는, Vector2 값이기 때문

    public Vector2 D = new Vector2(7, 8);

    public Vector3 E;
    public Vector3 F;


    #region 필기
    // 벡터의 요소
    // x : x 축의 값 (가로축)
    // y : y 축의 값 (높이)
    // z : z 축의 값 (세로축)
    // w : 셰이더나 수학 계산 등에서 사용되는 Vector4에서의 w축

    // ※ 값(value) vs 참조(reference)
    // 값 : 변수에 데이터가 직접 저장됩니다.
    // 참조 : 변수에 데이터가 저장된 메모리 주소 값이 저장되는 경우
    // 아는 내용이지만 복습을 하자, 멍때리지 말고..

    // ※ 메모리 저장 영역 / 프로그램 실행 개념
    // 프로그램이 실행되기 위해서는 운영체제(OS)가 프로그램의 정보를 메모리에 로드해야 합니다.
    // 프로그램이 실행되는 동안 중앙 제어 장치(CPU)가 코드를 처리하기 위해
    // 메모리가 명령어와 데이터들을 저장하고 있어야 합니다.

    // 컴퓨터 메모리는 바이트(Byte) 단위로 번호가 새겨진 선형 공간을 의미합니다.
    // 낮은 주소부터 높은 주소까지 저장되는 영역이 다르게 설정되어 있습니다.

    // 낮은 주소 : 메모리의 시작 부분
    // 높은 주소 : 메모리의 끝 부분

    // 대표적인 메모리 공간
    // 1. 코드 영역(code)
    //   > 실행할 프로그램 코드가 저장되는 영역 (텍스트 영역)
    //   > CPU에서 저장된 명령을 하나씩 가져가서 처리합니다.
    //   > 프로그램 시작부터 종료까지 계속 남아있는 값
    // 2. 데이터 영역(data)
    //   > 프로그램에서 전역 변수, 정적 변수가 저장되는 영역
    //   > 전역 변수(global) : 프로그램 어디서나 접근 가능한 변수
    //   >> (c#에서는 존재하지 않음, 전역 대신 클래스 수준의 정적 변수를 사용함)
    //   > 정적 변수(static) : static 키워드가 붙은 변수는 별도의 객체 생성 없이
    //   >> 클래스명.변수명 으로 직접 접근하는 것이 가능합니다.
    //   >> 프로그램 시작 시에 할당이 되고 그 이후부터 종료 시점까지 유지
    // 3. 힙(heep)
    //   > 프로그래머가 직접 저장 공간에 대한 할당과 해제를 진행하는 영역
    //   > 값에 대한 등록도, 값에 대한 제거도 프로그래머가 설계합니다.
    //   >> 참조 타입은 '무조건' 힙에 저장됩니다.
    //   >> c#의 힙 영역의 데이터는 GC에 의해 자동으로 관리됩니다.
    //   >> 저장 순서, 정렬에 대한 작업을 따로 신경 쓸 필요가 없습니다.
    //   >> 단, 메모리가 크고, GC에 의해 자동으로 처리되는 만큼 많이 사용되면 그만큼 성능이 저하됩니다.
    //   > 쉽게 말해, 접근속도 느림. 편하게 사용할 수 있는데신 컨트롤 불가.
    // 4. 스택(stack)
    //   > 프로그램이 자동으로 사용하는 임시 메모리 영역
    //   > 함수 호출 시 생성되는 변수(지역 변수, 매개 변수)가 저장되는 영역
    //   > 함수의 호출이 완료되면 사라지는 데이터, 이때의 호출 정보 == stack frame(스택 프레임)
    //   > 매우 빠른 속도로 접근이 가능합니다. (할당과 해제의 비용이 사실상 없음)
    //   > 먼저 들어온 데이터가 누적되고 가장 마지막에 남은 데이터가 먼저 제거되는 방식(LIFO)


    // 벡터의 특징 (스트럭트다) 스트럭트는 사용자 지정 타입이라 생각하면 편하다.
    // 1. 값 타입(value)으로 참조가 아닌 값 그 자체를 의미합니다. (구조체 struct)
    //  >> 계산이 빠르게 처리됩니다.
    // 2. 값을 복사할 경우 값 그 자체를 복사하기만 하면 됩니다.
    // 3. 벡터에 대한 계산 보조 기능이 많이 제공됩니다.(magnitude, normalized, Dot, Cross...)
    // 4. 벡터는 스택(stack) 영역의 메모리에서 저장이 됩니다.

    // c#에서 new 키워드를 힙에 대한 할당이 아니라, 값에 대한 초기화를 의미합니다.
    // struct에서의 new -> 초기화
    // class에서의 new -> 힙에 인스턴스 생성
    #endregion

    // 벡터의 덧셈은 순서가 상관없음
    // 벡터의 뺄셈은 순서가 중요하다.
    // >b - a와 a - b는 다름, 당연하지만..
    // 벡터의 곱셈은 존나게 어렵다.
    // > 스칼라(scalar)는 방향이 없는 수로 크기만 가지고 있는 순수한 수
    // 벡터의 나눗셈은, 그냥 하지마 씹쌔끼야
    // >> 벡터의 크기를 원하는 비율로 조절하는 연산입니다.

    // 내적 정의
    // 외적 정의


    void Start() {
        E = A + B;
        F = C + (Vector3)D;
        // 캐스팅의 경우 벡터2의 X, Y 값이 그대로 벡터3 의 X, Y값으로 된다. Y가 Z가 되진 않는다는 말

        Debug.Log(A);
        Debug.Log(B);
        Debug.Log(C);
        Debug.Log(D);
        Debug.Log(E);
        Debug.Log(F);
        // 벡터는 기본적으로 float값이다.
    }

    void Update() {
        
    }
}
// 벡터 2를 3에 넣어보고
// 벡터 3를 2에 넣어보고
// 소실되는 값, xy가 들어오나 xz가 들어오나 등등
// 테스트 해보자