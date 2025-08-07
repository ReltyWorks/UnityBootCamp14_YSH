using UnityEngine;
using UnityEngine.UI;

public class HitMyAss : MonoBehaviour {
    private Text tx;
        
    private void OnCollisionEnter(Collision collision) {
        // collision 변수에는 부딪힌 상대방에 대한 모든 정보 가지고있음
        // collision.gameObject는 '나와 부딪힌 바로 그 게임 오브젝트'를 의미

        // 만약 부딪힌 상대방의 태그가 "Player" 라면
        if (collision.gameObject.CompareTag("Player")) {
            tx = GameObject.Find("Score").GetComponent<Text>();
            // 여기에 점수 깎는 코드!
            gameObject.SetActive(false);
            Player.score--;
            tx.text = $"Score : {Player.score * 10}";
        }
        else if (collision.gameObject.CompareTag("Bullet")) {
            tx = GameObject.Find("Score").GetComponent<Text>();
            gameObject.SetActive(false);
            Player.score++;
            tx.text = $"Score : {Player.score * 10}";
        }
    }
}
