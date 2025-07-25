using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Text scoreText;  // �ؽ�Ʈ �ؽ�Ʈ

    public bool obsOn = false; // ��ֹ� ����
    private int score = 0; // ����


    void Start()
    {

        // Text scoreText = GetComponent<Text>();
        // ��?

        scoreText.text = "Score : 0";
        speed = 1000;
        rb = GetComponent<Rigidbody>();
        // GetComponent<T>() : ���� ������Ʈ�� �پ��ִ� ������Ʈ�� �������� ���
        // T : Type
        Debug.Log("������ �Ϸ�Ǿ����ϴ�!");
    }

    void Update()
    {
        // speed += 1;
        // Debug.Log($"�ӵ��� 1 �����մϴ�. ���� �ӵ��� {speed}�Դϴ�.");

        float horizontal = Input.GetAxis("Horizontal"); // ���� �̵�

        // ���� �̵�
        float vertical = Input.GetAxis("Vertical");

        // �̵� ��ǥ(����) ����
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        if(obsOn == true) {
            rb.AddForce((movement * -100f) * Time.deltaTime);
            obsOn = false;
        }
    
        rb.AddForce((movement * speed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        // �浹ü�� ���� ������Ʈ �±װ� Itembox ���
        if(other.gameObject.CompareTag("Itembox")) {
            Debug.Log("������ ȹ��!");
            // �浹ü�� ���ӿ�����Ʈ�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("obstacle")) {
            Debug.Log("��ֹ� ����!");

            score++;
            scoreText.text = $"Score = {score * 10}";

            obsOn = true;
            other.gameObject.SetActive(false);
        }
    }

}