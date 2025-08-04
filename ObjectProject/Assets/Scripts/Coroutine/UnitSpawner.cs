using System.Collections;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {
    
    public GameObject unitPrefab; // 유닛 프리팹
    public Transform spawnPoint; // 생성 위치
    public float interval = 5.0f; // 유닛 생성 간격

    private void Start() {
        StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn() {
        while (true) {
            // 유닛을 생성합니다.
            // 생성 위치는 spawnPoint
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log($"{spawnPoint.position}에서 {unitPrefab.name} 생성되었습니다.");

            // 생성 간격만큼 대기
            yield return new WaitForSeconds(interval);
        }
    }



}
