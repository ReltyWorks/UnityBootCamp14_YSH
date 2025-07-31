using UnityEngine;
using UnityEngine.InputSystem;
// InputSystem�� ����ϱ����� InputSystem�� ��¡�Ѵ�!?

// Player Input�� �����ؾ� ��밡��

//[RequireComponent(typeof(T))]
// �� �� ��ũ��Ʈ�� ������Ʈ�� ����� ��� �ش� ������Ʈ��
// �ݵ�� T�� ������ �־�� �մϴ�. ���� ����� �ڵ�����
// ������ְ�, �� �ڵ尡 �����ϴ� �� �����Ϳ���
// ���� ������Ʈ�� �ش� ������Ʈ�� ������ �� �����ϴ�.

[RequireComponent(typeof(PlayerInput))]
public class wowInputSys : MonoBehaviour {

    // ���� Action Map : Sample
    //      Action : Move
    //      Type : Value
    //      Compos : Vector2
    //      Binding : 2D Vector(WASD)

    private Vector2 veiwCamera;
    private Vector2 moveInputValue;
    private float speed = 3.0f;

    // PlayerInput ������Ʈ�� Behavior��
    // Send Messages�� ���Ǵ� ���
    // Ư�� Ű�� ������, Ư�� �Լ��� ȣ���մϴ�.
    // �Լ� ���� On + Actions name, ���� ���� Action�� �̸��� move���
    // �Լ� ���� OnMove�� �˴ϴ�.

    void OnLook(InputValue value) {
        veiwCamera = value.Get<Vector2>();
    }

    void OnMove(InputValue value) {
        moveInputValue = value.Get<Vector2>();
    }


    void Update() {
        Vector3 look = new Vector3(veiwCamera.x, 0, veiwCamera.y);
        Vector3 move = new Vector3(moveInputValue.x, 0, moveInputValue.y);
        transform.Translate(move * speed * Time.deltaTime);
        transform.Rotate(look * speed * Time.deltaTime);
    }
}
