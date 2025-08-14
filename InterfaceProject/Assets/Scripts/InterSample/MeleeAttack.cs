using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Melee")]
public class MeleeAttack : ScriptableObject, IAttackStrategy {
    public void Attack(GameObject target, ScriptableObject attackType) {
        Debug.Log($"[{attackType}] {target}");
        SpriteRenderer targetSR = target.GetComponent<SpriteRenderer>();
        targetSR.color = Color.red;
    }
}
