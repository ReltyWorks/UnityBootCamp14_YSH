using UnityEngine;
using UnityEngine.Events;
/*
����Ƽ�� �Է� �ý���
A. Input Manager - ���� ��� ó��(�Լ�)
Edit -> Project Settings -> input
Input.GetAxis("Ű �̸�") -1~1������ '�Ǽ�' ����Ȯ��
Input.GetAxisRaw("Ű �̸�") -1, 1, 0 �� ��ȯ, �ݿø��� �ƴ�, 0�� �������� ���ݸ� �ٲ� -1, 1 ��ȯ��
Input.GetButton("��ư �̸�") �ش� ��ư�� ���� ��ŭ true (������ ������ ��� �ö�)
Input.GetButtonDown("��ư �̸�") �ش� ��ư�� ������ �� 1�� true
Input.GetButtonUp("��ư �̸�") �ش� ��ư�� ������ �� 1�� true

���콺 �Է� 0 ����, 1 ������ ,2 �߾�(��)
Input.mousePosition���콺�� ȭ�鳻�� ��ġ

Unity Input System
����Ƽ 2019���� ���ĺ��� New Input System
1. ��Ƽ �÷��� ����(�پ��� ����̽����� ������ �ڵ�� �Է� ����)
2. ���� �Է� ���ε�(����ڰ� ���� ������ Ű ���� ���� ����)
3. �̺�Ʈ ����� �Է�(������ ���Žô� ���� ���, ������ ��ǲ �ý����� �̺�Ʈ ���)
4. �Է� �׼� �ý���(�׼��� ���� �پ��� �Է¿� ���� ó���� �� ������ ���� ����)
*/



[ExecuteInEditMode]
public class PlayerStat : MonoBehaviour
{
    public enum Job {
        ����, ����, ������, ����,
    }

    [Header("<Status>")]
    public string name = "Player";
    public int level = 1;
    public Job job = Job.����;
    public int str = 0;
    public int wis = 0;
    public int dex = 0;

    [Header("<Editor>")]
    [Space(30)]
    public bool tryEdit = false;
    public bool valuePlus = true;

    [Space(10)]
    public UnityEvent Editor;


    public void Update() {
        if (!Application.isPlaying && tryEdit) {
            Editor.Invoke(); // Invoke��� �Լ��� ���ؼ� action�� ��ϵ� �Լ��� ����
        }
    }

    public void StrEdit() {
        if (valuePlus) str++;
        else str--;
    }
    public void WisEdit() {
        if (valuePlus) wis++;
        else wis--;
    }
    public void DexEdit() {
        if (valuePlus) dex++;
        else dex--;
    }
}
