using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed = 5f;
    float h, v;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);

        rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
    }
}