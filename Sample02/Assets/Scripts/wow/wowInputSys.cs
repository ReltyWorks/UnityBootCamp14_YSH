using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class wowInputSys : MonoBehaviour {

    private Vector3 mouseMove;
    private Vector2 veiwCamera;
    private Vector2 moveInputValue;
    private float speed = 3.0f;

    void Update() {
        transform.Rotate(mouseMove * speed * Time.deltaTime);
        mouseMove = Input.mousePosition;
    }
}
