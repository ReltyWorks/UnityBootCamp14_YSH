using UnityEngine;

// ���� ��������(Spherically interpolate)

// Lerp�� Slerp�� ���Ǵ� ���
// 1. �ܼ��� ��ġ �̵� Lerp or Slerp? -> Lerp
// 2. ȸ�� �� ���� ��ȯ Lerp or Slerp? -> Slerp
// 3. �ڿ������� ī�޶��� ������ Lerp or Slerp? -> Slerp
// ���Ը��� ȸ�� �� ���� ��ȯ�� ���ٸ� slerp�� ���

// Lerp -> ���� �̵�, ü�� ������ ���� �����ϰ� ��ȭ�ϴ� ���
// Slerp -> ȸ���̳� ������ ������ �ʿ��� ���, 3D ȸ��(���ʹϾ�) / ���� ���� � ��� Ȯ�� / ���� ȸ���� �ε巴�� ��� ������ �ٶ���� �� ���

public class SphericaInter : MonoBehaviour {

    // 
    public Transform target;
    public float speed = 1.0f;

    private Vector3 start_position;
    private float t = 0.0f;

    private void Start() {
        start_position = transform.position;
    }
    private void Update() {
        if (t < 1.0f) {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Slerp(start_position, target.position, t);
        }
    }
}
