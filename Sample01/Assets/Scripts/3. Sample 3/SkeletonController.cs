using UnityEngine;
// ��ư�� OnClick�� ����� ���


public class SkeletonController : MonoBehaviour
{
    public GameObject skeleton;

    public void OnLButtonEnter() {
        if (skeleton.transform.position.x > -4f) {
            skeleton.transform.Translate(0.5f, 0, 0);
        }

    }
    public void OnRButtonEnter() {
        if (skeleton.transform.position.x < 4f) {
            skeleton.transform.Translate(-0.5f, 0, 0);
        }
    }
    // UI��ư�� OnClick ��� ���
    // 1. ��ư ������Ʈ Ŭ��(LButton, RButton)
    // 2. OnClick�� + ��ư�� ���� ����� �߰��մϴ�.
    // 3. ������Ʈ�� ����ϸ� �ش� ������Ʈ�� ���� ������Ʈ / ��ũ��Ʈ�� �޼��带 ��� �� �� ����
}
