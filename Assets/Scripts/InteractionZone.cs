using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject interactPrompt;
    private bool playerInZone;
    public MiniGameData minigameData;
    void Start()
    {
        interactPrompt.SetActive(false);
    }
    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.Z))
        {
            interactPrompt.SetActive(false);
            UIManager.Instance.ShowMiniGameUI(minigameData);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = true;
            interactPrompt.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = false;
            interactPrompt.SetActive(false);
        }
    }
}
