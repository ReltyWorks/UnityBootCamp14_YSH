using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject checkSphere;
    public Text scoreText;

    static public int score = 0;

    float spawnTime = 2.0f;
    float time = 0.0f;

    // 시간을 따로 계산해서, 변수로 저장하고
    // 그 변수가 스폰 타임보다 커지면 오브젝트 생성
    // 변수를 0으로 초기화

    // 델타타임 = 프레임에서 프레임까지

    void Update()
    {
        time += Time.deltaTime;
        scoreText.text = $"Score : {score * 10}";

        if (time > spawnTime) {
            GameObject go = Instantiate(objectPrefab);
            go.transform.Translate(Random.Range(-3.6f, 3.6f), 0, 0);
            time = 0.0f;
            
            checkSphere = GameObject.Find("Sphere");
            score++;
        }
    }
}