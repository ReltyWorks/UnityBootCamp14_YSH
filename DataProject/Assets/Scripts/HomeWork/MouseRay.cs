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
            // 3D 광선 대신, 2D 월드 좌표를 직접 얻음
            // 게임 안에...?뭔 기능인지? 씨발?
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Physics.Raycast 대신 Physics2D.Raycast
            // 점을 찍는 느낌
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, layerMask);

            if (hit.collider != null) {
                // 만약 맞은 오브젝트의 태그가 "Target"라면
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