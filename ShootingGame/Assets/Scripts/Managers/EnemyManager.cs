using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [Header("利 积己扁 汲沥")]
    [Tooltip("利 积己 钱")] public GameObject enemyFactory;
    [Tooltip("利 积己 康开")] public GameObject spawnArea;
    [Tooltip("利 积己 矫埃 弥家")] public float minCT = 1f;
    [Tooltip("利 积己 矫埃 弥措")] public float maxCT = 5f;
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