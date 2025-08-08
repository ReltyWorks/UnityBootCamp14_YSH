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

    private List<string> optionsDDSex = new List<string> { "����", "����", "����", "���߸���" };
    private List<string> optionsDDJob = new List<string> { "����", "���", "������", "�ü�" };
    private List<string> optionsDDSpec = new List<string> { "����", "��ũ", "���", "������" };

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
        if(optionsDDSex.Contains(DDSex.options[idx].text) && !(DDSex.options[idx].text == "����"))
            selectSex = DDSex.options[idx].text;
        if (optionsDDJob.Contains(DDJob.options[idx].text) && !(DDJob.options[idx].text == "����"))
            selectJob = DDJob.options[idx].text;
        if (optionsDDSpec.Contains(DDSpec.options[idx].text) && !(DDSpec.options[idx].text == "����"))
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
        if (selectSex == "����") outputSex = "��";
        if (selectSex == "����") outputSex = "�׳�";

        string outputText = $"{name}��(��) {selectSpec}���� ���̿��� {age/2}���� �Ѱ� �������� ���ؿԱ⿡ ������ �ڽ��� ä���� �߽��ϴ�.\n�ð��� �귯, ���Ӿ��� �������� {selectJob}�� �� {name}��(��) {outputSex}�� ���� {age}�쿡 {selectSpec}������ �л��ϰ� ������ �Խ��ϴ�.";
        PlayerCreateText.text = outputText;
    }
}
