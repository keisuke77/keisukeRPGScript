using UnityEngine;

public class itemboxscreen : MonoBehaviour
{
    public itembox itembox;
    public ItemIconText[] ItemIconTexts;
    

    public void enteritem(Itemkind Itemkind){
itembox.enteritem(Itemkind);

    }


    void Start()
    {
        itembox.boxToScreen(ItemIconTexts);
    }
}