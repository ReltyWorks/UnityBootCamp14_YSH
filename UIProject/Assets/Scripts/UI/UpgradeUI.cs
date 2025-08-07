using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour {

    public Button upgradeBtn;
    public Text upgradeMsg;
    public Text logMsg;
    public Text statMsg;
    public Text iconText;


    // 배열에 readonly를 붙이면, 초기화 1회 후 변경 불가. 읽기만 가능
    // static을 써서 정적으로 사용할 수도 있음!
    public string[] materials = new string[] {
        "100 골드",
        "100 골드+루비",
        "200 골드+사파이어+마력석",
        "최대 강화 완료"
    };

    // max_level을 사용할 경우 배열의 길이 -1의 값을 가지게 됩니다.
    public static int upgrade = 0;
    private int max_level => materials.Length - 1;

    private void Start() {
        // 아래코드 설명, 버튼01의 onClick 에 AddListener(OnUpgradeBtnClick) 라는
        // 능력(코드? 명령)을 넣어주는 것이다. 즉, 스타트에서 한번만 실행되도 무방하다.
        // 차피, onClick은 버튼01이 스스로 처리할테니
        upgradeBtn.onClick.AddListener(OnUpgradeBtnClick);
        // AddListener는 유니티의 UI의 이벤트에 기능을 연결해주는 코드
        // 전달할 수 있는 값의 형태가 정해져 있어서 그 형태대로 설계해줘야합니다.
        // 다른 형태로 쓰는 경우(매개변수가 다른 경우)라면 delegate를 활용합니다.
        // 특징) 이 기능을 통해 이벤트에 기능을 전달한다면
        // 유니티 인스펙터에서 연결된 걸 확인 할 수 없습니다.

        // 장점 : 직접 등록하지 않아서 잘못 넣을 확률이 낮아집니다.
        UpdateUI();
        // 시작시 UI에 대한 렌더링 설정
    }

    // 버튼 클릭 시 호출할 메소드 설계
    private void OnUpgradeBtnClick() {
        UnitInventory ui = GetComponent<UnitInventory>();
        if (upgrade < max_level && ui.CheckInventoryResource()) {
            upgrade++;
            logMsg.text = "강화에 성공했습니다!";
            UpdateUI();
        }
        else {
            logMsg.text = "강화에 실패했습니다ㅠ";
            UpdateUI();
        }
    }
    // 인캡슐레이션, 캡슐화
    private void UpdateUI() {
        iconText.text = $"마법사 + {upgrade}";
        upgradeMsg.text = $"<강화재료>\n{materials[upgrade]}";
    }
}
