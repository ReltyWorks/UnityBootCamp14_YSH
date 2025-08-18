using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {
    string[] quizTextTable = {
        "Ŭ������ �ϳ��� å�Ӹ��� ����. �̴� Ŭ������ �������� ���̰� ���� ���� ������ �ּ�ȭ�ϴ� ����̴�.\r\n�̸� ���� �ٸ� ��ɿ� ������ ���� ��ġ�� �� ���� �߻� Ȯ���� ��������, �ڵ��� �������� �۾� �ÿ� ������� �߻��� �� ������ �ڵ��� �������� �������� �ȴ�.",
        "SW ���� ��Ҵ� ���� �ڵ带 �������� �ʰ� ���ο� ����� �߰��� �� �ְ� ����Ǿ� �־�� �մϴ�.\r\n�̸� ��� �� ���� �ڵ��� ������ ����ġ ���� �κп����� ������ �̾�����, �ϳ��� ������ ��ü ������ ������ ��ġ�� �ȴ�.",
        "�ڽ� Ŭ������ �θ� Ŭ������ ����� ������ ��ü�� �� �־�� �Ѵ�.\r\n�̸� ��� �� �������� ������ ���� ��Ȳ�� �߻��ϱ� ������ �ڵ��� �������� �����ϰ� �˴ϴ�.",
        "�������̽��� ���� �и��� ���ʿ��� �޼ҵ� ������ �����ϰ� �Ǹ� ���� ���� �������̽��� �ϳ��� ���� ���� �������̽����� ����.\r\n�̸� ��� �� �ʿ����� �ʴ� �޼ҵ���� ���� �����ؾ��ϰ� ���ʿ��� �������� ����� �� �������̽��� ������ ����ȴ�.",
        "���� ������ �߻�ȭ�� �����ϰ� �����϶�. ��� �� ���� ���踦 �ּ�ȭ�� �ڵ��� Ȯ�强�� ������������ Ȯ���ؾ� �Ѵ�."
    };
    string[] quizAnswer = { "S R P", "O C P", "L S P", "I S P", "D I P" };

    public TMP_Text quizText;

    public GameObject afterBtn;

    public Button answerBtnA;
    public Button answerBtnB;
    public Button answerBtnC;

    public TMP_Text btnAText;
    public TMP_Text btnBText;
    public TMP_Text btnCText;

    public GameObject textCorrect;
    public GameObject textWrong;

    void Start() {
        int selectQuiz = Random.Range(0, quizTextTable.Length);
        string[] answer = new string[3];
        int answerBtnNum = Random.Range(0, answer.Length);

        quizText.text = quizTextTable[selectQuiz];

        if (answerBtnNum == 0) {
            btnAText.text = quizAnswer[selectQuiz];
            quizAnswer[selectQuiz] = "Q W E R";
            btnBText.text = quizAnswer[Random.Range(0, quizAnswer.Length)];
            btnCText.text = quizAnswer[Random.Range(0, quizAnswer.Length)];

            answerBtnA.onClick.AddListener(Correct);
            answerBtnB.onClick.AddListener(Wrong);
            answerBtnC.onClick.AddListener(Wrong);
        }
        else if (answerBtnNum == 1) {
            btnBText.text = quizAnswer[selectQuiz];
            quizAnswer[selectQuiz] = "Q W E R";
            btnAText.text = quizAnswer[Random.Range(0, quizAnswer.Length)];
            btnCText.text = quizAnswer[Random.Range(0, quizAnswer.Length)];

            answerBtnB.onClick.AddListener(Correct);
            answerBtnA.onClick.AddListener(Wrong);
            answerBtnC.onClick.AddListener(Wrong);
        }
        else {
            btnCText.text = quizAnswer[selectQuiz];
            quizAnswer[selectQuiz] = "Q W E R";
            btnAText.text = quizAnswer[Random.Range(0, quizAnswer.Length)];
            btnBText.text = quizAnswer[Random.Range(0, quizAnswer.Length)];

            answerBtnC.onClick.AddListener(Correct);
            answerBtnA.onClick.AddListener(Wrong);
            answerBtnB.onClick.AddListener(Wrong);
        }
    }

    void Correct() {
        textCorrect.SetActive(true);
        answerBtnA.interactable = false;
        answerBtnB.interactable = false;
        answerBtnC.interactable = false;
        afterBtn.SetActive(true);
    }

    void Wrong() {
        textWrong.SetActive(true);
        answerBtnA.interactable = false;
        answerBtnB.interactable = false;
        answerBtnC.interactable = false;
        afterBtn.SetActive(true);
    }
}
