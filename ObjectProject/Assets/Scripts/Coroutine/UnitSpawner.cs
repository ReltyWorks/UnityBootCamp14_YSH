using System.Collections;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {
    
    public GameObject unitPrefab; // ���� ������
    public Transform spawnPoint; // ���� ��ġ
    public float interval = 5.0f; // ���� ���� ����

    private void Start() {
        StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn() {
        while (true) {
            // ������ �����մϴ�.
            // ���� ��ġ�� spawnPoint
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log($"{spawnPoint.position}���� {unitPrefab.name} �����Ǿ����ϴ�.");

            // ���� ���ݸ�ŭ ���
            yield return new WaitForSeconds(interval);
        }
    }



}
