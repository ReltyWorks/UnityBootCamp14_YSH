using UnityEngine;
using UnityEngine.Events;

public class UnityEventSample : MonoBehaviour {

    // ������ �ν����Ϳ��� �ʵ� ���� ���콺�� �÷��� �� ������ �����ִ� ���
    [Tooltip("�̺�Ʈ ����Ʈ�� �߰��ϰ�, ������ ����� ���� ���� ������Ʈ�� ����ϼ���.")]
    public UnityEvent action;

    private void Update() {
        action.Invoke(); // Invoke��� �Լ��� ���ؼ� action�� ��ϵ� �Լ��� ����
    }

    public void Move() {
        gameObject.transform.Translate(0, 1, 0);
    }


}
