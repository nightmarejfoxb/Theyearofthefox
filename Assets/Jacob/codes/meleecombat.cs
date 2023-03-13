using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleecombat : MonoBehaviour
{
    public Animator ai;

    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public Transform LeftAttack;
    public Transform RightAttack;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
          if (Input.GetKeyDown(KeyCode.T))
          {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
          }
        }

        if(Input.GetAxis("Horizontal")>0)
        {
            attackpoint.position = RightAttack.position;
        }
        else if( Input.GetAxis("Horizontal")<0)
        {
            attackpoint.position = LeftAttack.position;
        }
        
    }

    void Attack()
    {
        ai.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if(enemy.gameObject.CompareTag("Enemy"))
            {
                enemy.gameObject.GetComponent<PatrollingEnemy>().TakeDamage(1);
            }
            Debug.Log("we hit" + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
        
    }

}
