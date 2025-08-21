using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
        if (other.gameObject.layer != 7) Destroy(other.gameObject);
        if (other.gameObject.layer == 8) {
            FileManager.Instance.GameOver();
            EnemyManager.Instance.GameOver();
        }
        Destroy(gameObject);
    }

    void PatternSetting() {
        int rand = Random.Range(0, 10);

        if (rand < 3) {
            type = EnemyType.Chase;
            GameObject target = GameObject.FindGameObjectWithTag("Player"); // 타겟은 플레이어
            dir = target.transform.position - transform.position; // 타겟 위치 - 본인 위치 = 방향
            dir.Normalize(); // 방향의 크기는 1로 설정합니다.
        }
        else {
            dir = Vector3.down;
        }
    }
}