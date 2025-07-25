using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Text scoreText;  // 텍스트 텍스트

    public bool obsOn = false; // 장애물 밟음
    private int score = 0; // 점수


    void Start()
    {

        // Text scoreText = GetComponent<Text>();
        // 왜?

        scoreText.text = "Score : 0";
        speed = 1000;
        rb = GetComponent<Rigidbody>();
        // GetComponent<T>() : 게임 오브젝트에 붙어있는 컴포넌트를 가져오는 기능
        // T : Type
        Debug.Log("설정이 완료되었습니다!");
    }

    void Update()
    {
        // speed += 1;
        // Debug.Log($"속도가 1 증가합니다. 현재 속도는 {speed}입니다.");

        float horizontal = Input.GetAxis("Horizontal"); // 수평 이동

        // 수직 이동
        float vertical = Input.GetAxis("Vertical");

        // 이동 좌표(벡터) 설정
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        if(obsOn == true) {
            rb.AddForce((movement * -100f) * Time.deltaTime);
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

            score++;
            scoreText.text = $"Score = {score * 10}";

            obsOn = true;
            other.gameObject.SetActive(false);
        }
    }

}