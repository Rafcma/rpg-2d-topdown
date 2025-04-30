using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount;// qnts cavadas
    [SerializeField] private float waterAmount;// total de agua pra nascer cenoura
    [SerializeField] private bool detecting;
    
    private int initialDigAmount;
    private float currentWater;
    private bool dugHole;// checa se o buraco foi cavado

    PlayerItems playerItems;

    private void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        initialDigAmount = digAmount;
    }

    private void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            if (currentWater >= waterAmount)// checa se encheu o total de agua
            {
                spriteRenderer.sprite = carrot;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    spriteRenderer.sprite = hole;
                    playerItems.Carrots++;
                    currentWater = 0f;
                }
            }
        }
        
    }

    public void OnHit()
    {
        digAmount--;

        if(digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }

        //    if (digAmount <= 0)
        //    {
        //        spriteRenderer.sprite = carrot;
        //    }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }

        if (collision.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detecting = false;
    }
}
