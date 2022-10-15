using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class buttongroup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

  public List<int> pointerList;

    void Start()
    {
        pointerList = new List<int>();
    }
    
    public void OnPointerDown(PointerEventData ev)
    {
        pointerList.Add(ev.pointerId);
        IterateAllChildren(transform, obj => {
            var arrowButton = obj.GetComponent<SlidableButton>();
            if (arrowButton != null)
            {
                arrowButton.OnGroupPointerDown();
            }
        });
    }

    public void OnPointerUp(PointerEventData ev)
    {
        pointerList.Remove(ev.pointerId);

        if (pointerList.Count > 0) return;

        IterateAllChildren(transform, obj => {
            var arrowButton = obj.GetComponent<SlidableButton>();
            if (arrowButton != null)
            {
                arrowButton.OnGroupPointerUp();
            }
        });
    }

    void IterateAllChildren(Transform transform, System.Action<GameObject> action)
    {
        action(transform.gameObject);

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            IterateAllChildren(child, action);
        }
    }
    
}