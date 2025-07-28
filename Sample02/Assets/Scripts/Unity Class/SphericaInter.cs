using UnityEngine;

// 구면 선형보간(Spherically interpolate)

// Lerp와 Slerp가 사용되는 경우
// 1. 단순한 위치 이동 Lerp or Slerp? -> Lerp
// 2. 회전 및 방향 전환 Lerp or Slerp? -> Slerp
// 3. 자연스러운 카메라의 움직임 Lerp or Slerp? -> Slerp
// 쉽게말해 회전 및 방향 전환이 들어간다면 slerp를 사용

// Lerp -> 직선 이동, 체력 게이지 등이 일정하게 변화하는 경우
// Slerp -> 회전이나 각도의 개념이 필요한 경우, 3D 회전(쿼터니언) / 벡터 간의 곡선 경로 확인 / 방향 회전이 부드럽게 대상 방향을 바라봐야 할 경우

public class SphericaInter : MonoBehaviour {

    // 
    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0.0f;

    private void Start() {
        start_position = transform.position;
    }
    private void Update() {
        if (t < 1.0f) {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Slerp(start_position, target.position, t);
        }
    }
}
