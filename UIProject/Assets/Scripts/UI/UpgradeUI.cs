using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour {

    public Button upgradeBtn;
    public Text upgradeMsg;
    public Text logMsg;
    public Text statMsg;
    public Text iconText;


    // �迭�� readonly�� ���̸�, �ʱ�ȭ 1ȸ �� ���� �Ұ�. �б⸸ ����
    // static�� �Ἥ �������� ����� ���� ����!
    public string[] materials = new string[] {
        "100 ���",
        "100 ���+���",
        "200 ���+�����̾�+���¼�",
        "�ִ� ��ȭ �Ϸ�"
    };

    // max_level�� ����� ��� �迭�� ���� -1�� ���� ������ �˴ϴ�.
    public static int upgrade = 0;
    private int max_level => materials.Length - 1;

    private void Start() {
        // �Ʒ��ڵ� ����, ��ư01�� onClick �� AddListener(OnUpgradeBtnClick) ���
        // �ɷ�(�ڵ�? ���)�� �־��ִ� ���̴�. ��, ��ŸƮ���� �ѹ��� ����ǵ� �����ϴ�.
        // ����, onClick�� ��ư01�� ������ ó�����״�
        upgradeBtn.onClick.AddListener(OnUpgradeBtnClick);
        // AddListener�� ����Ƽ�� UI�� �̺�Ʈ�� ����� �������ִ� �ڵ�
        // ������ �� �ִ� ���� ���°� ������ �־ �� ���´�� ����������մϴ�.
        // �ٸ� ���·� ���� ���(�Ű������� �ٸ� ���)��� delegate�� Ȱ���մϴ�.
        // Ư¡) �� ����� ���� �̺�Ʈ�� ����� �����Ѵٸ�
        // ����Ƽ �ν����Ϳ��� ����� �� Ȯ�� �� �� �����ϴ�.

        // ���� : ���� ������� �ʾƼ� �߸� ���� Ȯ���� �������ϴ�.
        UpdateUI();
        // ���۽� UI�� ���� ������ ����
    }

    // ��ư Ŭ�� �� ȣ���� �޼ҵ� ����
    private void OnUpgradeBtnClick() {
        UnitInventory ui = GetComponent<UnitInventory>();
        if (upgrade < max_level && ui.CheckInventoryResource()) {
            upgrade++;
            logMsg.text = "��ȭ�� �����߽��ϴ�!";
            UpdateUI();
        }
        else {
            logMsg.text = "��ȭ�� �����߽��ϴ٤�";
            UpdateUI();
        }
    }
    // ��ĸ�����̼�, ĸ��ȭ
    private void UpdateUI() {
        iconText.text = $"������ + {upgrade}";
        upgradeMsg.text = $"<��ȭ���>\n{materials[upgrade]}";
    }
}
