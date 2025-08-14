using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Range")]
public class RangedAttack : ScriptableObject, IAttackStrategy {
    public void Attack(GameObject target, ScriptableObject attackType) {
        Debug.Log($"[{attackType}] {target}");
        SpriteRenderer targetSR = target.GetComponent<SpriteRenderer>();
        targetSR.color = Color.blue;
    }
}