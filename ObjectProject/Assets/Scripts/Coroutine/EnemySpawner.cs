using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    public GameObject enemyPrefab; // ���� ������
    public Transform spawnPoint; // ���� ��ġ
    public float interval = 1.0f; // ���� ���� ����
    public GameObject enemy;

    private void Start() {
    //    StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn() {
        while (enemy == null) {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log($"{spawnPoint.position}���� {enemyPrefab.name} �����Ǿ����ϴ�.");
            GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
            // ���� ���ݸ�ŭ ���
            yield return new WaitForSeconds(interval);
        }
    }



}
