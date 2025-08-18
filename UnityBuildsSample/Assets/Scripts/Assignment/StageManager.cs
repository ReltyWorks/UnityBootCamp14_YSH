using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {
    public Button beforeBtn;
    public Button lottoBtn;
    public Button afterBtn;

    private void Start() {
        beforeBtn.onClick.AddListener(BeforeScene);
        afterBtn.onClick.AddListener(AfterScene);
        lottoBtn.onClick.AddListener(LottoScene);
    }

    private void BeforeScene() {
        SceneManager.LoadScene("MainScene");
    }

    private void AfterScene() {
        SceneManager.LoadScene("QuizScene");
    }

    private void LottoScene() {
        SceneManager.LoadScene("SampleScene");
    }
}
