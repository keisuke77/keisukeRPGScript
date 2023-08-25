using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
<<<<<<< HEAD
public class itemdrops
{
    public itemdrop itemdrop;

    [Range(0, 1)]
    public float droprate;
    public bool usechest;

    // Start is called before the first frame update


    public void itemdropset(itemdrop items)
    {
        itemdrop = items;
    }

    public void itemdropers()
    {
        itemdropers(keikei.player);
    }

    public void itemdropers(GameObject obj)
    {
=======
public class itemdrops 
{
    public itemdrop itemdrop;
   [Range(0,1)]
    public float droprate;
    public bool usechest;
    // Start is called before the first frame update


    public void itemdropset(itemdrop items){

        itemdrop=items;
    }
    public void itemdropers(){
        itemdropers(keikei.player);
    }
    public void itemdropers(GameObject obj){
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        if (!droprate.GetRatecheck())
        {
            return;
        }
<<<<<<< HEAD
        if (usechest)
        {
            var a = keikei.instantiate(
                keikei.treasure,
                obj.transform.position,
                Quaternion.identity
            );
            keikei.itemappend(a);
            a.GetComponent<GIE.Chest>().itemdrop = itemdrop;
        }
        else
        {
            obj.itemdroper(itemdrop);
        }
    }

    // Update is called once per frame
=======
if (usechest)
{
     var a = keikei.instantiate(keikei.treasure,obj.transform.position,Quaternion.identity);
      keikei.itemappend(a);    
a.GetComponent<GIE.Chest>().itemdrop=itemdrop;
 
}else{

    obj.itemdroper(itemdrop);
}

          
    }
 
    // Update is called once per frame
 
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
