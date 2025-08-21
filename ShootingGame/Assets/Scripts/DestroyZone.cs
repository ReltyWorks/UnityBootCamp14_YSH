using UnityEngine;

public class DestroyZone : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != 7) Destroy(other.gameObject);
    }
}