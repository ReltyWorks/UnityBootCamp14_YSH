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
                // new 생성자명() [필드명=값, 필드명2 = 값 ... ] 해당 형태의 값을 가진 클래스 객체가 생성됩니다.
                new QuestData() { quest_name = "시작이 반이다", reward = "exp +100", description = "시작이 반이 맞냐? 왜이렇게 힘드냐." },

                new QuestData() { quest_name = "중간만 해라", reward = "exp +150", description = "중간을 하는 것도 힘들긴 한데." },

                new QuestData() {quest_name = "끝까지 가자", reward = "exp +500", description = "가능하다면 말야.." }
            }
        }; // 마침표의 의미 

        //2) JsonUtiluty.ToJson(Object, pretty_print);를 통해 C#의 객체를 JSON으로 변경해주는 직렬화 기능을 가진 함수

        string json = JsonUtility.ToJson(list, true);
        // Tojson(객체)는 해당 객체를 JSON문자열로 변경해주는 코드
        // true를 추가할 경우, 들여쓰기와 줄바꿈이 포함된 형식의 json파일로 설정해 줍니다.
        // false를 쓰거나 생략하는 경우라면 전부 한 줄로 압축된 json파일로 설정됩니다.

        Debug.Log(json);

        // 3) 저장 경로에 대한 작성을 진행합니다.
        Debug.Log($"현 저장 폴더 위치 : {Application.persistentDataPath}");
        string path = Path.Combine(Application.persistentDataPath, "quests.json");
        // Path.Combine(string path1, string path2);
        // 두 경로의 문자열을 하나의 경로로 만들어주는 기능을 가지고 있습니다.
        // 저장 위치/파일명으로 자주 사용됩니다.

        // Application.persistentDataPath : 유니티가 각 플랫폼마다 제공하는 영구 저장 가능한 폴더 경로

        //4) 해당 경로에 파일을 작성
        File.WriteAllText(path, json);
        // C# 723페이지에 System.IO 네임스페이스,
        // 725페이지 Path클래스를 통해 파일 이름, 확장자, 폴더 정보를 얻는 방법
        // 733페이지 Json데이터에 대한 설명

        string path2 = "C:\\Users\\user\\Documents\\GitHub\\UnityBootCamp14_YSH\\DataProject\\Assets\\Resources\\quests.json";
        File.WriteAllText(path2, json);

        Debug.Log("Json 파일 저장 완료");

        //여기까진 세이브
        //=========================================
        //여기서부턴 로드

        //1) 해당 경로에 파일이 존재하는지 판단하세요.
        if (File.Exists(path)) {
            Debug.Log("있습니다.");
            // 파일 텍스트를 전부 읽어서 문자형 데이터로 변경합니다.
            string json2 = File.ReadAllText(path);

            QuestList loaded = JsonUtility.FromJson<QuestList>(json2);
            Debug.Log($"퀘스트 수락 : {loaded.quests[0].quest_name}");
        }
        else {
            Debug.LogWarning("파일을 찾지 못했슴다.");
        }


    }

}
