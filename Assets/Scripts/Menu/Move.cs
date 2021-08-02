using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public Animator anim;

    public Vector2 pos;
    public RectTransform Cr;
    public float moveSpeed = 150;
    void Start()
    {
        anim = GetComponent<Animator>();

        float w = Cr.rect.width;
        float h = Cr.rect.height;
        float pos_x = Random.Range(w / 2, Screen.width - w / 2);
        float pos_y = Random.Range(h / 2, Screen.height - h / 2);

        pos = new Vector2(pos_x, pos_y);
    }

    void Update()
    {
        anim.SetBool("isWalk", true);
        if(pos.x - transform.position.x > 0)
        {
            Cr.localScale = new Vector3(4.5f,4.5f,1);
        }
        else
        {
            Cr.localScale = new Vector3(-4.5f, 4.5f, 1);

        }
        Cr.position = Vector2.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);

        if (pos == (Vector2)transform.position)
        {
            StartCoroutine(MOVE());
        }
    }


    IEnumerator MOVE()
    {
        anim.SetBool("isWalk", false);
        if(Cr.localScale.x > 0)
        {
            Cr.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            Cr.localScale = new Vector3(-1, 1, 1);

        }
        yield return new WaitForSeconds(Random.Range(1,4));

        float w = Cr.rect.width;
        float h = Cr.rect.height;
        float pos_x = Random.Range(w / 2, Screen.width - w / 2);
        float pos_y = Random.Range(h / 2, Screen.height - h / 2);

        pos = new Vector2(pos_x, pos_y);


        StopAllCoroutines();
    }
}
