using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    public GameObject enemyPrefab; // 유닛 프리팹
    public Transform spawnPoint; // 생성 위치
    public float interval = 1.0f; // 유닛 생성 간격
    public GameObject enemy;

    private void Start() {
    //    StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn() {
        while (enemy == null) {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log($"{spawnPoint.position}에서 {enemyPrefab.name} 생성되었습니다.");
            GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
            // 생성 간격만큼 대기
            yield return new WaitForSeconds(interval);
        }
    }



}
