using UnityEngine;

public class SampleSpawner : MonoBehaviour
{
    // �ش� ������Ʈ�� ���� �� ������Ʈ�� �����ϰ�, ������Ʈ�� �ο��ϱ�
    void Start()
    {
        GameObject sample = GameObject.Find("Sample");
        // 1) '���� ������Ʈ'Ŭ���� 'sample'�� ������
        // 2) ���� ������Ʈ, �̸��� "Sample"�� ������ ã�Ƽ� ���� ������Ʈ ������ 'sample'�� ����

        // ������Ʈ Ž�� ����� ���� ���
        if (sample == null) { // 3) Ž�� ����� ������
            GameObject go = new GameObject("Sample");
            // 4) ���� ������Ʈ Ŭ���� 'go'�� ���� "Sample"�� ���� ���� ������ ����.
            //go.AddComponent<Sample>(); //
        } else {
            Debug.Log("�̹� �����մϴ�.");
        }
    }
}
