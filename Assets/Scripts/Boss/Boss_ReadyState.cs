using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ReadyState : StateMachineBehaviour
{
    public Boss boss;
    public Transform bossTransform;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        bossTransform = GameObject.Find("Pivot").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(boss.currentAttackTime >= boss.AttckDelay)
        {
            animator.SetTrigger("Attack");
            boss.currentAttackTime = 0;
        }

        if (Vector2.Distance(boss.playerTransform.position, bossTransform.position) > 4)
        {
            animator.SetBool("isFollow", true);
            animator.SetBool("isReady", false);
        }

        if(animator.transform.localScale.x > 0)
        {
            if(boss.playerTransform.position.x - bossTransform.position.x > 0)
            {
                animator.SetBool("isFollow", true);
                animator.SetBool("isReady", false);
            }
        }
        else
        {
            if (boss.playerTransform.position.x - bossTransform.position.x < 0)
            {
                animator.SetBool("isFollow", true);
                animator.SetBool("isReady", false);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
