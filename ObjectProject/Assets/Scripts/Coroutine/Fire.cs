using UnityEngine;

// �� �ڵ�� �Ѿ˿� ���� �߻�(����) ��ɸ� ����մϴ�.
public class Fire : MonoBehaviour {

    // �Ѿ� �߻縦 ���� Ǯ
    public BulletPool pool;

    // �Ѿ� �߻� ����
    public Transform pos;

    // �Ѿ� �߻� �ӵ�
    public float speed = 2.0f;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            pool = GameObject.Find("Pool").GetComponent<BulletPool>();
            var bullet = pool.GetBullet();
            bullet.transform.position = pos.position;
            bullet.transform.rotation = pos.rotation;
        }
    }
}
