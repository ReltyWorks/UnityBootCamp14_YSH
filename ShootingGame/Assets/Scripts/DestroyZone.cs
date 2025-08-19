using UnityEngine;

public class DestroyZone : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("DestroyZone")) Destroy(other.gameObject);
    }
}