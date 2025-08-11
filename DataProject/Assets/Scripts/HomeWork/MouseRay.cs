using UnityEngine;
using UnityEngine.UI;

public class MouseRay : MonoBehaviour {

    public Text scoreText;
    public static int score = 0;
    public string targetTag = "Target";

    private Camera cam;
    public float distance = 100.0f;
    public LayerMask layerMask;

    void Start() {
        cam = Camera.main;
        UpdateScoreText();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // 3D ���� ���, 2D ���� ��ǥ�� ���� ����
            // ���� �ȿ�...?�� �������? ����?
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Physics.Raycast ��� Physics2D.Raycast
            // ���� ��� ����
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, layerMask);

            if (hit.collider != null) {
                // ���� ���� ������Ʈ�� �±װ� "Target"���
                if (hit.collider.CompareTag(targetTag)) {
                    score++;
                    UpdateScoreText();
                }
            }
        }
    }

    void UpdateScoreText() {
        scoreText.text = "Score : " + score;
    }
}