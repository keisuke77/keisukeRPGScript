
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ItemSystem;

public class onmouceenter : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    
[SerializeField]
    private Text _text;

   
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.text = gameObject.GetComponent<itemuse>().Itemkind.GetItemName();
        _text.enabled=true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.text=gameObject.acessdata().Itemkind.GetItemName();  }
}
    
