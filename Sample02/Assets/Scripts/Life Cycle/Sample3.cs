using UnityEngine;

// ������Ʈ ĳ�̿� ���Ͽ�(Object Cashing)

// ĳ��(Cashe)
// ���� ���Ǵ� �����ͳ� ���� �̸� �����صδ� �ӽ� ���

// ĳ�� ��� �ǵ�
// 1. �ð� ������ : ���� �ֱٿ� ���� ���� �ٽ� ���� ���ɼ��� ����.
// 2. ���� ������ : �ֱٿ� ������ �ּҿ� ������ �ּ��� ������ ���� ���ɼ��� ����.

public class Sample3 : MonoBehaviour
{
    Rigidbody rb;
    Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // ĳ��(cashing)
    }

    void Update()
    {
        // GetComponent<Rigidbody>().AddForce(pos * 5); // �����Ӹ��� ��ü ȣ��
        rb.AddForce(pos * 5); // ĳ���� �� �����͸� ȣ��
    }
}
