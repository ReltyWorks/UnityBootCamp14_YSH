using UnityEngine;

public class PlayerFire : MonoBehaviour {
    [Header("발사 설정")]
    [Tooltip("총알 생산 공장")]public GameObject bulletFactory;
    [Tooltip("총구")]public GameObject firePosition;

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            var bullet = Instantiate(bulletFactory, firePosition.transform.position, Quaternion.identity);
        }
    }
}