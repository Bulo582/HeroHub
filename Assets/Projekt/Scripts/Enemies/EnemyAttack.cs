using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyHitbox hitbox;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float activeTime = 0.2f;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackCooldown);
            hitbox.Enable();
            yield return new WaitForSeconds(activeTime);
            hitbox.Disable();
        }
    }
}
