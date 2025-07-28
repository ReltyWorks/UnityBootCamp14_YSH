using UnityEngine;

public class Sample1 : MonoBehaviour
{
    public CustomComponent cc;
    private void Awake() {
        // 컴포넌트에 대한 값을 얻어옴
        cc = GetComponent<CustomComponent>();
    }
}
