using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryManager : MonoBehaviour
{
    [Header("UI References")]
    public Transform gridLayout;
    public GameObject winPanel;
    
    [Header("Prefabs & Data")]
    public GameObject memoryCardPrefab;
    public List<CardData> availableCards;

    private List<MemoryCard> spawnedCards = new List<MemoryCard>();

    private MemoryCard firstSelected;
    private MemoryCard secondSelected;

    private int totalPairs;
    private int matchedPairs;

    private bool isChecking = false;

    void Start()
    {
        if (winPanel != null) winPanel.SetActive(false);
        InitializeGame();
    }

    void InitializeGame()
    {
        if (availableCards == null || availableCards.Count == 0) return;

        List<CardData> deck = new List<CardData>();
        
        foreach (var data in availableCards)
        {
            deck.Add(data);
            deck.Add(data); // Pair
        }

        totalPairs = availableCards.Count;
        matchedPairs = 0;

        Shuffle(deck);

        foreach (var data in deck)
        {
            if (memoryCardPrefab != null && gridLayout != null)
            {
                GameObject cardObj = Instantiate(memoryCardPrefab, gridLayout);
                MemoryCard card = cardObj.GetComponent<MemoryCard>();
                if (card != null)
                {
                    card.Setup(data.cardID, data.cardSprite, this);
                    spawnedCards.Add(card);
                }
            }
        }
    }

    void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CardData temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void CardClicked(MemoryCard card)
    {
        if (isChecking) return;
        if (card == firstSelected) return;

        card.OpenCard();

        if (firstSelected == null)
        {
            firstSelected = card;
        }
        else
        {
            secondSelected = card;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        isChecking = true;

        yield return new WaitForSeconds(1.0f);

        if (firstSelected.cardID == secondSelected.cardID)
        {
            // Match
            if (firstSelected.button != null) firstSelected.button.interactable = false;
            if (secondSelected.button != null) secondSelected.button.interactable = false;
            matchedPairs++;

            if (matchedPairs >= totalPairs)
            {
                WinGame();
            }
        }
        else
        {
            // No match
            firstSelected.CloseCard();
            secondSelected.CloseCard();
        }

        firstSelected = null;
        secondSelected = null;
        isChecking = false;
    }

    void WinGame()
    {
        if (winPanel != null) winPanel.SetActive(true);
        Debug.Log("Puzzle Complete!");
    }
}
