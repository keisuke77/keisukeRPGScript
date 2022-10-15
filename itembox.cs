


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "itembox", menuName = "New Unity Project (1)/itembox", order = 0)]
public class itembox : ScriptableObject {
    
int i;
   public List<Itemkind> mybox;
public void boxToScreen(ItemIconText[] ItemIconTexts){
foreach (var item in ItemIconTexts)
{
    item.icon.sprite=mybox[i].GetIcon();
      item.name.text=mybox[i].GetItemName();
  item.number.text=mybox[i].Getnumber().ToString();
  item.explain.text=mybox[i].GetInformation();
  
i++;

}
i=0;
}

bool once;
public void enteritem(Itemkind Itemkind){
    foreach (var item in mybox)
    {
        if (item==Itemkind)
        {
            item.addnumber(Itemkind.Getnumber());
            once=true;
        }
    }
    if (!once)
    {
        mybox.Add(Itemkind);
    }
    once=false;
}

}