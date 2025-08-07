using System.Collections;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {
    
    public GameObject unitPrefab; // ���� ������
    public Transform spawnPoint; // ���� ��ġ
    public float interval = 5.0f; // ���� ���� ����

    private void Start() {
        spawnPoint = gameObject.transform;
        StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn() {
        while (true) {
            // ������ �����մϴ�.
            // ���� ��ġ�� spawnPoint
            spawnPoint.position = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log($"{spawnPoint.position}���� {unitPrefab.name} �����Ǿ����ϴ�.");

            // ���� ���ݸ�ŭ ���
            yield return new WaitForSeconds(interval);
        }
    }



}
