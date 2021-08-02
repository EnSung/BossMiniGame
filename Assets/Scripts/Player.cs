using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator anim;

    public Attack atk;

    public float MaxHp = 10;
    public float currentHp;
    public bool isStop = false;
    public float atkrange = 0.6f;
    public float STKk_Power = 2;


    public bool isGround = true;

    [SerializeField]
    float JumpForce = 600f;
    

    [SerializeField]
    Transform atkTransform;
    void Start()
    {
        currentHp = MaxHp;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update()
    {
        if(currentHp<= 0)
        {
            anim.SetBool("Die", true);
            Invoke("End", 0.8f);
            UIManager.Instance.GameOver();

        }
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }
    void End()
    {
        Time.timeScale = 0;
    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(atkTransform.position, atkrange);
        Debug.DrawRay(transform.position, Vector2.down);
    }

    void Attack()
    {
        Collider2D[] hitinfo = Physics2D.OverlapCircleAll(atkTransform.position, atkrange, LayerMask.GetMask("Boss"));

        foreach (Collider2D enemy in hitinfo)
        {
            Debug.Log($"hit {enemy.name}");
            enemy.GetComponent<Boss>().BossDamaged(STKk_Power);
        }
    }

    public void Damaged(float value)
    {
        anim.SetTrigger("Damaged");
        currentHp -= value;
    }

    void OnisStop()
    {
        isStop = true;
    }

    void OffisStop()
    {
        isStop = false;
    }


    void GroundCheck()
    {
        var hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 1.2f,LayerMask.GetMask("Ground"));

    
        if(hitinfo.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
       
    }

    public void SetisattackT()
    {
        atk.isAttack = true;
    }

    public void SetisattackF()
    {
        atk.isAttack = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DeadLine")
        {
            currentHp = 0;
        }
    }
}
