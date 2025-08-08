using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// ��� �ٿ��� ���� ���
// 1. Template : ��� �ٿ��� �������� ��, ���̴� ����Ʈ �׸�
// 2. Caption / Item Text : ���� ���õ� �׸� / ����Ʈ �׸� ������ ���� �ؽ�Ʈ
// TMP�� ���� ���, �ѱ� ����� ���� Label�� Item Label���� ��� ���� ��Ʈ�� �������ּž� ��� �� �� �ֽ��ϴ�.
// 3. Options : ��� �ٿ ǥ�õ� �׸� ���� ����Ʈ
// �ν����͸� ���� ���� ����� �����մϴ�.
// ����ϸ� �ٷ� ����Ʈ�� �˴ϴ�.
// 4. On Value Changed (int32) : ����ڰ� �׸��� �������� �� ȣ��Ǵ� �̺�Ʈ
// �ν����͸� ���� ���� ����� �� �ֽ��ϴ�.
// ��� �ٿ� ���� ���� ���� �߻� �� ȣ��˴ϴ�.
public class DropdownSample : MonoBehaviour {
    public TMP_Dropdown dropdown;
    // Options�� ����� ���� ���ڿ�
    private List<string> options = new List<string> { "A", "B", "C"  };

    private void Start () {
        dropdown.ClearOptions(); // ��Ӵٿ��� Option ����� �����ϴ� �ڵ�
        dropdown.AddOptions(options); // �غ�� ��ܿ� ���� �߰�
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        // �̺�Ʈ ��� �� �䱸�ϴ� �Լ��� ���´�� �ۼ��� ��ٸ�
        // �Լ��� �̸��� �־� ����� �� �ְ� �˴ϴ�.
    }


    void OnDropdownValueChanged(int idx) {
        Debug.Log("���� ���õ� �޴���" + dropdown.options[idx].text);
    }
}
