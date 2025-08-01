using UnityEngine;
/*
RayCast : ���� ��ġ���� Ư�� �������� ������ ������ �i�� ��
�ε����� ������Ʈ�� �ִ����� �Ǵ��մϴ�.
1) Ư�� ������Ʈ�� �浹 �������� �����ϴ� �۾� ����
2) Ư�� ������Ʈ�� ���� �浹 ������ Ȯ���ϴ� �뵵








*/




public class RayCastSample : MonoBehaviour {
    RaycastHit hit; // �浹 ������ ����
    // ref : ������ ������ ����, ������ �޼ҵ� �ȿ��� ����� �� ������ �˸��� �뵵
    // out : ������ ������ ����, ���� ���� ���� ������ ���� �ʱ�ȭ�� ������ �ʿ䰡 ����

    // Physics.RayCast(Vector3 origin, Vector3 direction, out RayCastHit hitInfo,
    // float maxDistance, int layerMask);

    // origin�� ���⿡�� direction�� �������� maxDistance ������ ������ �߻��մϴ�.

    // hitInfo�� �浹ü�� ���� ������ �ǹ��մϴ�.

    const float length = 10.0f;

    void Update() {

        // ������Ʈ�� ��ġ���� �������� length��ŭ�� ���̿� �ش��ϴ� ����� ������ ��� �ڵ�
        // �ַ� ����ĳ��Ʈ �۾����� ���̰� �Ⱥ��̱� ������ �����ִ� �뵵�� ����մϴ�.
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);

        // ���� ��ư�� ������ ��� 
        if (Physics.Raycast(transform.position, transform.forward, out hit, length)) {
            Debug.Log("������ �߽�");
            hit.collider.gameObject.SetActive(false); // ������ ����
        }

    }
}
