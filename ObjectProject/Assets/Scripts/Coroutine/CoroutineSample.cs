using System.Collections;
using UnityEngine;

public class CoroutineSample : MonoBehaviour {

    // ������ Ÿ�� 
    public GameObject target;

    // ��ȭ �ð�
    float duration = 5.0f;

    // �ٲٰ� ���� ��
    public Color color;

    //Coroutine coroutine;

    void Start() {
        //coroutine = StartCoroutine(ChangeColor());
        //// �ڷ�ƾ ���� ���
        //StopCoroutine(coroutine);
        //StopAllCoroutines(); // ��� �ڷ�ƾ�� ���� ����(���� ���� ������Ʈ���� ��������)
        // ������ ���� �� ����, ������ ����, ������ �����



        // Ÿ���� �����Ǿ� �ִٸ�
        if (target != null) {
            StartCoroutine(ChangeColor());
            // StartCoroutine(�޼ҵ��()); IEnumerator ������ �޼ҵ带 �ڷ�ƾ���� �����մϴ�.
            // �ڵ� �ۼ� �������� �޼ҵ尡 ������ ������
            // �޼ҵ� ȣ���� ������ �������� Ȯ�εǱ⿡ ã�� �����ϴ� �ð��� ���ڿ����� ���� ��ϴ�.

            // StartCoroutine("ChangeColor");
            // StartCoroutine("�޼ҵ��"); ���ڿ��� ���� �Ű������� ���� �ڷ�ƾ�� ȣ���� �� �ֽ��ϴ�.
            // ���������� �޼ҵ��� �̸��� ���ڿ��� �����ϰ�, ��Ÿ�ӿ��� ã�Ƽ� �����ϴ� ��� (���÷���)
            // Ÿ�� üũ�� ���� �ʾƼ� �߸��� �̸��� ���� ��Ÿ�� ���� �߻�
        }
        else Debug.LogWarning("Ÿ�� ����");
    }

    IEnumerator ChangeColor() {
        // IEnumerator ������ �����ʹ� yield�� ���ԵȰ� �ϳ��� ��ȯ�ؾ���


        // Ÿ�����κ��� ������ ������Ʈ�� ���� ���� ��� �ɴϴ�.
        var targetRenderer = target.GetComponent<Renderer>();

        // ������ Ÿ���� �������� ���� ��� / �۾� �ߴ�
        if (targetRenderer == null) {
            Debug.LogWarning("�������� ������ ���߽��ϴ�.(NULL)");
            yield break;
        }

        // �� ��ġ�� �ڵ�� ���������� �������� ���� ��쿡 ����Ǵ� ��ġ


        float time = 0.0f;

        //Ÿ���� �������� ���� ��Ƽ������ ������ ���
        var start = targetRenderer.material.color;
        var end = color;
        
        // �ݺ� �۾�
        // �ڷ�ƾ ������ �ݺ����� �����ϸ� yield�� ���� ���� �����ٰ� �ٽ� ���ƿͼ� �ݺ����� �����ϰ� �˴ϴ�.
        while (time < duration) { // ��ȭ�� �ð���ŭ �۾�
            time += Time.deltaTime;
            var value = Mathf.PingPong(time, duration) / duration;
            // Mathf.PingPong(a,b)
            // �־��� ���� a�� b ���̿��� �ݺ��Ǵ� ���� �����մϴ�. (�⺻���� �պ� �)
            // �̷��� ~~ �Ѱ��� ����ȭ��� �մϴ�.
            // �� 0���� 1������ ��ȭ ���� ���˴ϴ�.
            // ����ȭ �۾��� ������ ���� : color�� 0���� 1������ ��

            targetRenderer.material.color = Color.Lerp(start, end, value);
            // ���� ���� �ε巯�� ����

            yield return null;// new WaitForSeconds(0.1f);
            Debug.Log("�� ������ �������.");
        }
    }
}