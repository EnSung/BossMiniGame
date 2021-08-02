using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float MaxHp = 100;
    public float Hp;
    public float StrikingPower = 5;
    public float SkillDamage = 10;


    public Transform atkPos;
    public float atkRange;
     public Transform playerTransform;
    public float moveSpeed = 8f;
    public float currentAttackTime = 0;
    public float AttckDelay = 2;


    public float DamagedDelay = 1.8f;
    public float currentDamagedDelay = 0;


    public float skillDelay = 8;
    public float currentskillDelay = 0;
    Animator anim;

    public GameObject SkillPrefab;
    void Start()
    {
        Hp = MaxHp;
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(Hp<= 0)
        {
            anim.SetBool("Die", true);
            var col = GetComponent<Collider2D>();
            Destroy(col);
            UIManager.Instance.GameClear();
            Destroy(gameObject, 0.9f);
        }
        currentAttackTime += Time.deltaTime;
        currentDamagedDelay += Time.deltaTime;
        currentskillDelay += Time.deltaTime;
        if(currentskillDelay>= skillDelay)
        {
            Skill();
            skillDelay = Random.Range(1, 8);
        }
    }

    void bossAttck()
    {
        Collider2D[] hitinfo = Physics2D.OverlapCircleAll(atkPos.position, atkRange, LayerMask.GetMask("Player"));

        foreach (Collider2D enemy in hitinfo)
        {
            Debug.Log($"hit {enemy.name}");

            enemy.GetComponent<Player>().Damaged(StrikingPower);
            /*if (enemy.tag == "Goblin")
            {
                goblin.Goblin_Damage();
            }*/
        }
    }

    public void BossDamaged(float value)
    {
        if (currentDamagedDelay >= DamagedDelay)
        {
            anim.SetTrigger("Damaged");
            Hp -= value;
            currentDamagedDelay = 0;

        }
        else
        {
            Damaged(value);
        }
    }

    public void Damaged(float value)
    {
        Hp -= value;
    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(atkPos.position, atkRange);
    }

    void Skill()
    {
        anim.SetTrigger("Skill");
    }

    void SkillSpawn()
    {
        Instantiate(SkillPrefab,new Vector2(playerTransform.position.x + 0.1f, 0.11f), transform.rotation);
        currentskillDelay = 0;
    }
}
