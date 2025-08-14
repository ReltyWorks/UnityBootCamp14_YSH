using System;
using UnityEngine;

public class ActionFuncExample : MonoBehaviour {
    
    // Action<T>�� �ִ� 16���� �Ű������� ���� �� �ֽ��ϴ�.
    // ��ȯ ���� �����ϴ�. (void)
    // ������ �����̸�, ����� ���� �ʴ� ����

    public Action<int> myaction;
    public Action<int, string> myaction2;

    // Func�� �������� ������ �κ��� Func�� ����� �Լ��� ��ȯ Ÿ���Դϴ�.
    public Func<bool> func01;
    public Func<string, int> func02;

    bool AttackAble() {
        int rand = UnityEngine.Random.Range(0, 10);
        return rand <= 3 ? true : false;
    }

    int result(string s) => int.Parse(s);

    void Start() {
        myaction += Rage;
        // myaction += Heal; �ȵ�!
        // myaction += Rage; �ȵ�!
        myaction2 += Heal;
        myaction(50);
        myaction2(40, "Steve");

        func01 = AttackAble;
        if (func01()) Debug.Log("���� ����");
        else Debug.Log("���� ����...");

        func02 = result;
        int point = func02("14");

        func01 = () => point > 10 ? true : false;
    }

    void Rage(int value) {
        Debug.Log($"�г�� ���� ���ݷ��� <color=red><b>{value}</b></color> ��ŭ ����մϴ�!");
    }

    void Heal(int value, string character) {
        Debug.Log($"ȸ�� �������� <color=yellow><b>{character}</b></color>�� <color=green><b>{value}</b></color> ��ŭ ȸ���մϴ�!");
    }

}
