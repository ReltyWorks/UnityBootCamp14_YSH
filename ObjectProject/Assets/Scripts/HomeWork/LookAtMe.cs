using UnityEngine;
// ȸ����Ű�� ��ũ��Ʈ
public class LookAtMe : MonoBehaviour {
    public Transform target;
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 2.0f);
    }
}