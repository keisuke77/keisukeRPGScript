using UnityEngine;
 public enum DiretionEnum
    {
        No,forward,backward,up,down,right,left
    }
public static class TransformExtensions
{

    public static Vector3 CameraDirection(this Transform tra,Camera cam,Vector2 vec){

     var cameravelc = Quaternion.AngleAxis(cam.transform.eulerAngles.y, Vector3.up);
       return cameravelc * new Vector3(vec.x, 0, vec.y).normalized;
     
    }
       public static Vector3 GetDirection(this Transform tra, DiretionEnum dir)
    {
       switch (dir)
       {
        case DiretionEnum.forward:
        return tra.forward;
            break;
            break; case DiretionEnum.backward:
        return -tra.forward;
            break;
            break; case DiretionEnum.up:
        return tra.up;
            break;
            break; case DiretionEnum.down:
        return -tra.up;
            break;

         case DiretionEnum.right:
        return tra.right; 
            break;
        case DiretionEnum.left:
        return -tra.right;
          
            break;
        default:
            break;
       }
       return Vector3.zero;
    }
    public static void SetPos(this Transform transform, float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    public static void AddPos(this Transform transform, float x, float y, float z)
    {
        transform.position = new Vector3(transform.position.x + x,
            transform.position.y + y, transform.position.z + z);
    }

    public static void SetPosX(this Transform transform, float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public static void SetPosY(this Transform transform, float y)
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    public static void SetPosZ(this Transform transform, float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
  public static void AddLocalPosX(this Transform transform, float x)
    {
        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z);
    }

    public static void AddLocalPosY(this Transform transform, float y)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + y, transform.localPosition.z);
    }

    public static void AddLocalPosZ(this Transform transform, float z)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + z);
    }
    public static void AddPosX(this Transform transform, float x)
    {
        transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);
    }

    public static void AddPosY(this Transform transform, float y)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);
    }

    public static void AddPosZ(this Transform transform, float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + z);
    }
}