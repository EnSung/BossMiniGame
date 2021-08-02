using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_walkState : StateMachineBehaviour
{
    public Boss boss;
    public Transform bossTransform;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        bossTransform = GameObject.Find("Pivot").transform;

        if (Vector2.Distance(boss.playerTransform.position, bossTransform.position) <= 4)
        {
            animator.SetBool("isFollow", false);
            animator.SetBool("isReady", true);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(boss.playerTransform.position, bossTransform.position) <= 4)
        {
            animator.SetBool("isFollow", false);
            animator.SetBool("isReady", true);
        }

        if (boss.playerTransform.position.x - bossTransform.position.x > 0) // 플레이어가 오른쪽에 있을 때
        {

            if(animator.transform.localScale.x > 0)
            {
                animator.transform.localScale =new Vector2( animator.transform.localScale.x * -1,animator.transform.localScale.y);
                animator.transform.position = new Vector2(animator.transform.position.x + 3.260001f, animator.transform.position.y);
            }
            
            animator.transform.Translate(new Vector2(boss.moveSpeed * Time.deltaTime, 0));

        }
        else
        {


            if (animator.transform.localScale.x < 0)
            {
                animator.transform.localScale = new Vector2(animator.transform.localScale.x * -1, animator.transform.localScale.y);
                animator.transform.position = new Vector2(animator.transform.position.x - 3.260001f, animator.transform.position.y);
            }


            animator.transform.Translate(new Vector2(-1 * boss.moveSpeed * Time.deltaTime, 0));

        }


        

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
