using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    private float initialSpeed;

    private int index;
    private Animator anim;

    public List<Transform> paths = new List<Transform>();


    private void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (DialogueControl.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            paths[index].position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f) //Contagem de paths
        {
            if (index < paths.Count - 1)
            {
                //index++; //index soma normal, segue os paths em ordem
                index = Random.Range(0, paths.Count - 1); // segue os paths de forma aleatoria
            }
            else
            {
                index = 0;
            }
        }

        Vector2 directio = paths[index].position - transform.position;

        if(directio.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(directio.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
