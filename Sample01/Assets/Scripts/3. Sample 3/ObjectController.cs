using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("mini simple skeleton demo");
    }

    void Update()
    {
        transform.Translate(0, -5f * Time.deltaTime, 0);

        if (transform.position.y < -1) {
            Destroy(gameObject);
        }

        // 충돌 판정 처리
        // 원에 의한 충돌 판정 로직 사용
        Vector3 v1 = transform.position;
        Vector3 v2 = player.transform.position;

        Vector3 dir = v1 - v2;

        float d = dir.magnitude; // 벡터의 크기 또는 길이를 의미
        // 두 점 사이의 거리를 계산할 때 사용

        float obj_r1 = 0.8f;
        float obj_r2 = 1.0f;

        if (d < obj_r1 + obj_r2) { // 이 계산을 하느니 리지드바디를 쓰는게 낫지만,
            Destroy(gameObject); // 연구용으로 만들어봄
        } // 이 기믹을 꼭 확인하고 학습해놔야함


    }
}
