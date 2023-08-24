using UnityEngine;using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public static class NullableGameObjectExtensions
{

 public static T1 AddComponentIfnull<T1>(this UnityEngine.GameObject obj)where T1:UnityEngine.Component
 {
if (obj==null)
{
  return default(T1);
}else if(obj.GetComponent<T1>()==null)
{obj.AddComponent(typeof(T1));
  return obj.GetComponent<T1>();
}else
{return obj.GetComponent<T1>();
}

 }


 
public static void AddComponentsIfNullInChildren<T>(this UnityEngine.GameObject obj)where T:UnityEngine.Component
{

foreach (var item in obj.GetAllChild())
{
  item.AddComponentIfnull<T>();
}

}
    public static UnityEngine.Component GetComponentIfNotNull( this UnityEngine.GameObject self, System.Type type ) 
    {
        if ( self == null )
        {
            return default( UnityEngine.Component );
        }
        return self.GetComponent( type );   
    }
    
    public static T GetComponentIfNotNull<T>( this UnityEngine.GameObject self )where T:UnityEngine.Component    
    {
        if ( self == null )
        {
            return default( T );
        }else if (self.GetComponent<T>()!=null)
        {
            return self.GetComponent<T>();  
        }
       
          return default( T );
          
    }
    
    public static UnityEngine.Component GetComponentIfNotNull( this UnityEngine.GameObject self, System.String type )   
    {
        if ( self == null )
        {
            return default( UnityEngine.Component );
        }
        return self.GetComponent( type );   
    }
    
    public static UnityEngine.Component GetComponentInChildrenIfNotNull( this UnityEngine.GameObject self, System.Type type )   
    {
        if ( self == null )
        {
            return default( UnityEngine.Component );
        }
        return self.GetComponentInChildren( type ); 
    } 
    public static List<UnityEngine.GameObject> GetAllChild( this UnityEngine.GameObject self )   
    {
        List<UnityEngine.GameObject> Objs= new List<GameObject>();
 
        Transform[] allChildren = self.GetComponentsInChildren<Transform>();
foreach (Transform child in allChildren)
{
    Objs.Add(child.gameObject);

    }

      
        return Objs; 
    }
    
    public static T GetComponentInChildrenIfNotNull<T>( this UnityEngine.GameObject self )  
    {
        if ( self == null )
        {
            return default( T );
        }
        return self.GetComponentInChildren<T>(  );  
    }
    
    public static UnityEngine.Component GetComponentInParentIfNotNull( this UnityEngine.GameObject self, System.Type type ) 
    {
        if ( self == null )
        {
            return default( UnityEngine.Component );
        }
        return self.GetComponentInParent( type );   
    }
    
    public static T GetComponentInParentIfNotNull<T>( this UnityEngine.GameObject self )    
    {
        if ( self == null )
        {
            return default( T );
        }
        return self.GetComponentInParent<T>(  );    
    }
    
    public static UnityEngine.Component[] GetComponentsIfNotNull( this UnityEngine.GameObject self, System.Type type )  
    {
        if ( self == null )
        {
            return default( UnityEngine.Component[] );
        }
        return self.GetComponents( type );  
    }
    
    public static T[] GetComponentsIfNotNull<T>( this UnityEngine.GameObject self ) 
    {
        if ( self == null )
        {
            return default( T[] );
        }
        return self.GetComponents<T>(  );   
    }
    
    public static void GetComponentsIfNotNull( this UnityEngine.GameObject self, System.Type type, System.Collections.Generic.List<UnityEngine.Component> results ) 
    {
        if ( self == null )
        {
            return;
        }
        self.GetComponents( type, results );    
    }
    
    public static void GetComponentsIfNotNull<T>( this UnityEngine.GameObject self, System.Collections.Generic.List<T> results )    
    {
        if ( self == null )
        {
            return;
        }
        self.GetComponents<T>( results );   
    }
    
    public static UnityEngine.Component[] GetComponentsInChildrenIfNotNull( this UnityEngine.GameObject self, System.Type type )    
    {
        if ( self == null )
        {
            return default( UnityEngine.Component[] );
        }
        return self.GetComponentsInChildren( type );    
    }
    
    public static UnityEngine.Component[] GetComponentsInChildrenIfNotNull( this UnityEngine.GameObject self, System.Type type, System.Boolean includeInactive )    
    {
        if ( self == null )
        {
            return default( UnityEngine.Component[] );
        }
        return self.GetComponentsInChildren( type, includeInactive );   
    }
    
    public static T[] GetComponentsInChildrenIfNotNull<T>( this UnityEngine.GameObject self, System.Boolean includeInactive )   
    {
        if ( self == null )
        {
            return default( T[] );
        }
        return self.GetComponentsInChildren<T>( includeInactive );  
    }
    
    public static void GetComponentsInChildrenIfNotNull<T>( this UnityEngine.GameObject self, System.Boolean includeInactive, System.Collections.Generic.List<T> results )  
    {
        if ( self == null )
        {
            return;
        }
        self.GetComponentsInChildren<T>( includeInactive, results );    
    }
    
    public static T[] GetComponentsInChildrenIfNotNull<T>( this UnityEngine.GameObject self )   
    {
        if ( self == null )
        {
            return default( T[] );
        }
        return self.GetComponentsInChildren<T>(  ); 
    }
    
    public static void GetComponentsInChildrenIfNotNull<T>( this UnityEngine.GameObject self, System.Collections.Generic.List<T> results )  
    {
        if ( self == null )
        {
            return;
        }
        self.GetComponentsInChildren<T>( results ); 
    }
    
    public static UnityEngine.Component[] GetComponentsInParentIfNotNull( this UnityEngine.GameObject self, System.Type type )  
    {
        if ( self == null )
        {
            return default( UnityEngine.Component[] );
        }
        return self.GetComponentsInParent( type );  
    }
    
    public static UnityEngine.Component[] GetComponentsInParentIfNotNull( this UnityEngine.GameObject self, System.Type type, System.Boolean includeInactive )  
    {
        if ( self == null )
        {
            return default( UnityEngine.Component[] );
        }
        return self.GetComponentsInParent( type, includeInactive ); 
    }
    
    public static void GetComponentsInParentIfNotNull<T>( this UnityEngine.GameObject self, System.Boolean includeInactive, System.Collections.Generic.List<T> results )    
    {
        if ( self == null )
        {
            return;
        }
        self.GetComponentsInParent<T>( includeInactive, results );  
    }
    
    public static T[] GetComponentsInParentIfNotNull<T>( this UnityEngine.GameObject self, System.Boolean includeInactive ) 
    {
        if ( self == null )
        {
            return default( T[] );
        }
        return self.GetComponentsInParent<T>( includeInactive );    
    }
    
    public static T[] GetComponentsInParentIfNotNull<T>( this UnityEngine.GameObject self ) 
    {
        if ( self == null )
        {
            return default( T[] );
        }
        return self.GetComponentsInParent<T>(  );   
    }
    
    public static void SetActiveIfNotNull( this UnityEngine.GameObject self, System.Boolean value ) 
    {
        if ( self == null )
        {
            return;
        }
        self.SetActive( value );    
    }
    
    public static System.Boolean CompareTagIfNotNull( this UnityEngine.GameObject self, System.String tag ) 
    {
        if ( self == null )
        {
            return default( System.Boolean );
        }
        return self.CompareTag( tag );  
    }
    
    public static void SendMessageUpwardsIfNotNull( this UnityEngine.GameObject self, System.String methodName, System.Object value, UnityEngine.SendMessageOptions options )   
    {
        if ( self == null )
        {
            return;
        }
        self.SendMessageUpwards( methodName, value, options );  
    }
    
    public static void SendMessageUpwardsIfNotNull( this UnityEngine.GameObject self, System.String methodName, System.Object value )   
    {
        if ( self == null )
        {
            return;
        }
        self.SendMessageUpwards( methodName, value );   
    }
    
    public static void SendMessageUpwardsIfNotNull( this UnityEngine.GameObject self, System.String methodName )    
    {
        if ( self == null )
        {
            return;
        }
        self.SendMessageUpwards( methodName );  
    }
    
    public static void SendMessageUpwardsIfNotNull( this UnityEngine.GameObject self, System.String methodName, UnityEngine.SendMessageOptions options )    
    {
        if ( self == null )
        {
            return;
        }
        self.SendMessageUpwards( methodName, options ); 
    }
    
    public static void SendMessageIfNotNull( this UnityEngine.GameObject self, System.String methodName, System.Object value, UnityEngine.SendMessageOptions options )  
    {
        if ( self == null )
        {
            return;
        }
        self.SendMessage( methodName, value, options ); 
    }
    
    public static void SendMessageIfNotNull( this UnityEngine.GameObject self, System.String methodName, System.Object value )  
    {
        if ( self == null )
        {
            return;
        }
        self.SendMessage( methodName, value );  
    }
    
    public static void SendMessageIfNotNull( this UnityEngine.GameObject self, System.String methodName )   
    {
        if ( self == null )
        {
            return;
        }
        self.SendMessage( methodName ); 
    }
    
    public static void SendMessageIfNotNull( this UnityEngine.GameObject self, System.String methodName, UnityEngine.SendMessageOptions options )   
    {
        if ( self == null )
        {
            return;
        }
        self.SendMessage( methodName, options );    
    }
    
    public static void BroadcastMessageIfNotNull( this UnityEngine.GameObject self, System.String methodName, System.Object parameter, UnityEngine.SendMessageOptions options ) 
    {
        if ( self == null )
        {
            return;
        }
        self.BroadcastMessage( methodName, parameter, options );    
    }
    
    public static void BroadcastMessageIfNotNull( this UnityEngine.GameObject self, System.String methodName, System.Object parameter ) 
    {
        if ( self == null )
        {
            return;
        }
        self.BroadcastMessage( methodName, parameter ); 
    }
    
    public static void BroadcastMessageIfNotNull( this UnityEngine.GameObject self, System.String methodName )  
    {
        if ( self == null )
        {
            return;
        }
        self.BroadcastMessage( methodName );    
    }
    
    public static void BroadcastMessageIfNotNull( this UnityEngine.GameObject self, System.String methodName, UnityEngine.SendMessageOptions options )  
    {
        if ( self == null )
        {
            return;
        }
        self.BroadcastMessage( methodName, options );   
    }
  

    public static bool GetRatecheck( 
        this float self){
           return self>Random.value;
        }
  
    public static System.String ToStringIfNotNull( this UnityEngine.GameObject self )   
    {
        if ( self == null )
        {
            return default( System.String );
        }
        return self.ToString(  );   
    }
    
    public static System.Boolean EqualsIfNotNull( this UnityEngine.GameObject self, System.Object o )   
    {
        if ( self == null )
        {
            return default( System.Boolean );
        }
        return self.Equals( o );    
    }
    
    public static System.Int32 GetHashCodeIfNotNull( this UnityEngine.GameObject self ) 
    {
        if ( self == null )
        {
            return default( System.Int32 );
        }
        return self.GetHashCode(  );    
    }
    
    public static System.Int32 GetInstanceIDIfNotNull( this UnityEngine.GameObject self )   
    {
        if ( self == null )
        {
            return default( System.Int32 );
        }
        return self.GetInstanceID(  );  
    }
    
    public static System.Type GetTypeIfNotNull( this UnityEngine.GameObject self )  
    {
        if ( self == null )
        {
            return default( System.Type );
        }
        return self.GetType(  );    
    }
    
}