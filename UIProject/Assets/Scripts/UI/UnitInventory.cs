using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInventory : MonoBehaviour {

    public Button createBtn;
    public Button moneyBtn;
    public Button gemSelectBtn;
    public Text createBtnGemText;
    public Text inventoryMsg;

    private int userGold;
    private List<string> userInventory = new List<string>();
    private List<string> item_table = new List<string>();
    private int choseGemNum;
    private string choseGem;


    private void Start() {
        UpgradeUI upgradeUI = GetComponent<UpgradeUI>();

        foreach (string readString in upgradeUI.materials) {
            string[] checkString = readString.Split('+');
            for (int i = 1; i < checkString.Length; i++) {
                if (!item_table.Contains(checkString[i])) item_table.Add(checkString[i]);
            }
        }

        choseGem = item_table[0];
        choseGemNum = 0;

        createBtn.onClick.AddListener(OnCreateBtnBtnClick);
        moneyBtn.onClick.AddListener(OnMoneyBtnClick);
        gemSelectBtn.onClick.AddListener(OnGemSelectBtnClick);

        UpdateInventoryUI();
    }
    private void OnCreateBtnBtnClick() {
        if (item_table.Contains(choseGem) && !userInventory.Contains(choseGem)) {
            userInventory.Add(choseGem);
        }
        UpdateInventoryUI();
    }
    private void OnMoneyBtnClick() {
        userGold += 100;
        UpdateInventoryUI();
    }
    private void OnGemSelectBtnClick() {
        if (choseGemNum == item_table.Count - 1) {
            choseGemNum = 0;
            choseGem = item_table[0];
        }
        else {
            choseGemNum++;
            choseGem = item_table[choseGemNum];
        }
        UpdateInventoryUI();
    }
    public bool CheckInventoryResource() {
        bool checkPassed = false;
        switch (UpgradeUI.upgrade) {
            case 0: {
                if (userGold >= 100) {
                    checkPassed = true;
                    userGold -= 100;
                    UpdateInventoryUI();
                }
                break;
            }
            case 1: {
                if (userGold >= 100 && userInventory.Contains("루비")) {
                    checkPassed = true;
                    userGold -= 100;
                    userInventory.Remove("루비");
                    UpdateInventoryUI();
                }
                break;
            }
            case 2: {
                if (userGold >= 200 && userInventory.Contains("사파이어") && userInventory.Contains("마력석")) {
                    checkPassed = true;
                    userGold -= 200;
                    userInventory.Remove("사파이어");
                    userInventory.Remove("마력석");
                    UpdateInventoryUI();
                }
                break;
            }
            case 3:
                break;
            default:
                break;
        }
        return checkPassed;
    }
    private void UpdateInventoryUI() {
        createBtnGemText.text = choseGem;
        inventoryMsg.text = $"<인벤토리>\n{userGold} 골드\n" + string.Join("\n", userInventory);
    }
}
