using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

<<<<<<< HEAD
public class buttongroup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public List<int> pointerList;
=======
public class buttongroup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

  public List<int> pointerList;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

    void Start()
    {
        pointerList = new List<int>();
    }
<<<<<<< HEAD

    public void OnPointerDown(PointerEventData ev)
    {
        pointerList.Add(ev.pointerId);
        IterateAllChildren(
            transform,
            obj =>
            {
                var arrowButton = obj.GetComponent<SlidableButton>();
                if (arrowButton != null)
                {
                    arrowButton.OnGroupPointerDown();
                }
            }
        );
=======
    
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
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    }

    public void OnPointerUp(PointerEventData ev)
    {
        pointerList.Remove(ev.pointerId);

<<<<<<< HEAD
        if (pointerList.Count > 0)
            return;

        IterateAllChildren(
            transform,
            obj =>
            {
                var arrowButton = obj.GetComponent<SlidableButton>();
                if (arrowButton != null)
                {
                    arrowButton.OnGroupPointerUp();
                }
            }
        );
=======
        if (pointerList.Count > 0) return;

        IterateAllChildren(transform, obj => {
            var arrowButton = obj.GetComponent<SlidableButton>();
            if (arrowButton != null)
            {
                arrowButton.OnGroupPointerUp();
            }
        });
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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
<<<<<<< HEAD
}
=======
    
}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
