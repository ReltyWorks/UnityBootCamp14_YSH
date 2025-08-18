using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lotto : MonoBehaviour {
    public Button GetLottoBtn;
    public Button BackBtn;
    public Text LottoText;
    public Text LottoMsg;
    bool[] lotto = new bool[10];
    int lottoNum = 0;

    UnityAction OnActionLotto;

    void Start() {
        lottoNum = (UnityEngine.Random.Range(0, lotto.Length) + 1);
        LottoText.text = ($"<color=red>이번 로또 당첨 번호는 {lottoNum} 입니다!</color>");
        OnActionLotto += GetLotto;
        GetLottoBtn.onClick.AddListener(OnActionLotto);
        BackBtn.onClick.AddListener(BackScene);
    }

    void GetLotto() {
        int i;
        while (true) {
            i = (UnityEngine.Random.Range(0, lotto.Length) + 1);
            if (!lotto[i - 1]) {
                lotto[i - 1] = true;
                LottoText.text = ($"<color=blue>뽑으신 로또 번호는 {i} 입니다!</color>");
                break;
            }
        }
        if (lottoNum == i) {
            LottoMsg.text = ($"<color=green>당첨!</color>");
            Debug.Log($"<color=red>당첨 확인, 오브젝트 비활성화</color>");

            // GetLottoBtn.onClick.RemoveListener(OnActionLotto);
            // 버튼의 기능 삭제

            GetLottoBtn.interactable = false;
            // 버튼 누르는 기능 비활성화

            // GetLottoBtn.gameObject.SetActive(false);
            // 버튼 오브젝트 비활성화

            // gameObject.SetActive(false);
            // 오브젝트 비활성화
        }
        else {
            LottoMsg.text = ($"<color=yellow>낙첨!</color>");
        }
    }
    void BackScene() {
        SceneManager.LoadScene("MainScene");
    }
}