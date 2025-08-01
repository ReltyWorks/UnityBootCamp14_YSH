using UnityEngine;

// 오브젝트 캐싱에 대하여(Object Cashing)

// 캐시(Cashe)
// 자주 사용되는 데이터나 값을 미리 복사해두는 임시 장소

// 캐시 사용 의도
// 1. 시간 지역성 : 가장 최근에 사용된 값이 다시 사용될 가능성이 높다.
// 2. 공간 지역성 : 최근에 접근한 주소와 인접한 주소의 변수가 사용될 가능성이 높음.

public class Sample3 : MonoBehaviour
{
    Rigidbody rb;
    Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 캐싱(cashing)
    }

    void Update()
    {
        // GetComponent<Rigidbody>().AddForce(pos * 5); // 프레임마다 전체 호출
        rb.AddForce(pos * 5); // 캐싱을 한 데이터를 호출
    }
}
