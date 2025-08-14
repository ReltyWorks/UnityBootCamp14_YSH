using UnityEngine;

public class InterPlayer : MonoBehaviour {

    // 인스펙터 내에서 접근 가능 (내부 데이터 연결 목적)
    // 외부에서 접근 불가 (함부로 값 쓰지 말라는 용도)
    [SerializeField] private ScriptableObject attackC;
    [SerializeField] private ScriptableObject attackR;
    [SerializeField] private ScriptableObject attackM;

    private IAttackStrategy strategy;

    private Transform playerTr;
    private Transform enemyTr;

    private float distance;

    public void ActionPerformed(GameObject target) {

        //거리 계산
        playerTr = transform.transform;
        enemyTr = target.transform.transform;
        distance = Vector2.Distance(playerTr.position, enemyTr.position);

        if (distance > 5) {
            strategy = attackC as IAttackStrategy;
            if (strategy == null) Debug.LogError("공격 기능이 구현되지 않았습니다!");
            else strategy?.Attack(target, attackC);
        }

        else if (distance > 3) {
            strategy = attackR as IAttackStrategy;
            if (strategy == null) Debug.LogError("공격 기능이 구현되지 않았습니다!");
            else strategy?.Attack(target, attackR);
        }
        else {
            strategy = attackM as IAttackStrategy;
            if (strategy == null) Debug.LogError("공격 기능이 구현되지 않았습니다!");
            else strategy?.Attack(target, attackM);
        }
        // Nullable<T> or T? 는 Value에 대한 null 허용을 위한 도구
    }
}
