using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections.Generic;

[System.Serializable]
public class OutlineDetails
{
    public Color color;
    public Vector2 size;
}

[System.Serializable]
public class ImageEventPair
{
    public Image image;
    [HideInInspector]public Vector3 defaultScale;
    public UnityEvent eventOnSelect;
    public UnityEvent preEventOnSelect;
    
}

public class ImageSelectorGrid : MonoBehaviour
{
    public List<ImageEventPair> imageEventPairs;
    public float selectedScale = 1.2f;
    public float decisionPunchScale = 1.5f;
    public float duration = 0.2f;
    private int selectedIndex = 0;
    public AudioClip selectionChangedSound;
    public AudioClip selectionMadeSound;
    private AudioSource audioSource;
    public bool enableWrap = false;
    private bool isSelecting = false;
    public KeyCode decisionKey = KeyCode.Return;  // The key used for making decision
    public UnityEvent onDecisionMade;  // Event that will be triggered when a decision is made
 public OutlineDetails outlineDetails;

 public float SelectableAngle=45;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        foreach (var pair in imageEventPairs)
        {
            pair.defaultScale = pair.image.transform.localScale;
        }
        SelectImage(selectedIndex);
    }
public controll Xaxis;
public controll Yaxis;
public float SequenceInterval=0.5f;
public bool Stop;
public Vector2 dir;
[Header("この閾値未満の角度差の場合、距離が短いものを選択します")]
 public float angleThreshold = 15f; // 
    
    private void Update()
    {
        int previousIndex = selectedIndex;
         dir=new Vector2(keiinput.Instance.GetAxis(Xaxis), keiinput.Instance.GetAxis(Yaxis));
     
        if (dir!=Vector2.zero&&!Stop)
        { Stop=true;
             keikei.delaycall(()=>Stop=false,SequenceInterval);
             FindClosestImage(dir);
            
        }

        if (selectedIndex != previousIndex)
        {
            DeselectImage(previousIndex);
            SelectImage(selectedIndex);
            PlaySound(selectionChangedSound);
        }

        if (!isSelecting && Input.GetKeyDown(decisionKey))
        {    onDecisionMade?.Invoke();  // Trigger the onDecisionMade event when decision key is pressed
   
            OnImageSelected(selectedIndex);
            PlaySound(selectionMadeSound);
             }
    }

    private void FindClosestImage(Vector2 input)
    {
        ImageEventPair currentPair = imageEventPairs[selectedIndex];
        Vector3 direction = new Vector3(input.x, input.y, 0);
        float closestDist = Mathf.Infinity;
        ImageEventPair closestPair = null;
        float smallestAngle = Mathf.Infinity;  // 追加: 最小角度のトラッキングのための変数

        foreach (ImageEventPair pair in imageEventPairs)
        {
            if (pair == currentPair)
                continue;

            Vector3 toOther = pair.image.transform.position - currentPair.image.transform.position;
            float angle = Vector3.Angle(direction, toOther);

            if (angle < SelectableAngle)
            {
                float dist = toOther.magnitude;

                // 以下の条件は、角度差がangleThreshold未満の場合、距離が最も短いものを選択します。
                // そうでない場合、角度差が最小のものを選択します。
                if (angle < angleThreshold && dist < closestDist)
                {
                    closestDist = dist;
                    closestPair = pair;
                }
                else if (angle < smallestAngle)
                {
                    smallestAngle = angle;
                    closestPair = pair;
                }
            }
        }

        if (closestPair != null)
        {
            selectedIndex = imageEventPairs.IndexOf(closestPair);
        }
        else if (enableWrap)
        {
            if (input.y > 0 || input.x > 0)
            {
                selectedIndex = 0;
            }
            else
            {
                selectedIndex = imageEventPairs.Count - 1;
            }
        }
    }
    private void SelectImage(int index)
    {
        var imagePair = imageEventPairs[index];
        imagePair.preEventOnSelect.Invoke();
        imagePair.image.transform.DOScale(imagePair.defaultScale*selectedScale, duration);
        Outline outline = imagePair.image.gameObject.AddComponentIfnull<Outline>() as Outline;
        if (outline != null)
        {
            outline.effectColor = outlineDetails.color; // 共通のoutlineDetailsを使用
            outline.effectDistance = outlineDetails.size; // 共通のoutlineDetailsを使用
            outline.enabled = true;
        }
    }

    private void DeselectImage(int index)
    {
        var imagePair = imageEventPairs[index];
        imagePair.image.transform.DOScale(imagePair.defaultScale, duration);
        Outline outline = imagePair.image.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

    private void OnImageSelected(int index)
    {
        isSelecting = true;
        imageEventPairs[index].eventOnSelect.Invoke();
        var image = imageEventPairs[index].image;
        image.transform.DOPunchScale(imageEventPairs[index].defaultScale*decisionPunchScale, duration).OnComplete(() => {
            isSelecting = false;
        });
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
