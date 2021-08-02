using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Jump : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public Rigidbody2D rigid;
    bool isClick;
    public float jumpForce = 400;
    public Player player;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.isGround) {
            isClick = true;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpForce);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
    }

void Start()
    {
        
    }

    void Update()
    {


        if (rigid.velocity.y > 0 && isClick == false)
        {
            rigid.velocity = rigid.velocity * 0.5f;

        }
    }
}
