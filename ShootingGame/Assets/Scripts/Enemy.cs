using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 5f;
    public GameObject explosionFactory;
    public EnemyType type = EnemyType.Down;
    Vector3 dir;

    public enum EnemyType {
        Down, Chase
    }

    void Start() {
        PatternSetting();
    }

    void Update() {
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other) {
        ScoreManager.Instance.SetScore(10);
        GameObject explosion = Instantiate(explosionFactory, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (other.gameObject.tag != "DestroyZone") Destroy(other.gameObject);
    }

    void PatternSetting() {
        int rand = Random.Range(0, 10);

        if (rand < 3) {
            type = EnemyType.Chase;
            GameObject target = GameObject.FindGameObjectWithTag("Player"); // Ÿ���� �÷��̾�
            dir = target.transform.position - transform.position; // Ÿ�� ��ġ - ���� ��ġ = ����
            dir.Normalize(); // ������ ũ��� 1�� �����մϴ�.
        }
        else {
            dir = Vector3.down;
        }
    }
}