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
        LottoText.text = ($"<color=red>�̹� �ζ� ��÷ ��ȣ�� {lottoNum} �Դϴ�!</color>");
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
                LottoText.text = ($"<color=blue>������ �ζ� ��ȣ�� {i} �Դϴ�!</color>");
                break;
            }
        }
        if (lottoNum == i) {
            LottoMsg.text = ($"<color=green>��÷!</color>");
            Debug.Log($"<color=red>��÷ Ȯ��, ������Ʈ ��Ȱ��ȭ</color>");

            // GetLottoBtn.onClick.RemoveListener(OnActionLotto);
            // ��ư�� ��� ����

            GetLottoBtn.interactable = false;
            // ��ư ������ ��� ��Ȱ��ȭ

            // GetLottoBtn.gameObject.SetActive(false);
            // ��ư ������Ʈ ��Ȱ��ȭ

            // gameObject.SetActive(false);
            // ������Ʈ ��Ȱ��ȭ
        }
        else {
            LottoMsg.text = ($"<color=yellow>��÷!</color>");
        }
    }
    void BackScene() {
        SceneManager.LoadScene("MainScene");
    }
}