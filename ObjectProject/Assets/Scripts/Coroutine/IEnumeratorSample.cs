using System.Collections;
using UnityEngine;

public class IEnumeratorSample : MonoBehaviour {

    // C# 기준으로 아이 이너머래이터 사용 가능
    // 유니티 (모노비에이이허ㅣ) 환경에서
    // 아이이너머래이터는 코루틴으로써 활용


    // 유니티에선 이렇게 사용하진 않고, C#에서나 사용하는 형식임
    // 유니티에선 그냥 XX을 쓰면됨
    class CustomCollection : IEnumerable {

        int[] numbers = { 6, 7, 8, 9, 10 };

        // GetEnumerator를 통해 순회 가능한 데이터를 IEnumerator 형태의 객체로 변환합니다.
        public IEnumerator GetEnumerator() {

            for (int i = 0; i < numbers.Length; i++) {

                yield return numbers[i];
            }
        }
    }

    int[] numbers = { 1, 2, 3, 4, 5 };

    void Start() {

        // numbers라는 배열을 순회할 수 있는 IEnumerator 형태의 데이터로 변환합니다.
        IEnumerator enumerator = numbers.GetEnumerator();

        while (enumerator.MoveNext()) {

            Debug.Log(enumerator.Current); //Current는 현재 순회중인 데이터의 정보를 의미함
        }

        CustomCollection collection = new CustomCollection(); // 커스텀 컬렉션 생성

        // foreach는 순환 가능한 데이터를 순차적으로 작업할 때 사용하는 for문임으로 보기가 간결해 집니다.
        foreach (int number in collection) {
            Debug.Log(number);
        }

        //IEnumeratorSample isample = new IEnumeratorSample();
        //IEnumerator enumerator1 = isample.


        foreach (var number in GetMessage()) {
            Debug.Log(number.ToString());
        }

    }
    /*
     yield는 C#에서 한 번에 하나 씩 값을 넘기고, 메소드가 일시 정지 되며 후속 값들을
     지속적으로 반환하게 합니다. (반복적인 작업, 순차적인 데이터 처리에 사용됩니다.)

     yield는 yield return, yield break로 사용됩니다.
     리턴은 그 지점에서 메소드 실행을 일시 중지 시킵니다.
     호출자가 다음 값을 요구할 때까지 대기합니다.
     브레이크는 메소드에서 반복을 종료하는 코드입니다. (실행 종료)

     yield를 사용하는 메소드는 IEnumerable 또는 IEnumerator 인터페이스를 구현하게 됩니다.
     컬렉션을 자동으로 순회하는 foreach와 자주 사용됩니다.

     장점 : 값을 필요로 할 때까지 계산을 미루는 방식(메모리 효율이 좋음, 큰 데이터를 처리할 떄 이점이 큽니다.)

     IEnumeralbe : 아이 이너머러블 
     반복 가능한 컬렉션을 나타내는 인터페이스 입니다.
     이 기능을 구현한 클래스는 반복할 수 있는 객체가 되며
     foreach 등에서 순차적인 탐색을 진행할 수 있게됩니다.
     해당 인터페이스를 구현하기 위해서는 GetEnumerator() 메소드를 제공하고, 사용자가 구현해야합니다.
    
     IEnumerator : 반복을 관리하는 인터페이스 입니다.
     컬렉션에서 하나씩 항목들을 반환하고, 그 상태를 관리하는 역할을 수행합니다.
     MoveNext()를 통해서 다음 값을 접근
     Current를 통해서 현재 값 확인
     Reset()을 통해서 리셋 기능 처리ㅉ
    */


    static IEnumerable GetMessage() {
        yield return 1;
        Debug.Log("탈출 했다가 돌아옴 1");
        yield return 2;
        Debug.Log("탈출 했다가 돌아옴 2");
        yield break; // 순환 작업 종료

        // -- Unreachable Code -- (접근 불가)
        Debug.Log("탈출 했다가 돌아옴 3");
        yield return 3;
    }
}