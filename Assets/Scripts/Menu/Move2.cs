using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
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
        if (pos.x - transform.position.x < 0)
        {
            Cr.localScale = new Vector3(1f, 1f, 1);
            Cr.localPosition = new Vector3(Cr.localPosition.x - 3.260001f, Cr.localPosition.y, Cr.localPosition.z);

        }
        else
        {
            Cr.localScale = new Vector3(-1f, 1f, 1);
            Cr.localPosition = new Vector3(Cr.localPosition.x + 3.260001f, Cr.localPosition.y, Cr.localPosition.z);

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

        yield return new WaitForSeconds(Random.Range(1, 4));

        float w = Cr.rect.width;
        float h = Cr.rect.height;
        float pos_x = Random.Range(w / 2, Screen.width - w / 2);
        float pos_y = Random.Range(h / 2, Screen.height - h / 2);

        pos = new Vector2(pos_x, pos_y);


    }
}