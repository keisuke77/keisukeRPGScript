using UnityEngine;

using UnityEngine.EventSystems;
public class tapinfo : MonoBehaviour
{public string text;
public GameObject effect;
     public void OnClick3DObject( BaseEventData eventData )
        {
            
            
            Instantiate(effect,((PointerEventData)eventData).position,Quaternion.identity);
text.CreateMesImage(gameObject,Vector3.up,3);

        }
}