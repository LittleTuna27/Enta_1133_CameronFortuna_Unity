using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] private TMP_Text roomText; // Reference to TMP_Text component
    private RectTransform roomRectT; // Reference to RectTransform


    public void Awake()
    {
        roomRectT = GetComponent<RectTransform>();
        roomText = GetComponentInChildren<TMP_Text>(); // Dynamically find TMP_Text in child
    }

    // Updates the text displayed in the TextBox
    public void UpdateRoomText(string newMessasge)
    {
        roomText.text = newMessasge;
    }
    public void OpenText()
    {
        roomRectT.DOAnchorPosY(0, 0.5f).SetEase(Ease.InOutQuad);
    }
    public void CloseText()
    {
        roomRectT.DOAnchorPosY(-roomRectT.rect.height, 0.5f).SetEase(Ease.InOutQuad);
    }

}

