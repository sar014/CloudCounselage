using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public Transform placeholder;
    public bool isFull = false;
    bool hasPickedRiddleCard = false;
    private GameObject currentCard;
    [SerializeField] public MatchCards matchCards;


    public void OnDrop(PointerEventData eventData)
    {
        var draggedItem = eventData.pointerDrag.GetComponent<RectTransform>();
        
        // Check if the dragged item is being placed in the placeholder and if the placeholder is empty
        if (IsOverPlaceholder(draggedItem) && !(isFull))
        {
            if(draggedItem.tag == placeholder.tag)
            {
                draggedItem.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                // Notify the card that it is placed in the slot
                draggedItem.GetComponent<dragdrop>().SetCurrentSlot(this);

                // Set the slot as full
                isFull = true;
                currentCard = eventData.pointerDrag;

                if(draggedItem.CompareTag("riddle"))
                    matchCards.GetRiddleName(currentCard);
                else
                    matchCards.MatchJobs(currentCard);
            
            }
        }


    }

    private bool IsOverPlaceholder(RectTransform draggedItem)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(
            placeholder.GetComponent<RectTransform>(),
            Input.mousePosition,
            null 
        );
    }

    // Call this when the current card is dragged away from the slot
    public void ResetSlot()
    {
        isFull = false;
        currentCard = null; // Clear the reference to the card
    }
}
