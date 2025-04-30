using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private Casting cast;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
    }

    // Update � chamado uma vez a cada frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else 
            { 
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }
        if (player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }
        if (player.isWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }
    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }
    #endregion

    #region Fishing
    //chamado quando player pressiona bot�o de a��o acima da lagoa
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }
    //testado quando termina anima��o
    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }


    #endregion

}
