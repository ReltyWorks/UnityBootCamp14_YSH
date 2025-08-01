using UnityEngine;
// 플레이어를 45도 방향으로 직진하는 코드

public class AngleMove : MonoBehaviour {
    [SerializeField] float angle_degree; // 각도(도)
    [SerializeField] float speed;        // 속도(움직일 때 쓸 수치)

    Vector3 pos; // 좌표(위치)
    void Update() {
        var radian = Mathf.Deg2Rad * angle_degree;
        Vector3 pos = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0);

        transform.Translate(pos * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Return)) {
            transform.position = Vector3.zero;
        }
    }
}
