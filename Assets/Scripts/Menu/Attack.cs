using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour,IPointerDownHandler
{
    public Player player;
    public Animator anim;

    public bool isAttack = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.isGround && !isAttack)
        {
            
            anim.SetTrigger("Attack");
        }
    }

    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
