using UnityEngine;

public class Itemtest : MonoBehaviour
{
    public SOMaker somaker;

    private void Start() {
        Debug.Log(somaker.description);
    }

    [ContextMenu("LevelUp")]
    public void LevelUp() {
        somaker.level++;
        Debug.Log("������ �����߽��ϴ�!");
    }
}
