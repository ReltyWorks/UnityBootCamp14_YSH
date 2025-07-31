using System.Collections.Generic;
using UnityEngine;

// 개꿀팁, 프로그래밍에선, 추가기능이 있으면 더 속도가 빠르고 리소스 소모가 적음
// 같은 결과를 얻을 수 있다면, 컬렉션 보단 배열을 쓰자. '결과물이 같다면!'

// 퍼블릭은 변질되기 쉬운 값이기 때문에
// 초기화 할때 값을 입력해도, 컴포넌트 될 때만 한번 로드된다.
// 그 뒤로 바뀌면 의미가 없어지는거

// 헤더는 인스펙터 창에서 텍스트를 넣는 기능이다.
public class InspectorAttributes : MonoBehaviour {

    [Header("<Score>")]public int point;
    public int max_point;
    [Header("<Info>")]
    public string nickname;
    // 직업 : 전사, 도적, 궁수, 마법사
    public Job myJob;

    // 인스펙터에 공개하기 싫은 값에 대한 설정
    [HideInInspector]
    public int bodyWeight = 78; // 퍼블릭이지만 인스펙터엔 안보임
    // 반대로, 프라이빗을 공개하는 설정
    // 유니티에서 비공개(private) 필드를 인스펙터에 노출시키고
    // 유니티의 직렬화 시스템에 포함시킵니다.
    [SerializeField]
    private int age = 13; // 프라이빗이지만, 인스펙터에 보임
    // public > 노출 o 접근 o
    // private > 노출 x 접근 x
    // SerializeField + private > 노출 o 접근 x
    // HideInInspector + public > 노출 x 접근 o

    // ※ 직렬화(Serialization) : 데이터를 저장 가능한 형식으로 변환하는 작업
    // 이 변환을 통해 씬, 프리팹, 에셋 등에 저장하고 복원하는 작업을 수행할 수 있습니다.
    // 쉽게 말해 읽을 수 없는 데이터를 사용자가 쓸 수 있게 만들어주는 것

    // 직렬화의 조건
    // 1. public or [SerializeField]
    // 2. static이 아닌 경우
    // 3. 직렬화 가능한 데이터 타입인 경우

    // 직렬화가 가능한 데이터
    // 1. 기본 데이터(int, float, bool, string...)
    // 2. 유니티에서 제공해주는 구조체(Vector3, Quaternion, Color...)
    // 3. 유니티 객체 참조(GameObject, Transform, Material...)
    // 4. [Serializable] 속성이 붙은 클래스
    // 5. 배열 / 리스트

    // 직렬화 불가능한 데이터
    // 1. Dictionary<K,V>
    // 2. Interface
    // 3. static 키워드가 붙은 필드
    // 4. abstract 키워드가 붙은 클래스

    public enum Job {
        전사,
        도적,
        궁수,
        마법사,
    }

    // 문자열이 장문일 경우 유용한 속성
    // 기본은 1줄, 설정을 넣으면 그 수치만큼 칸이 늘어납니다.
    [Multiline(3)] // 현재 유니티 최신에는 안먹힘,


    // 긴 문자열을 여러 줄로 적을 수 있는 설정
    // [TextArea]만 작성할 경우 여러 줄 입력이 가능한 상태가 됩니다.
    // (최소 크기, 최대 크기)를 추가로 쓴다면, 인스펙터 상에 높이를 제한할 수 있습니다.
    // [Space(높이)] : 적은 높이 만큼 간격(위의 속성과의)이 생깁니다.
    [TextArea(3, 5)][Space(30)] public string quest_info;



    // 여기서부턴 스트럭트 클래스 테스트


    // [Serializable]
    public struct Book { // 사용자 정의 타입 / 값(Value)타입 / GC 필요 없음
        // 작은 데이터 묶음을 자주 할당 / 복사하는 개념에서 활용 (ex. Vector3)
        // 최적화 용도로 자주 씀 / ex. 플레이어의 스탯 묶음, 등
        // 쉽게 생각해라, 이건 지금 int, float 처럼 Book을 만든거다
        public string name;
        public string description;
    }

    [System.Serializable] // 상단에 System을 선언하지 않고, 이렇게 쓸 수도 있다.
    public class Item { // 객체를 위한 설계도(속성[변수]과 기능[메서드])
                        // 유니티에서는 class 사용 권장, 스트럭트에 비해 안정성이 높음
                        // 복사 과정에서의 실수 발생 가능성 없음
                        // 너무 많이 생성되고, 파괴되는 요소에 쓰면, 성능에 문제가...
        public string name;
        private string description; // 프라이빗!
    }

    public Book myBook; // 얘는 인스펙터에 아예 안뜸
    public Item myItem; // 얘는 인스펙터에 뜨고, name만 뜸

    // 유니티 인스펙터에서는 배열도 리스트로 나오게 됩니다.
    // 리스트<T>는 T형태의 데이터를 묶음으로 순차적으로 저장할 수 있는 데이터 입니다.
    // 데이터의 검색, 추가, 삭제 등의 기능이 제공됩니다.
    public List<Item> item_list;
    // // 깜짝 놀랐네! 맞어 List<T>의 <T>는 자료형이야!
    // // 그리고 Item은 데이터, 그리고 자료형으로 쓸 수 있지! 씨발!

    public Book[] bookArray = new Book[5];
    // 유니티에선 리스트나 배열이나 똑같이 표현한다.
    // 다만, 스크립트에선 다르게 돌아가겠지
    // 유니티 인스펙터 창에선, 배열을 늘려줄 수도 있다.
    // 다만, 이 상태에선 Book에 [Serializable]이 달려있지 않아서, 인스펙터에 뜨지 않는다.

    // [Range(최소, 최대)]를 통해 해당 값을 에디터에서 최소값과 최대가 설정되어있는
    // 스크롤 형태의 값으로 변경됩니다. (범위 제한)
    // 이게 변수의 최대 최소를 정해주는 역할도 해버린다.
    [Range(0,100)] public int bgSound; // 마우스를 움직여보면 정수만 표현
    [Range(0,100)] public float sfx; // 마우스 움직여보면 소수점도 표현
}
