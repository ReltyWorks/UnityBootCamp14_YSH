using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    string saveA = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveA.json";
    string saveB = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveB.json";
    string saveC = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Scripts\\HomeWork\\RoleHW\\SaveJson\\SaveC.json";

    public Button ResetBtn;

    void Start() {
        ResetBtn.onClick.AddListener(ResetSaveFile);
    }

    void ResetSaveFile() {
        File.Delete(saveA);
        File.Delete(saveB);
        File.Delete(saveC);
    }
}
