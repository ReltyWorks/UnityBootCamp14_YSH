using System.Collections;
using UnityEngine;

// �Ѿ˿� ���� ����, �Ѿ� �ݳ�, �Ѿ� �̵�
public class Bullet : MonoBehaviour {

    [Range(0, 100)] public float speed = 5.0f; // �Ѿ� �̵� �ӵ�
    [Range(0, 100)] public float life_time = 2.0f; // �Ѿ� �ݳ� �ð�
    public GameObject effect_prefab; // ����Ʈ ������

    private BulletPool pool; // Ǯ
    private Coroutine life_coroutine;


    public void SetPool(BulletPool pool) => this.pool = pool;

    private void OnEnable() {
        life_coroutine = StartCoroutine(IEBulletReturn());
    }

    private void OnDisable() {
        if (life_coroutine != null) StopCoroutine(life_coroutine);
    }

    private void Update() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    IEnumerator IEBulletReturn() {
        yield return new WaitForSeconds(life_time);
        pool.BulletReturn(gameObject);
    }

    private void OnTriggerEnter(Collider other) {

        // �ε��� ����� Enemy �±׸� ������� �ִ� ������[��Ʈ�� ���
        // �������� �����ϴ�. �� ���� ������ ���� �ڵ� �ۼ�

        // ����Ʈ ���� (��ƼŬ)
        if (effect_prefab != null) Instantiate(effect_prefab, transform.position, Quaternion.identity);

        pool.BulletReturn(gameObject);
    }

    // �޼ҵ��� ����� 1���� ���, ���ٽ�
    void ReturnPool() => pool.BulletReturn(gameObject);
}
