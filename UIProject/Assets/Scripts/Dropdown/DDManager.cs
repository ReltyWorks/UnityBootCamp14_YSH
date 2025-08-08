using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DDManager : MonoBehaviour {
    //#region Singleton

    //public static DDManager Instance { get; private set; } 
    //private void Awake() {
    //    if (Instance == null) {
    //        Instance = this;
    //        DontDestroyOnLoad(Instance);
    //    }
    //    else Destroy(gameObject);
    //}

    //#endregion

    #region Declaration

    public TMP_Dropdown DDSex;
    public TMP_Dropdown DDJob;
    public TMP_Dropdown DDSpec;
    public TMP_InputField IFName;
    public TMP_InputField IFAge;
    public UnityEngine.UI.Button CreateBtn;
    public TMP_Text PlayerCreateText;

    private string selectSex = "";
    private string selectJob = "";
    private string selectSpec = "";

    #endregion

    #region Initialization

    private List<string> optionsDDSex = new List<string> { "성별", "남성", "여성", "성중립凸" };
    private List<string> optionsDDJob = new List<string> { "직업", "기사", "위저드", "궁수" };
    private List<string> optionsDDSpec = new List<string> { "종족", "오크", "고블린", "슬라임" };

    #endregion

    void Start() {
        DDSex.ClearOptions();
        DDJob.ClearOptions();
        DDSpec.ClearOptions();

        DDSex.AddOptions(optionsDDSex);
        DDJob.AddOptions(optionsDDJob);
        DDSpec.AddOptions(optionsDDSpec);

        DDSex.onValueChanged.AddListener(OnDropdownValueChanged);
        DDJob.onValueChanged.AddListener(OnDropdownValueChanged);
        DDSpec.onValueChanged.AddListener(OnDropdownValueChanged);

        CreateBtn.onClick.AddListener(WrittenByHoHoGrandpa);
    }

    void OnDropdownValueChanged(int idx) {
        if(optionsDDSex.Contains(DDSex.options[idx].text) && !(DDSex.options[idx].text == "성별"))
            selectSex = DDSex.options[idx].text;
        if (optionsDDJob.Contains(DDJob.options[idx].text) && !(DDJob.options[idx].text == "직업"))
            selectJob = DDJob.options[idx].text;
        if (optionsDDSpec.Contains(DDSpec.options[idx].text) && !(DDSpec.options[idx].text == "종족"))
            selectSpec = DDSpec.options[idx].text;
    }

    void WrittenByHoHoGrandpa() {
        string name = IFName.text;
        int age = int.Parse(IFAge.text);
        Debug.Log(name);
        Debug.Log(age);
        Debug.Log(selectSex);
        Debug.Log(selectJob);
        Debug.Log(selectSpec);

        string outputSex = "";
        if (selectSex == "남성") outputSex = "그";
        if (selectSex == "여성") outputSex = "그녀";

        string outputText = $"{name}은(는) {selectSpec}무리 사이에서 {age/2}년이 넘게 괴롭힘을 당해왔기에 쉼없이 자신을 채찍질 했습니다.\n시간이 흘러, 끊임없는 수련으로 {selectJob}가 된 {name}은(는) {outputSex}의 나이 {age}살에 {selectSpec}무리를 학살하고 도망쳐 왔습니다.";
        PlayerCreateText.text = outputText;
    }
}
