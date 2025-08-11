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

    private string selectJob = "무직";
    private string outputText = "";


    // 저장 위치
    string saveA = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveA.json";
    string saveB = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveB.json";
    string saveC = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveC.json";


    void Start() {
        DDJob.onValueChanged.AddListener(OnDropdownValueChanged);
        CreateBtn.onClick.AddListener(WrittenByHomeworker);
        FixedBtn.onClick.AddListener(CreateChar);
        CreateText.text = $"<캐릭터 생성>\n이름 : 없음\n직업 : {selectJob}";
    }

    void OnDropdownValueChanged(int idx) {
        selectJob = DDJob.options[idx].text;
    }

    void WrittenByHomeworker() {
        CreateText.text = $"<캐릭터 생성>\n이름 : {IFName.text}\n직업 : {selectJob}";
    }

    void CreateChar() {
        CharData makeData = new CharData() { charName = IFName.text, charJob = selectJob };
        string json = JsonUtility.ToJson(makeData, true);
        if (!File.Exists(saveA)) {
            File.WriteAllText(saveA, json);
            outputText = $"<캐릭터 생성>\n이름 : {IFName.text}\n직업 : {selectJob}";
        } 
        else if (!File.Exists(saveB)) {
            File.WriteAllText(saveB, json);
            outputText = $"<캐릭터 생성>\n이름 : {IFName.text}\n직업 : {selectJob}";
        }
        else if (!File.Exists(saveC)) {
            File.WriteAllText(saveC, json);
            outputText = $"<캐릭터 생성>\n이름 : {IFName.text}\n직업 : {selectJob}";
        }
        else outputText = $"자리가 없어 임마.";

        FixedTextBG.SetActive(true);
        FixedText.text = outputText;
        gameObject.SetActive(false);
    }
}
