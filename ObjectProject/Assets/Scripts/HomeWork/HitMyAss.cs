using UnityEngine;
using UnityEngine.UI;

public class HitMyAss : MonoBehaviour {
    private Text tx;
        
    private void OnCollisionEnter(Collision collision) {
        // collision �������� �ε��� ���濡 ���� ��� ���� ����������
        // collision.gameObject�� '���� �ε��� �ٷ� �� ���� ������Ʈ'�� �ǹ�

        // ���� �ε��� ������ �±װ� "Player" ���
        if (collision.gameObject.CompareTag("Player")) {
            tx = GameObject.Find("Score").GetComponent<Text>();
            // ���⿡ ���� ��� �ڵ�!
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
