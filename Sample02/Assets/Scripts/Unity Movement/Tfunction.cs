using UnityEngine;
// �ﰢ �Լ� (������ �����Ѵ�)
// ����Ƽ���� �������ִ� �ﰢ�Լ��� �ַ� ȸ��, ī�޶� ����, �, �����ӿ� ���� ǥ������ ���˴ϴ�.

// Ư¡) ������ �������� ����մϴ�. 1���� = �� 57��
//
public class Tfunction : MonoBehaviour {
    // ���
    // Sin(Radian) : �־��� ������ Y ��ǥ (���� ���� ��ġ)
    // Cos(Radian) : �־��� ������ X ��ǥ (���� ���� ��ġ)
    // Tan(Radian) : �־��� ������ ���� ( Y / X )

    public void ButterFly() {
        float t = Time.time * 2;
        float x = Mathf.Cos(t) * 2;
        float y = Mathf.Sin(t * 2f) * 2 * 2;

        transform.position = new Vector3(x, y, 0);
    }

    // Time.time : �������� ������ ���������� �ð�
    // Time.deltaTime : �������� �����ϰ� ������ �ð�


    // ���� ȸ��
    public void CircleRotate() {
        float angle = Time.time * 90.0f;
        float radian = angle * Mathf.Deg2Rad; // ���� �ش� ���� �����ָ� �������� ��ȯ�˴ϴ�.

        var x = Mathf.Cos(radian) * 5.0f; // Cos�̶�?
        var y = Mathf.Sin(radian) * 5.0f; // Sin�̶�?

        transform.position = new Vector3(x, y, 0);
    }

    public void Wave() {
        var offset = Mathf.Cos(Time.time * 2.0f) * 10f;
        transform.position = pos + Vector3.up * offset;
    }

    Vector3 pos; // ��ǥ(��ġ)

    private void Start() {
        pos = transform.position;
    } // ������ �� ������Ʈ�� ��ġ ����

    void Update() { // ����Ŭ�� ����,
        if (Input.GetMouseButton(0)) CircleRotate();
        else if (Input.GetMouseButton(1)) Wave();
        else if (Input.GetMouseButton(2)) ButterFly();
    }
}
