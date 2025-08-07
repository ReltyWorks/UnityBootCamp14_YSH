using UnityEngine;

public class MouseLook : MonoBehaviour {
    [Range(1f, 100f)]public float sensitivity = 2.0f;    // 마우스 감도
    [Range(1f, 100f)]public float smoothness = 10.0f;    // 회전 부드러움 정도

    public float minRotationY = 130.0f;
    public float maxRotationY = 240.0f;

    private float currentYRotation;     // 마우스 움직임을 계속 더해줄 변수

    void Start() {
        // 게임 시작하면 마우스 커서를 화면 안에 가두고 안 보이게 만들어
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        // 마우스의 좌우 움직임 값을 받아와서 감도를 곱해준다
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // 받아온 마우스 값을 계속 더해서 총 회전량을 계산한다
        currentYRotation += mouseX;

        // 클램프 함써본다. 씨발쎾쓰!
        currentYRotation = Mathf.Clamp(currentYRotation, minRotationY, maxRotationY);

        //계산한 총 회전량(오일러 각)을 쿼터니언으로 변환한다
        Quaternion targetRotation = Quaternion.Euler(0f, currentYRotation, 0f);

        // 어렵다 어려워
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothness);
    }
}