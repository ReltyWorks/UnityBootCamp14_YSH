using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
    public static int score;
    public void Start() {
        score = 0;
        StartCoroutine(CheckScore());
    }
    IEnumerator CheckScore() {
        while (true) {
            if (score <= -1) {
                gameObject.SetActive(false);
                break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}