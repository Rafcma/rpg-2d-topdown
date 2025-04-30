using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int totalWood;
    [SerializeField] private float currentWater;
    [SerializeField] private int carrots;
    [SerializeField] private int fishes;

    [Header("Limits")]
    [SerializeField] private float waterLimit = 50; //max de agua
    [SerializeField] private float carrotsLimit = 10; //max de cenoura
    [SerializeField] private float woodLimit = 10; //max de madeira
    [SerializeField] private float fishLimit = 5; //max de peixe

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public float CurrentWater { get => currentWater; set => currentWater = value; }
    public int Carrots { get => carrots; set => carrots = value; }
    public float WaterLimit { get => waterLimit; set => waterLimit = value; }
    public float CarrotsLimit { get => carrotsLimit; set => carrotsLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }
    public int Fishes { get => fishes; set => fishes = value; }
    public float FishLimit { get => fishLimit; set => fishLimit = value; }

    public void CheckWaterLimit(float water)
    {
        if(CurrentWater < WaterLimit)
        {
            CurrentWater += water;
        }
    }

}
