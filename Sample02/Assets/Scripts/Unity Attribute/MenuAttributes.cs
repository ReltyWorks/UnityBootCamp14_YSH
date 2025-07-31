using UnityEngine;

/*
Attribute : C#���� �����ϰ�, ����Ƽ���� �����Ѵ�. 
            Ŭ������ �Լ�, ���� �տ� �ٴ� []���� Attribute(Ư��)
            �����Ϳ� ���� Ȯ���̳� ����� ���� �� ���ۿ��� �����Ǵ� ��ɵ�
��� ���� : ����ڰ� �����͸� �� ����������, ���������� ����ϱ� ���ؼ�

1. AddComponentMenu("�׷��̸�/����̸�")
    Editor�� Component�� �޴��� �߰����ִ� ���
    �׷��� ���� ��� �׷��� �����Ǹ�, �ƴ� ��쿡�� ��ɸ� �����˴ϴ�.
    ���� ���� ���� ������ ���� ���� ������ ������ �ֽ��ϴ�.
    (1) Ư������ (2) ���� (3) �빮�� (4) �ҹ���

*/


//
//
[AddComponentMenu("Sample/AddComponentMunu")]
public class MenuAttributes : MonoBehaviour {

    // [ContextMenuItem("������� ǥ���� �̸�", "�Լ��� �̸�")]
    // message(����)�� ������� MessageReset ����� �����Ϳ��� ����� �� �ֽ��ϴ�.
    // �ν����� â���� Message(����) ��� �ؽ�Ʈ�� ��Ŭ���ϸ�,
    // "�޼��� �ʱ�ȭ"(�޴���)��� �޴��� ���̰�, Ŭ���ϸ� MessageReset(�Լ�)�� �۵��ȴ�.
    [ContextMenuItem("�޼��� �ʱ�ȭ", "MessageReset")] public string message = "";

    public void MessageReset() {
        message = "";
    }

    // [ContextMenu("������� ǥ���� �̸�")]
    // �ν����Ϳ��� ������Ʈ��(�� ��ũ��Ʈ �̸�)�� ��Ŭ���ϸ�
    // "��� �޼��� ȣ��"(�޴���)��� �޴��� ���̰�,
    // Ŭ���ϸ� MenuAttributesMethod(�޼���)�� �۵��ȴ�.
    [ContextMenu("��� �޼��� ȣ��")]
    public void MenuAttributesMethod() {
        Debug.LogWarning("�߸���!");
    }
}
