using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [Header("�� ������ ����")]
    [Tooltip("�� ���� Ǯ")] public GameObject enemyFactory;
    [Tooltip("�� ���� ����")] public GameObject spawnArea;
    [Tooltip("�� ���� �ð� �ּ�")] public float minCT = 1f;
    [Tooltip("�� ���� �ð� �ִ�")] public float maxCT = 5f;
    float createTime;
    float currentTime;

    void Update() {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) {
            var enemy = Instantiate(enemyFactory, spawnArea.transform.position, Quaternion.identity);

            currentTime = 0f;

            createTime = Random.Range(minCT, maxCT);
        }
    }
}