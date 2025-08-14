using UnityEngine;

public class InterPlayer : MonoBehaviour {

    // �ν����� ������ ���� ���� (���� ������ ���� ����)
    // �ܺο��� ���� �Ұ� (�Ժη� �� ���� ����� �뵵)
    [SerializeField] private ScriptableObject attackC;
    [SerializeField] private ScriptableObject attackR;
    [SerializeField] private ScriptableObject attackM;

    private IAttackStrategy strategy;

    private Transform playerTr;
    private Transform enemyTr;

    private float distance;

    public void ActionPerformed(GameObject target) {

        //�Ÿ� ���
        playerTr = transform.transform;
        enemyTr = target.transform.transform;
        distance = Vector2.Distance(playerTr.position, enemyTr.position);

        if (distance > 5) {
            strategy = attackC as IAttackStrategy;
            if (strategy == null) Debug.LogError("���� ����� �������� �ʾҽ��ϴ�!");
            else strategy?.Attack(target, attackC);
        }

        else if (distance > 3) {
            strategy = attackR as IAttackStrategy;
            if (strategy == null) Debug.LogError("���� ����� �������� �ʾҽ��ϴ�!");
            else strategy?.Attack(target, attackR);
        }
        else {
            strategy = attackM as IAttackStrategy;
            if (strategy == null) Debug.LogError("���� ����� �������� �ʾҽ��ϴ�!");
            else strategy?.Attack(target, attackM);
        }
        // Nullable<T> or T? �� Value�� ���� null ����� ���� ����
    }
}
