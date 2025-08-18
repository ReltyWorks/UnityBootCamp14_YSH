using UnityEngine;
using UnityEngine.Events;
// ����Ƽ Event, EventArgs�� ����ϱ� ���ؼ�
// UnityEngine.Events ���ӽ����̽� ������ �ʼ��Դϴ�.

// C#�� Event���� ������
// 1. �ν����Ϳ��� Ȯ���� �����ϴ�.
// 2. �߰� ���� ����� +=, -=�� ���� �ʰ� AddListener�� RemoveLister�� �����մϴ�

//                    UnityAction            vs            UnityEvent
// Ÿ��                 delegate                              class
// ���                 �Լ� ����                  �����Ϳ��� �ڵ鷯 ���� ��� ����
// ����                   +, -                   AddListener(), RemoveListener()
// ����� ��Ȳ        ��ũ��Ʈ �ڵ� �� ó��             �ν����Ϳ� �̺�Ʈ �ý���
// �ӵ�                   ����                 ����(���� ������ ���� �Ľ� �� ��Ÿ�� ���� ���)
// �޸�                 ����                                  ����
// GC �߻� ����            ����                                 ����
// ���Ǽ�              ��ü ���� �ؾ���                 �ٷ� ��� ����, ���� ����

// UnityAction�� UnityEvent�� ����ϴ� �ڵ带 ������ �� ȿ�����Դϴ�.
// �Ϲ� delegate�� UnityAction<T>�� ���� Ÿ�Կ� ���� ������ �ȵǾ��־�
// ���� ���� ����ؾ� �մϴ�.

// ����Ƽ �۾� �� ����� �� �ִ� delegate ���� ������ ����
// 1. C# delegate
// 2. Unity UnityAction
// 3. C# Func<T>, Action<T>

// �� �پ��� delegate����
// ���� ��� ����ؾ� �ϴ°�?

// ������ ���Ѵ�. -> C# delegate
// �ݹ� -> Aciton, UnityAction
// UnityEvent���� �ν����� ���� -> UnityAction
// �̺�Ʈ �ñ״�ó �ʿ�(�����ϰ� ���� ����) -> delegate, Func, Action

// �̺�Ʈ �ñ״�ó - ȣ��Ǵ����� ������ �Լ��� ����
// ex. C#�� EventHandler�� ����
// ex. delegate void EventHandler(object sender, EventArgs e);
// �ñ״�ó
// 1. ��ȯŸ�� (void)
// 2. �Ű����� (object, EventArgs)

public class EventSample3 : MonoBehaviour {
    public UnityEvent OnKButtonEnter;
    public UnityAction OnAction;

    void Start() {
        // OnKButtonEnter += Sample(); ����!
        OnKButtonEnter.AddListener(Sample);
        // AddListener(UnityAction call)��
        // UnityAction�� �޼ҵ�� �����ϸ� ����

        OnAction += Sample2;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            OnKButtonEnter?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            OnAction?.Invoke();
        }
    }
    
    private void Sample() {
        Debug.Log("<color=cyan>Sample3_Sample ����</color>");
    }
    private void Sample2() {
        Debug.Log("<color=red>Sample3_Sample2 ����</color>");
    }
}
