using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Transform atkPos;
    public Boss boss;
    public float atkRangeX;
    public float atkRangeY;


    private void Awake()
    {
        boss = GameObject.Find("Boss").GetComponent<Boss>();

    }
    void Attack()
    {

        Collider2D[] hitinfo = Physics2D.OverlapBoxAll(atkPos.position, new Vector2(atkRangeX,atkRangeY), LayerMask.GetMask("Player"));

        foreach (Collider2D enemy in hitinfo)
        {
            if(enemy.tag != "Player")
            {
                return;
            }
            Debug.Log($"hit {enemy.name}");

            enemy.GetComponent<Player>().Damaged(boss.SkillDamage);
            /*if (enemy.tag == "Goblin")
            {
                goblin.Goblin_Damage();
            }*/
        }
    }

    void Des()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawCube(atkPos.position, new Vector2(atkRangeX, atkRangeY));
    }
}
