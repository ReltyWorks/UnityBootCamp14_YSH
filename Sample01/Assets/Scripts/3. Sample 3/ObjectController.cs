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

        // �浹 ���� ó��
        // ���� ���� �浹 ���� ���� ���
        Vector3 v1 = transform.position;
        Vector3 v2 = player.transform.position;

        Vector3 dir = v1 - v2;

        float d = dir.magnitude; // ������ ũ�� �Ǵ� ���̸� �ǹ�
        // �� �� ������ �Ÿ��� ����� �� ���

        float obj_r1 = 0.8f;
        float obj_r2 = 1.0f;

        if (d < obj_r1 + obj_r2) { // �� ����� �ϴ��� ������ٵ� ���°� ������,
            Destroy(gameObject); // ���������� ����
        } // �� ����� �� Ȯ���ϰ� �н��س�����


    }
}
