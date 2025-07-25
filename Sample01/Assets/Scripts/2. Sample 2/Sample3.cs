/*
����Ƽ���� �����Ǵ� Ŭ������ ����� ��ũ��Ʈ�� �ۼ��մϴ�.

 1. ����Ƽ�� Transform Ŭ���� ���
 Ʈ�������� ����Ƽ �����Ϳ��� ���� ������Ʈ�� ������ ��,
 ��� ���� ������Ʈ�� �⺻������ �ο��Ǵ� ������Ʈ�� �ǹ���
 �ش� ������Ʈ�� ��ġ(Position), ȸ��(Rotation), ũ��(Scale)�� ���� ������ ����
 ������Ʈ�� ����� ȣ���ϴ� GetComponent<T>�� ������� �ʰ� �ٷ� ����� ����

 �� �ش� Ŭ������ �������ִ� �Ӽ�(Property)

 transform.position
    ���� ������Ʈ�� ��ġ ������ �ǹ�
    Vector3 ������ ������, (x, y, z)�� float�� ����
 transform.rotation
    ���� ������Ʈ�� ȸ�� ������ �ǹ� (�ε巯�� ȸ��)
    Quaternion ������ ������, (x, y, z, w)�� float�� ����
 transform.forward
    ���� ������Ʈ ������ ������ ��Ÿ���� ��
 transform.up
    ���� ������Ʈ ������ ����� ��Ÿ���� ��
 transform.right
    ���� ������Ʈ ������ �������� ��Ÿ���� ��
 transform.eulerAngles
    ���� ������Ʈ�� ȸ�� ������ �ǹ� (������ ȸ��)

 �� �ش� Ŭ������ �������ִ� �ֿ� ����(�޼ҵ�)

 transform.LookAt(Transform target)
    ������Ʈ�� �־��� Ÿ���� ���ϵ��� ���� ������Ʈ�� ȸ����Ű�� ���
 transform.Rotate(Vector3 eulerAngles)
    ���޹��� ������ �������� ���� ������Ʈ�� ȸ����Ű�� ���
 transform.Translate(Vector3 translation)
    �־��� ���͸�ŭ ���� ������Ʈ�� �̵���Ű�� ���
*/

using UnityEngine;


public class Sample3 : MonoBehaviour
{
    // transform�� �̿��� ������Ʈ�� ������Ʈ ����
    public GameObject go;

    void Start()
    {
        // Ʈ�������� �̿��ؼ� �ٸ� ������Ʈ�� ������Ʈ�� ������ �� �ִ�.
        Debug.Log(go.transform.GetComponent<Sample4>().value);

    }

    void Update()
    {
        
    }
}
