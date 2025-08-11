using System;
using System.IO;
using UnityEngine;

public class JsonMaker : MonoBehaviour {
    
    [Serializable]
    public class QuestData {

        public string quest_name;
        public string reward;
        public string description;

    }

    [Serializable]
    public class QuestList {

        public QuestData[] quests;
    }

    private void Start() {
        QuestList list = new QuestList() {
            quests = new QuestData[] {
                // new �����ڸ�() [�ʵ��=��, �ʵ��2 = �� ... ] �ش� ������ ���� ���� Ŭ���� ��ü�� �����˴ϴ�.
                new QuestData() { quest_name = "������ ���̴�", reward = "exp +100", description = "������ ���� �³�? ���̷��� �����." },

                new QuestData() { quest_name = "�߰��� �ض�", reward = "exp +150", description = "�߰��� �ϴ� �͵� ����� �ѵ�." },

                new QuestData() {quest_name = "������ ����", reward = "exp +500", description = "�����ϴٸ� ����.." }
            }
        }; // ��ħǥ�� �ǹ� 

        //2) JsonUtiluty.ToJson(Object, pretty_print);�� ���� C#�� ��ü�� JSON���� �������ִ� ����ȭ ����� ���� �Լ�

        string json = JsonUtility.ToJson(list, true);
        // Tojson(��ü)�� �ش� ��ü�� JSON���ڿ��� �������ִ� �ڵ�
        // true�� �߰��� ���, �鿩����� �ٹٲ��� ���Ե� ������ json���Ϸ� ������ �ݴϴ�.
        // false�� ���ų� �����ϴ� ����� ���� �� �ٷ� ����� json���Ϸ� �����˴ϴ�.

        Debug.Log(json);

        // 3) ���� ��ο� ���� �ۼ��� �����մϴ�.
        Debug.Log($"�� ���� ���� ��ġ : {Application.persistentDataPath}");
        string path = Path.Combine(Application.persistentDataPath, "quests.json");
        // Path.Combine(string path1, string path2);
        // �� ����� ���ڿ��� �ϳ��� ��η� ������ִ� ����� ������ �ֽ��ϴ�.
        // ���� ��ġ/���ϸ����� ���� ���˴ϴ�.

        // Application.persistentDataPath : ����Ƽ�� �� �÷������� �����ϴ� ���� ���� ������ ���� ���

        //4) �ش� ��ο� ������ �ۼ�
        File.WriteAllText(path, json);
        // C# 723�������� System.IO ���ӽ����̽�,
        // 725������ PathŬ������ ���� ���� �̸�, Ȯ����, ���� ������ ��� ���
        // 733������ Json�����Ϳ� ���� ����

        string path2 = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Resources\\quests.json";
        File.WriteAllText(path2, json);

        Debug.Log("Json ���� ���� �Ϸ�");

        //������� ���̺�
        //=========================================
        //���⼭���� �ε�

        //1) �ش� ��ο� ������ �����ϴ��� �Ǵ��ϼ���.
        if (File.Exists(path)) {
            Debug.Log("�ֽ��ϴ�.");
            // ���� �ؽ�Ʈ�� ���� �о ������ �����ͷ� �����մϴ�.
            string json2 = File.ReadAllText(path);

            QuestList loaded = JsonUtility.FromJson<QuestList>(json2);
            Debug.Log($"����Ʈ ���� : {loaded.quests[0].quest_name}");
        }
        else {
            Debug.LogWarning("������ ã�� ���߽���.");
        }


    }

}
