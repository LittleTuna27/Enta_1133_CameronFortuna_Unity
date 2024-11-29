using UnityEngine;
using DG.Tweening;



public class Inventory : MonoBehaviour 
{
    RectTransform InventoryRectT;
    public bool _inInventory = false;

    public GameObject buttonPrefab; // Assign the button prefab in the Inspector
    public Transform inventoryPanel; // Assign the inventory panel (with Vertical Layout Group)
    public GameObject UseItemUI;

    public void Awake()
    {
        InventoryRectT = GetComponent<RectTransform>();
        Debug.Log("InventoryRectT assigned: " + (InventoryRectT != null));
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory();
        }
    }
    public void inventory()
    {
            if (Input.GetKeyDown(KeyCode.I)) // escape button for menu
            {
                if (!_inInventory)
                {
                    inventotryOpen();
                }
                else
                {
                    inventotryClose();
                }
            }
    }
   
    public void inventotryOpen()
    {
        _inInventory = true;
        InventoryRectT.DOAnchorPosX(0, 0.5f).SetEase(Ease.InOutQuad);
    }
    public void inventotryClose()
    {
            InventoryRectT.DOAnchorPosX(-InventoryRectT.rect.width, 0.5f).SetEase(Ease.InOutQuad);
            _inInventory = false;
    }
    public void DoUseItem()
    {
        UseItemUI.SetActive(true);

    }
}
