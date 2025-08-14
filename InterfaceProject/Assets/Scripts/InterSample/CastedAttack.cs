using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Cast")]
public class CastedAttack : ScriptableObject, IAttackStrategy {
    public void Attack(GameObject target, ScriptableObject attackType) {
        Debug.Log($"[{attackType}] {target}");
        SpriteRenderer targetSR = target.GetComponent<SpriteRenderer>();
        targetSR.color = Color.yellow;
    }
}