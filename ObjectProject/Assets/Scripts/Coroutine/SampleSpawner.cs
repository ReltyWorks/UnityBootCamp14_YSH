using UnityEngine;

public class SampleSpawner : MonoBehaviour
{
    // 해당 오브젝트가 없을 때 오브젝트를 생성하고, 컴포넌트를 부여하기
    void Start()
    {
        GameObject sample = GameObject.Find("Sample");
        // 1) '게임 오브젝트'클래스 'sample'을 생성함
        // 2) 게임 오브젝트, 이름이 "Sample"인 내용을 찾아서 게임 오브젝트 정보를 'sample'에 넣음

        // 오브젝트 탐색 결과가 없을 경우
        if (sample == null) { // 3) 탐색 결과가 없으면
            GameObject go = new GameObject("Sample");
            // 4) 게임 오브젝트 클래스 'go'를 만들어서 "Sample"을 새로 만들어서 정보를 넣음.
            //go.AddComponent<Sample>(); //
        } else {
            Debug.Log("이미 존재합니다.");
        }
    }
}
