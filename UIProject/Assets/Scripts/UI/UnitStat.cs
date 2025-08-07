using UnityEngine;
using UnityEngine.UI;

public class UnitStat : MonoBehaviour {

    public Button upgradeBtn;
    public Text statMsg;


    void Start() {
        upgradeBtn.onClick.AddListener(OnUpgradeBtnClick);
        UpdateStatUI();
    }

    private void OnUpgradeBtnClick() {
        UpdateStatUI();
    }
    // ÀÎÄ¸½¶·¹ÀÌ¼Ç, Ä¸½¶È­
    private void UpdateStatUI() {
        statMsg.text = $"HP {(UpgradeUI.upgrade * 100) + 100} / MP {(UpgradeUI.upgrade * 50) + 100}\n" +
            $"Str {(UpgradeUI.upgrade * 1) + 10} / Wis {(UpgradeUI.upgrade * 5) + 10} / Dex {(UpgradeUI.upgrade * 3) + 10}";
    }

}
