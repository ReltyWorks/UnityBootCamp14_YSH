using UnityEngine;

public class Sample1 : MonoBehaviour
{
    public CustomComponent cc;
    private void Awake() {
        // ������Ʈ�� ���� ���� ����
        cc = GetComponent<CustomComponent>();
    }
}
