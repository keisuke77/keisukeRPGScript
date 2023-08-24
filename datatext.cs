using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

  public enum DataType
    {
        money,exp,power,hp,name,questinfo
    }

    
public class datatext : MonoBehaviour
{
    data data;
    Text text;
    public DataType datatype;
  
    // Start is called before the first frame update
    void Start()
    {data=gameObject.acessdata();
       text= GetComponent<Text>();
    }
string GetText(){
switch (datatype)
    {
        case DataType.money: return "所持金:"+data.money.ToString();
            break; case DataType.name: return "名前:"+data.name;
            break; case DataType.exp: return "経験値:"+data.exp.ToString();
            break; case DataType.questinfo: return "クエスト情報:"+  data.nowquest.textinpress();
            break;      
        default:
        return null;
            break;
    }
}
    // Update is called once per frame
    void Update()
    {
    
        text.text=GetText();
    }
}
