
 public void extends(){

     
if (splitMessage[messageNum][nowTextNum].ToString()=="u"&&splitMessage[messageNum][nowTextNum+1].ToString()=="r"&&splitMessage[messageNum][nowTextNum+2].ToString()=="l")
  {
StartCoroutine(keikei.GetImageFromURL(url,Images));
nowTextNum=nowTextNum+3;
  }

if (splitMessage[messageNum][nowTextNum].ToString()=="t"&&splitMessage[messageNum][nowTextNum+1].ToString()=="r")
 {if (splitMessage[messageNum][nowTextNum+2].ToString()=="0")
     {

gameObject.pclass().AutoRotateCamera.atractend();
         nowTextNum=nowTextNum+3;
  
     }
     if (splitMessage[messageNum][nowTextNum+2].ToString()=="1")
     {
if (tr1)
{
    
gameObject.pclass().AutoRotateCamera.lerpatractcamera(tr1,cameradistance==0?-9.8f:cameradistance);
}
         nowTextNum=nowTextNum+3;
  
     }
     if (splitMessage[messageNum][nowTextNum+2].ToString()=="2")
     {

if (tr2)
{
    
gameObject.pclass().AutoRotateCamera.lerpatractcamera(tr2,cameradistance==0?-9.8f:cameradistance);   
}  
   nowTextNum=nowTextNum+3;
     }if (splitMessage[messageNum][nowTextNum+2].ToString()=="3")
     {

if (tr3)
{
    
gameObject.pclass().AutoRotateCamera.lerpatractcamera(tr3,cameradistance==0?-9.8f:cameradistance);   
}  
   nowTextNum=nowTextNum+3;
     }

 }
 }


