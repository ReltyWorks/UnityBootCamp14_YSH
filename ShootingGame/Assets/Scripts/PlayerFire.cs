using UnityEngine;

public class PlayerFire : MonoBehaviour {
    [Header("�߻� ����")]
    [Tooltip("�Ѿ� ���� ����")]public GameObject bulletFactory;
    [Tooltip("�ѱ�")]public GameObject firePosition;

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            var bullet = Instantiate(bulletFactory, firePosition.transform.position, Quaternion.identity);
        }
    }
}