using UnityEngine;
using System;

// 1. EventArgs�� ����� Ŀ���� Ŭ���� �����

public class DamageEventArgs : EventArgs {
    // ������ ���� ���� ����
    // ������Ƽ�� �۾��ϸ�, get��ɸ� �ַ� Ȱ��ȭ �մϴ�.
    public int Value { get; } // Value�� ���� ���ٸ� ����
    public string eventName { get; }

    // EventArgs�� ���� ������ �߻��ϸ� ���� �����˴ϴ�.(������)
    public DamageEventArgs(int value, string name ) {
        Value = value;
        eventName = name;
    }
}

public class EventSample4 : MonoBehaviour {
    public event EventHandler<DamageEventArgs> OnDamage;
    // �������� �޾��� ���� ���� �̺�Ʈ �ڵ鷯

    public void TakeDamage(int value, string name) {
        // ���޹��� ���� �������� ������ �̺�Ʈ �Ű������� ������
        // �ڵ鷯 ȣ�� ���� ������ �����մϴ�.
        OnDamage?.Invoke(this, new DamageEventArgs(value, name));

        Debug.Log($"<color=white>[{name}] �÷��̾ {value} �������� �޾ҽ��ϴ�.</color>");
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.A)) {
            TakeDamage(UnityEngine.Random.Range(10, 200), "������");
        }
    }
}
