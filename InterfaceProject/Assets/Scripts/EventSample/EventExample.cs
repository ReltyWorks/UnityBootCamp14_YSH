using System;
using UnityEngine;
// C# Event 526 page

// event : Ư�� ��Ȳ�� �߻����� �� �˸��� ������ ��Ŀ����
// 1. �÷��̾ �׾��� ��, �˸� ���� > �޼ҵ� ȣ��

// Action : �Ű����� ���� ���ϰ� ����

/*
public class Tester : MonoBehaviour {
    void Start() {
        EventExample eventExample = new EventExample();
        eventExample.onDeath?.Invoke();
        // eventExample.onStart?.Invoke(); <- ������
        // event Action�� ��� �ܺο��� ȣ�� �Ұ���
        eventExample.onDeath = null; // �����Ѱ� �� ����
        // onStart�� �ȵ�, �� event Action�� ��������
        eventExample.onStart += Sample; // ������ ����
        eventExample.onStart -= Sample; // ������ ����
        // �������ڸ�, event Action�� ������ �Լ����� Ȯ���ؼ� ���
    }
    private void Sample() { }
}
                    Action      vs      event Action
�ܺ� ȣ��               O                       X
�ܺ� ����               O                       X
���� ���               O                       O
���� ����               O                       O
�� �뵵            ���η���, �ݹ�            �̺�Ʈ �˸�

���� �����ϸ�, event Action�� �ܺο��� �����Ǿ����� ������ ���� �� ������
�������� üũ�ؼ� ����ϸ��! �����ʿ��ϸ� event Action!
*/

public class EventExample : MonoBehaviour {

    // Action vs event Action?? ���� Tester Ȯ��!
    public Action onDeath;
    public event Action onStart;

    void Start () {
        // �׼��� +=�� ���� �Լ�(�޼���)�� �׼ǿ� ����� �� �ֽ��ϴ�. (����)
        // �׼��� -=�� ���� �Լ�(�޼���)�� �׼ǿ��� ������ �� �ֽ��ϴ�. (����)
        // �׼��� ����� ȣ���ϸ� ��ϵǾ��ִ� �Լ��� ���������� ȣ��˴ϴ�.
        onStart += Ready;
        onStart += Fight;

        onDeath += Damaged;
        onDeath += Dead;

        onStart?.Invoke(); // Invoke();�� �׼ǿ� ��ϵ� ����� �����ϴ� �ڵ�
        onDeath();

        // ���� ����? ����. ���� ��Ÿ�� ����
        // Invoke ����̸� null üũ ����, �ܺο����� ȣ��, ������ �䱸�� ��õ
        // �Լ� ���¸� ���� ����, ���� �ڵ��̰ų� �ܼ� ȣ���� ��� �ش� ��� ��õ
    }
    private void Ready() {
        Debug.Log("<color=cyan><b>Ready??</b></color>");
    }
    private void Fight() {
        Debug.Log("<color=yellow><b>Fight!!</b></color>");
    }

    private void Damaged() {
        Debug.Log("<color=red><b>Critical Damage!!</b></color>");
    }
    private void Dead() {
        Debug.Log("<color=blue><b>A Hero is Fallen.</b></color>");
    }
}
