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

    // �ð��� ���� ����ؼ�, ������ �����ϰ�
    // �� ������ ���� Ÿ�Ӻ��� Ŀ���� ������Ʈ ����
    // ������ 0���� �ʱ�ȭ

    // ��ŸŸ�� = �����ӿ��� �����ӱ���

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