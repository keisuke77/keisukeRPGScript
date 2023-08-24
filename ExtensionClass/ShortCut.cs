using UnityEngine;
using DG.Tweening;

public static class ShortCut
{
    public static Animator GetPlayerAnimator(this GameObject p)
    {
        return p.pclass().anim;
    }

    public static playerclass pclass(this GameObject obj)
    {
        return obj.root().GetComponentIfNotNull<playerclass>();
    }

    public static CharactorClass cclass(this GameObject obj)
    {
        return obj.root().GetComponentIfNotNull<CharactorClass>();
    }

    public static bool ptag(this Collision col)
    {
        return col.gameObject.CompareTag("Player");
    }

    public static bool proottag(this Collision col)
    {
        return col.gameObject.transform.root.gameObject.CompareTag("Player");
    }

    public static bool ptag(this Collider col)
    {
        return col.gameObject.CompareTag("Player");
    }

    public static bool ptag(this GameObject col)
    {
        return col.CompareTag("Player");
    }

    public static bool etag(this GameObject col)
    {
        return col.CompareTag("Enemy");
    }

    public static bool proottag(this Collider col)
    {
        return col.gameObject.proottag();
    }

    public static bool proottag(this GameObject col)
    {
        return col.root().ptag();
    }

    public static bool eroottag(this Collider col)
    {
        return col.gameObject.eroottag();
    }

    public static bool eroottag(this GameObject col)
    {
        return col.root().etag();
    }

    public static GameObject root(this GameObject obj)
    {
        if (obj.transform.root.gameObject != null)
        {
            return obj.transform.root.gameObject;
        }
        return obj;
    }

    public static GameObject root(this Collider obj)
    {
        return obj.gameObject.root();
    }

    public static data acessdata(this GameObject obj)
    {
        return obj.root().pclass().datamanage.data;
    }
}
