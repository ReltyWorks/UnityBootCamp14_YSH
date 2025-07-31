using UnityEngine;

public class CameraWork : MonoBehaviour {
    // ���� ������Ʈ Ÿ�� ���� player
    public GameObject player;

    // ī�޶�� �÷��̾� ������ ���� offset
    private Vector3 offset;

    void Start() {
        // ī�޶�� �÷��̾��� �Ÿ� ���̸� offset�� ������ �����մϴ�.
        offset = transform.position - player.transform.position;
    }

    // ������Ʈ���� ó���� �κ��� �� ó���� �Ŀ� ȣ��Ǵ� ��ġ
    // ī�޶� �۾����� ���� ����� (������Ʈ ������ ������ ���)
    private void LateUpdate() {
        // ī�޶��� ��ġ�� �÷��̾���� ���� �Ÿ��� �����Ѵ�.(offset)
        transform.position = player.transform.position + offset;
    }
}