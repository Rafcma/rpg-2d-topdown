using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;


    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image ShovelUI;
    //[SerializeField] private Image BucketUI;
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    public List<Image> toolsUI = new List<Image>();


    private PlayerItems playerItems;
    private Player player;

    private void Awake() // sempre antes do start
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }

    void Start() // uma vez por chamada
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;

    }

    void Update()
    {
        waterUIBar.fillAmount = playerItems.CurrentWater / playerItems.WaterLimit;
        woodUIBar.fillAmount = playerItems.TotalWood / playerItems.WoodLimit;
        carrotUIBar.fillAmount = playerItems.Carrots / playerItems.CarrotsLimit;
        fishUIBar.fillAmount = playerItems.Fishes / playerItems.FishLimit;


        //toolsUI[player.handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
