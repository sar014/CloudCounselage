using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Interactions;

public class dragdrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler, IDragHandler, IPointerClickHandler
{

    [SerializeField] private Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    public bool OnPlaceholder = false;
    UnityEngine.Vector3 originalPos;
    private ItemSlot currentSlot;

    void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPos = this.transform.localPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        // If the card is being dragged off a placeholder, reset the slot
        if (OnPlaceholder && currentSlot != null)
        {
            currentSlot.ResetSlot(); // Notify the slot that the card is being dragged away
            currentSlot = null; // Clear the reference to the slot
            OnPlaceholder = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition+=eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        // If the card is not placed in a placeholder, return it to its original position
        if (!OnPlaceholder)
        {
            ReturnToOriginalPosition();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    
    }

    public void OnSuccessfullMatch()
    {
        currentSlot.ResetSlot();
    }


    public void ReturnToOriginalPosition()
    {
        rectTransform.localPosition = originalPos;

        // Reset the slot (if the card was placed in one before)
        if (currentSlot != null)
        {
            currentSlot.ResetSlot();
            currentSlot = null;
        }
    }

    // Set the current slot the card is placed in
    public void SetCurrentSlot(ItemSlot slot)
    {
        currentSlot = slot;
        OnPlaceholder = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
         
    }
}
