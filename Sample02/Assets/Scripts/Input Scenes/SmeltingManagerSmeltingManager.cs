using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class SmeltingManager : MonoBehaviour {
    public Text textName;
    public Text textAtt;
    public Text textValue;
    public Text textChance;

    public int itemValue = 0;
    public int itemAtt = 0;
    public int bonus = 0;

    void OnJump() {
        if (itemValue < 10) Smelting();
    }
    
    private void Smelting() {
        int itemChance = 100 - (itemValue * 10);
        int itemChanceTry = Random.Range(1, 101);
        if (itemChanceTry <= (itemChance + bonus)) {
            successSmelting();
        }
        else if (itemValue >= 1) {
            itemAtt -= 5;
            itemValue--;
            failSmelting();
        }
        else failSmelting();
    }
    private void successSmelting() {
        itemAtt += 5;
        itemValue++;
        textName.text = $"Ű���� (+{itemValue})";
        textAtt.text = $"���ݷ� : 50 (+{itemAtt})";
        textValue.text = $"��ȭ�� : {itemValue} / 10";
        textChance.text = $"��ȭ Ȯ�� : {100 - (itemValue * 10)}%";
    }
    private void failSmelting() {
        textName.text = $"Ű���� (+{itemValue})";
        textAtt.text = $"���ݷ� : 50 (+{itemAtt})";
        textValue.text = $"��ȭ�� : {itemValue} / 10";
        textChance.text = $"��ȭ Ȯ�� : {100 - (itemValue * 10)}%";
    }
}
