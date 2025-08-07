using UnityEngine;

public class MouseLook : MonoBehaviour {
    [Range(1f, 100f)]public float sensitivity = 2.0f;    // ���콺 ����
    [Range(1f, 100f)]public float smoothness = 10.0f;    // ȸ�� �ε巯�� ����

    public float minRotationY = 130.0f;
    public float maxRotationY = 240.0f;

    private float currentYRotation;     // ���콺 �������� ��� ������ ����

    void Start() {
        // ���� �����ϸ� ���콺 Ŀ���� ȭ�� �ȿ� ���ΰ� �� ���̰� �����
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        // ���콺�� �¿� ������ ���� �޾ƿͼ� ������ �����ش�
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // �޾ƿ� ���콺 ���� ��� ���ؼ� �� ȸ������ ����Ѵ�
        currentYRotation += mouseX;

        // Ŭ���� �Խẻ��. ���ߛ徲!
        currentYRotation = Mathf.Clamp(currentYRotation, minRotationY, maxRotationY);

        //����� �� ȸ����(���Ϸ� ��)�� ���ʹϾ����� ��ȯ�Ѵ�
        Quaternion targetRotation = Quaternion.Euler(0f, currentYRotation, 0f);

        // ��ƴ� �����
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothness);
    }
}