using UnityEngine;

// ������ ��� ���¿��� Update, OnEnable, OnDisable�� ������ ������ �� �ֽ��ϴ�.
// Play�� ������ �ʾƵ� Editor ������ Update � ������ ��ɵ��� ������ �� �� �ֽ��ϴ�.

[ExecuteInEditMode]
public class EditMenuAttributes : MonoBehaviour {
    void Update() {
        // �̷� �ڵ�� ������ â���� (������ ���ص�)����ؼ� ����Ǳ⿡
        // �����ؼ� ����ؾ���
        //if (!Application.isPlaying) {
        //    Vector3 pos = transform.position;
        //    pos.y = 0;
        //    transform.position = pos;
        //    Debug.Log("Editor Test...(�� ��ũ��Ʈ�� �� ������Ʈ�� y���� 0���� �����˴ϴ�.)");
        //}
    }
}
