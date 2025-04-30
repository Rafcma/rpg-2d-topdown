using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{

    [SerializeField] private int percentage; // chance de pescar 1 peixe
    [SerializeField] private GameObject fishPrefab;


    private bool detectingPlayer;
    private PlayerItems player;
    private PlayerAnim playerAnim;

    void Start()
    {
        player = FindObjectOfType<PlayerItems>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if(randomValue <= percentage)
        {
            float xOffset = Random.Range(1f, 2f) * (Random.value < 0.5f ? -1 : 1);
            Vector3 spawnPosition = player.transform.position + new Vector3(xOffset, 0f, 0f);
            Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
