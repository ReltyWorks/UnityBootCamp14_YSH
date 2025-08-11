using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateUI : MonoBehaviour {

    public class CharData {
        public string charName;
        public string charJob;
    }

    public TMP_Text CreateText;
    public TMP_InputField IFName;
    public TMP_Dropdown DDJob;
    public Button CreateBtn;
    public Button FixedBtn;
    public TMP_Text FixedText;
    public GameObject FixedTextBG;

    private string selectJob = "����";
    private string outputText = "";


    // ���� ��ġ
    string saveA = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveA.json";
    string saveB = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveB.json";
    string saveC = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveC.json";


    void Start() {
        DDJob.onValueChanged.AddListener(OnDropdownValueChanged);
        CreateBtn.onClick.AddListener(WrittenByHomeworker);
        FixedBtn.onClick.AddListener(CreateChar);
        CreateText.text = $"<ĳ���� ����>\n�̸� : ����\n���� : {selectJob}";
    }

    void OnDropdownValueChanged(int idx) {
        selectJob = DDJob.options[idx].text;
    }

    void WrittenByHomeworker() {
        CreateText.text = $"<ĳ���� ����>\n�̸� : {IFName.text}\n���� : {selectJob}";
    }

    void CreateChar() {
        CharData makeData = new CharData() { charName = IFName.text, charJob = selectJob };
        string json = JsonUtility.ToJson(makeData, true);
        if (!File.Exists(saveA)) {
            File.WriteAllText(saveA, json);
            outputText = $"<ĳ���� ����>\n�̸� : {IFName.text}\n���� : {selectJob}";
        } 
        else if (!File.Exists(saveB)) {
            File.WriteAllText(saveB, json);
            outputText = $"<ĳ���� ����>\n�̸� : {IFName.text}\n���� : {selectJob}";
        }
        else if (!File.Exists(saveC)) {
            File.WriteAllText(saveC, json);
            outputText = $"<ĳ���� ����>\n�̸� : {IFName.text}\n���� : {selectJob}";
        }
        else outputText = $"�ڸ��� ���� �Ӹ�.";

        FixedTextBG.SetActive(true);
        FixedText.text = outputText;
        gameObject.SetActive(false);
    }
}
