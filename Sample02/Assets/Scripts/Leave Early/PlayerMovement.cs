using UnityEngine;

//1) 이 스크립트를 사용하기 위해서는 Rigidbody 컴포넌트가 요구됩니다.
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    //[public]
    //이동 속도 (speed)
    public float speed;
    //점프 파워 수치 (jp)
    public float jp;
    //땅 레이어 확인(레이어 마스크) (ground)
    public LayerMask ground;

    //[private]
    //리지드바디 (rb)
    private Rigidbody rb;
    //땅을 밟은 상태인지 체크 (isGrounded)
    private bool isGrounded;


    void Start()
    {
        //리지드 바디에 대한 연결
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //키 입력
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");


        //방향 설계
        Vector3 dir = new Vector3(x, 0, z);

        //이동 속도 설정
        Vector3 velocity = dir * speed;

        rb.linearVelocity = velocity;
        //리지드 바디의 속성
        //linearVelocity = 선형 속도(물체가 공간 상에서 이동하는 속도)
        //angularVelocity = 각 속도 (물체가 회전하는 속도)


        //점프 기능 추가
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jp, ForceMode.Impulse);
            //ForceMode.Impulse : 순간적인 힘
            //ForceMode.Force : 지속적인 힘
        }

    }

    private bool IsGrounded()
    {
        //아래 방향으로 1만큼 레이를 쏴서 레이어 체크
        return Physics.Raycast(transform.position, Vector3.down, 1.0f, ground);
    }
}
