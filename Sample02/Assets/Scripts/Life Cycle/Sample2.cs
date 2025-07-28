using UnityEngine;

public class Sample2 : MonoBehaviour
{
    public Sample1 Sample1;
    private void Awake() {
        Sample1 = GameObject.FindWithTag("s1").GetComponent<Sample1>();
        // 1. GameObject.FindWithTag("�±��̸�")
        // >> ������ �ش� �±׸� ������ �ִ� ������Ʈ�� �˻��ϴ� ���
        //      �� ����� ���� �޾ƿ��� �� > gameObject

        // 2. gameObject.GetComponent<T>
        // >> ���� ������Ʈ�� GetComponent<T>�� ���� T�� ������Ʈ�� ������
        //      �ۼ����ָ� �ش� ���ӿ�����Ʈ�� ������Ʈ�� ������ �ִ� ���� �����ɴϴ�.
        //      �� ����� ���� �޾ƿ��� �� > T

        // public <T> Sample1;
        // Sample1 = GameObject.FindWithTag("s1").GetComponent<T>();
        // T�� ��ġ�� ����

        Debug.Log(Sample1.cc.message);
    }
}