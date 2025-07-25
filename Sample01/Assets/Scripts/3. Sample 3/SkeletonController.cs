using UnityEngine;
// 버튼의 OnClick에 등록할 기능


public class SkeletonController : MonoBehaviour
{
    public GameObject skeleton;

    public void OnLButtonEnter() {
        if (skeleton.transform.position.x > -4f) {
            skeleton.transform.Translate(0.5f, 0, 0);
        }

    }
    public void OnRButtonEnter() {
        if (skeleton.transform.position.x < 4f) {
            skeleton.transform.Translate(-0.5f, 0, 0);
        }
    }
    // UI버튼의 OnClick 사용 방법
    // 1. 버튼 오브젝트 클릭(LButton, RButton)
    // 2. OnClick의 + 버튼을 눌러 기능을 추가합니다.
    // 3. 오브젝트를 등록하면 해당 오브젝트가 가진 컴포넌트 / 스크립트의 메서드를 사용 할 수 있음
}
