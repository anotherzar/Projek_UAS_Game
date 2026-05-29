using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject cardBack;
    public GameObject cardFront;
    public Image frontImage;
    public Button button;

    [Header("Card Properties")]
    public int cardID;

    private MemoryManager manager;

    public void Setup(int id, Sprite sprite, MemoryManager mgr)
    {
        cardID = id;
        if (frontImage != null)
            frontImage.sprite = sprite;
        manager = mgr;
        
        CloseCardImmediate();
        
        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnCardClicked);
        }
    }

    public void OnCardClicked()
    {
        manager.CardClicked(this);
    }

    public void OpenCard()
    {
        if (cardBack != null) cardBack.SetActive(false);
        if (cardFront != null) cardFront.SetActive(true);
        if (button != null) button.interactable = false;
    }

    public void CloseCard()
    {
        if (cardBack != null) cardBack.SetActive(true);
        if (cardFront != null) cardFront.SetActive(false);
        if (button != null) button.interactable = true;
    }

    public void CloseCardImmediate()
    {
        if (cardBack != null) cardBack.SetActive(true);
        if (cardFront != null) cardFront.SetActive(false);
        if (button != null) button.interactable = true;
    }
}
