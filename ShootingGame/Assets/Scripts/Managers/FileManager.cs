using System.IO;
using System;
using TMPro;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ScoreData {
    public int save;
}
public class FileManager : MonoBehaviour {
    public GameObject player;
    public TMP_Text bestText;
    private int best;

    private string editorPath = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\ShootingGame\\Save\\save.json";
    private string runtimePath;

    public static FileManager Instance = null;

    private void Awake() {
        if (Instance == null) Instance = this;

#if UNITY_EDITOR
        if (File.Exists(editorPath)) {
            string json = File.ReadAllText(editorPath);
            ScoreData Data = JsonUtility.FromJson<ScoreData>(json);
            best = Data.save;
        };
#else
        string exeFolder = Path.Combine(Application.dataPath, "../");
        string saveFolderPath = Path.Combine(exeFolder, "Save");
        if (!Directory.Exists(saveFolderPath)) { Directory.CreateDirectory(saveFolderPath); };
        runtimePath = Path.Combine(saveFolderPath, "save.json");
        if (File.Exists(runtimePath)) {
            string json = File.ReadAllText(runtimePath);
            ScoreData Data = JsonUtility.FromJson<ScoreData>(json);
            best = Data.save;
        };
#endif
    }

    public void SetBest(int value) {
        best = value;
        SetBestText(best);
    }

    private void SetBestText(int best) => bestText.text = $"Score : {best}";

    public int GetBest() => best;

    void Update() {
        if (!player.activeSelf) {
#if UNITY_EDITOR
            ScoreData Data = new ScoreData();
            Data.save = best;
            string json = JsonUtility.ToJson(Data, true);
            File.WriteAllText(editorPath, json);
#else

#endif
        }
    }
}
