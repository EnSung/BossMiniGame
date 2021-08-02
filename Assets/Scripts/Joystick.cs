using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick : MonoBehaviour,IPointerDownHandler ,IPointerUpHandler , IDragHandler
{
    [SerializeField]
    private RectTransform rect_background;
    [SerializeField]
    private RectTransform rect_joystick;

    float moveSpeed = 8f;

    float radius;
    bool istouch;

    public Player playerMovement;
    public GameObject Player;
    public SpriteRenderer Playersp;
    public Animator anim;
    Vector2 movePos;
    void Start()
    {
        radius = rect_background.rect.width * 0.5f; // 반지름
    }




    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isStop)
        {
            Player.transform.Translate(movePos);
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_background.position;

        value = Vector2.ClampMagnitude(value, radius); // (n,m)넣을 시 n+-m만큼으로


        rect_joystick.localPosition = new Vector2(value.x,0);
        value = value.normalized;

        if (value.x < 0)
        {
            if (Player.transform.localScale.x > 0)
            {
                if (!playerMovement.isStop)
                {

                    Player.transform.localScale = new Vector2(Player.transform.localScale.x * -1, Player.transform.localScale.y);
                }
            }
        }
        else
        {
            if (Player.transform.localScale.x < 0)
            {
                if (!playerMovement.isStop)
                {
                    Player.transform.localScale = new Vector2(Player.transform.localScale.x * -1, Player.transform.localScale.y);
                }
            }
        }
        anim.SetBool("isRun", true);
        movePos = new Vector2(value.x * moveSpeed * Time.deltaTime, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        istouch = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        istouch = false;
        rect_joystick.localPosition = Vector3.zero;
        movePos = new Vector2(0, 0);
        anim.SetBool("isRun", false);
    }   
}
