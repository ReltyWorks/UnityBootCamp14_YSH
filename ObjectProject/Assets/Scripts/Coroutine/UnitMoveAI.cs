using System.Collections;
using UnityEngine;

public class UnitMoveAI : MonoBehaviour {

    [Range(0, 100)] public float speed = 2.0f; // 이동 속도
    [Range(0, 100)] public float detetion = 10.0f; // 검색 위치

    private Transform player_position; // 플레이어 위치

    void Start() {
        player_position = GameObject.FindGameObjectWithTag("Player")?.transform;
        // (? 연산자 활용) : 객체가 null 일 떄 발생할 오류 방지
        // GameObject.FindGameObjectWithTag("Player")?.transform 와 같이 작성을 하면 해당 값을
        // Nullable 타입으로 변경합니다. (값이 없을 때만)

        if (player_position != null) StartCoroutine(Move());
        else Debug.LogWarning("게임 내에서 플레이어를 찾을 수 없습니다.");
    }

    IEnumerator Move() {
        while (player_position != null) {
            float distance = Vector3.Distance(transform.position, player_position.position);

            // 플레이어가 지정된 거리 내에 있다면?
            if (distance <= detetion) {
                Vector3 dir = (player_position.position - transform.position).normalized;

                transform.position = Vector3.MoveTowards(transform.position, player_position.position, speed * Time.deltaTime);
            }
            else {
                // 거리 내에 없을 때 메세지 등을 남기고 싶으면 이쪽
            }
        yield return null;
        }
    }
}