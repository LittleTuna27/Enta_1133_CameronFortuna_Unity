using UnityEngine;
using UnityEngine.UI;

public class ItemButtonScript : MonoBehaviour
{
    public Button confirmButton;
    public Item thisItem;
    public void linkItemToConfirmDialogue()
    {
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(thisItem.UseItem);
    }
}
