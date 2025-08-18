using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {
    string[] quizTextTable = {
        "클래스는 하나의 책임만을 진다. 이는 클래스의 응집도를 높이고 변경 시의 영향을 최소화하는 방법이다.\r\n이를 어기면 다른 기능에 영향을 많이 미치게 되 버그 발생 확률이 높아지고, 코드의 유지보수 작업 시에 어려움이 발생할 수 있으며 코드의 가독성도 떨어지게 된다.",
        "SW 구성 요소는 기존 코드를 수정하지 않고도 새로운 기능이 추가될 수 있게 설계되어 있어야 합니다.\r\n이를 어길 시 기존 코드의 변경이 예기치 못한 부분에서의 오류로 이어지고, 하나의 수정이 전체 구조에 영향을 미치게 된다.",
        "자식 클래스는 부모 클래스의 기능을 완전히 대체할 수 있어야 한다.\r\n이를 어길 시 다형성이 깨지며 예외 상황이 발생하기 쉬워져 코드의 안전성을 저해하게 됩니다.",
        "인터페이스에 대한 분리는 불필요한 메소드 구현을 방지하게 되며 여러 개의 인터페이스가 하나의 통합 범용 인터페이스보다 낫다.\r\n이를 어길 시 필요하지 않는 메소드까지 강제 구현해야하고 불필요한 의존성이 생기게 되 인터페이스의 장점이 퇴색된다.",
        "세부 사항이 추상화에 의존하게 설계하라. 모듈 간 의존 관계를 최소화해 코드의 확장성과 유지보수성을 확보해야 한다."
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
