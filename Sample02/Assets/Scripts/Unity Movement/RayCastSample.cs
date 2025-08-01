using UnityEngine;
/*
RayCast : 시작 위치에서 특정 방향으로 가상의 광선을 쐇을 때
부딪히는 오브젝트가 있는지를 판단합니다.
1) 특정 오브젝트를 충돌 범위에서 제외하는 작업 가능
2) 특정 오브젝트에 대한 충돌 판정을 확인하는 용도








*/




public class RayCastSample : MonoBehaviour {
    RaycastHit hit; // 충돌 감지용 변수
    // ref : 변수를 참조로 전달, 변수가 메소드 안에서 변경될 수 있음을 알리는 용도
    // out : 변수를 참조로 전달, 변수 전달 전에 변수에 대한 초기화를 진행할 필요가 없음

    // Physics.RayCast(Vector3 origin, Vector3 direction, out RayCastHit hitInfo,
    // float maxDistance, int layerMask);

    // origin의 방향에서 direction의 방향으로 maxDistance 길이의 광선을 발사합니다.

    // hitInfo는 충돌체에 대한 정보를 의미합니다.

    const float length = 10.0f;

    void Update() {

        // 오브젝트의 위치에서 정면으로 length만큼의 길이에 해당하는 디버깅 광선을 쏘는 코드
        // 주로 레이캐스트 작업에서 레이가 안보이기 때문에 보여주는 용도로 사용합니다.
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);

        // 왼쪽 버튼을 눌렀을 경우 
        if (Physics.Raycast(transform.position, transform.forward, out hit, length)) {
            Debug.Log("히히히 발싸");
            hit.collider.gameObject.SetActive(false); // 맞으면 꺼짐
        }

    }
}
