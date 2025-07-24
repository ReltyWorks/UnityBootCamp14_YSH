/*
모노비헤이비어??
프레임을 너무 아끼면 단조로워 질 수 ?있?다?
디버그 델리트 버그
Axis 는 유니티가 고유하게 기지고 있는 키?


인풋 매니저(Axes 키) 확인
Horizontal : 수평 키
Vertical : 수직 키
유니티 입력 기능 (구/신버전 활성화)
Edit -> Project Settings -> Player -> Other Settings -> Configuration -> Active Input Handling
유니티 기본 편집 IDE설정
Edit -> Preferences -> External tools -> External Script Editor -> 원하는걸로
VS에서 솔루션 탐색기에 Assembly-CSharp이 켜져있어야 유니티의 코드를 탐색할 수도 있음



Obstacle 스크립트를 만들어서
장애물을 구현하
1. 장애물의 태그는 obstacle
    장애물과 트리거 충돌할 경우
    플레이어의 speed가 1 감소합니다
    장애물은 사라짐

*/ 

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public bool obsOn = false;



    // Start는 MonoBehaviour가 생성된 후 Update의 첫 번째 실행 전에 한 번 호출됩니다.
    void Start()
    {
        speed = 300;
        rb = GetComponent<Rigidbody>();
        // GetComponent<T>() : 게임 오브젝트에 붙어있는 컴포넌트를 가져오는 기능
        // T : Type
        Debug.Log("설정이 완료되었습니다!");
    }

    // 업데이트는 프레임당 한 번씩 호출됩니다.
    void Update()
    {
        // speed += 1;
        // Debug.Log($"속도가 1 증가합니다. 현재 속도는 {speed}입니다.");

        // 수평 이동
        float horizontal = Input.GetAxis("Horizontal");
        
        // 수직 이동
        float vertical = Input.GetAxis("Vertical");

        // 이동 좌표(벡터) 설정
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        if(obsOn == true) {
            rb.AddForce((movement * -500f) * Time.deltaTime);
            obsOn = false;
        }
    
        rb.AddForce((movement * speed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        // 충돌체의 게임 오브젝트 태그가 Itembox 라면
        if(other.gameObject.CompareTag("Itembox")) {
            Debug.Log("아이템 획득!");
            // 충돌체의 게임오브젝트를 비활성화
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("obstacle")) {
            Debug.Log("장애물 밟음!");
            obsOn = true;
            other.gameObject.SetActive(false);
        }
    }

}