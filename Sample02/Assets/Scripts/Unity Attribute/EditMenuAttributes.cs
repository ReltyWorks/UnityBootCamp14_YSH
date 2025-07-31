using UnityEngine;

// 에디터 모드 상태에서 Update, OnEnable, OnDisable의 실행을 진행할 수 있습니다.
// Play를 누르지 않아도 Editor 내에서 Update 등에 설계한 기능들을 실행해 볼 수 있습니다.

[ExecuteInEditMode]
public class EditMenuAttributes : MonoBehaviour {
    void Update() {
        // 이런 코드는 에디터 창에서 (실행을 안해도)계속해서 실행되기에
        // 조심해서 사용해야함
        //if (!Application.isPlaying) {
        //    Vector3 pos = transform.position;
        //    pos.y = 0;
        //    transform.position = pos;
        //    Debug.Log("Editor Test...(이 스크립트를 낀 오브젝트는 y축이 0으로 고정됩니다.)");
        //}
    }
}
