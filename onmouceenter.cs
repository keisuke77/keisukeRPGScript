
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
<<<<<<< HEAD
using ItemSystem;
=======

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

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
    
