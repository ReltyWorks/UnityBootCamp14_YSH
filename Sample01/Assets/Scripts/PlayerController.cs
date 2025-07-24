/*
�������̺��??
�������� �ʹ� �Ƴ��� �����ο� �� �� ?��?��?
����� ����Ʈ ����
Axis �� ����Ƽ�� �����ϰ� ������ �ִ� Ű?


��ǲ �Ŵ���(Axes Ű) Ȯ��
Horizontal : ���� Ű
Vertical : ���� Ű
����Ƽ �Է� ��� (��/�Ź��� Ȱ��ȭ)
Edit -> Project Settings -> Player -> Other Settings -> Configuration -> Active Input Handling
����Ƽ �⺻ ���� IDE����
Edit -> Preferences -> External tools -> External Script Editor -> ���ϴ°ɷ�
VS���� �ַ�� Ž���⿡ Assembly-CSharp�� �����־�� ����Ƽ�� �ڵ带 Ž���� ���� ����



Obstacle ��ũ��Ʈ�� ����
��ֹ��� ������
1. ��ֹ��� �±״� obstacle
    ��ֹ��� Ʈ���� �浹�� ���
    �÷��̾��� speed�� 1 �����մϴ�
    ��ֹ��� �����

*/ 

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public bool obsOn = false;



    // Start�� MonoBehaviour�� ������ �� Update�� ù ��° ���� ���� �� �� ȣ��˴ϴ�.
    void Start()
    {
        speed = 300;
        rb = GetComponent<Rigidbody>();
        // GetComponent<T>() : ���� ������Ʈ�� �پ��ִ� ������Ʈ�� �������� ���
        // T : Type
        Debug.Log("������ �Ϸ�Ǿ����ϴ�!");
    }

    // ������Ʈ�� �����Ӵ� �� ���� ȣ��˴ϴ�.
    void Update()
    {
        // speed += 1;
        // Debug.Log($"�ӵ��� 1 �����մϴ�. ���� �ӵ��� {speed}�Դϴ�.");

        // ���� �̵�
        float horizontal = Input.GetAxis("Horizontal");
        
        // ���� �̵�
        float vertical = Input.GetAxis("Vertical");

        // �̵� ��ǥ(����) ����
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        if(obsOn == true) {
            rb.AddForce((movement * -500f) * Time.deltaTime);
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
            obsOn = true;
            other.gameObject.SetActive(false);
        }
    }

}