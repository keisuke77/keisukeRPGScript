using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startmenu : MonoBehaviour
{
    public Button returnbutton;

    [System.Serializable]
    public class resetanim
    {
        public Animator animator;
        public string animname;
    }

    public resetanim[] resetanims;
    public Button[] menubutton;

    [System.Serializable]
    public class _startmenu
    {
        public GameObject[] objs;
        public Transform cameraposition;
    }

    public _startmenu startmenus;

    [System.Serializable]
    public class menu
    {
        public Image[] subimage;
        public Text subtitle;
        public Transform cameraposition;
        public anim[] anims;
        public GameObject[] decideobj;

        [System.Serializable]
        public class anim
        {
            public Animator animator;
            public string animname;
        }
    }

    public menu[] menus;
    public SmoothMove SmoothMove;
    public int i;
    public timelinemanager timelinemanager;

    // Start is called before the first frame update

    void Start()
    {
        SmoothMove.execute(startmenus.cameraposition);
        hidemenubutton();

        timelinemanager.EventPlay(1);
        reset();
    }

    public void hidemenubutton()
    {
        foreach (var f in menubutton)
        {
            f.gameObject.SetActive(false);
        }
    }

    public void appermenubutton()
    {
        foreach (var f in menubutton)
        {
            f.gameObject.SetActive(true);
        }
    }

    public void decidetransition(int num)
    {
        reset();
        returnbutton.gameObject.SetActive(true);
        foreach (var xx in menus[num].decideobj)
        {
            xx.SetActive(true);
        }
    }

    public void gamestart()
    {
        menutransition();
        foreach (var f in menubutton)
        {
            f.gameObject.SetActive(true);
        }
        foreach (GameObject item in startmenus.objs)
        {
            item.SetActive(false);
        }
    }

    public void reset()
    {
        foreach (var a in menus)
        {
            foreach (var xxx in a.decideobj)
            {
                xxx.SetActive(false);
            }
            foreach (var b in a.subimage)
            {
                b.gameObject.SetActive(false);
            }
            foreach (var x in a.decideobj)
            {
                x.SetActive(false);
            }

            if (a.subtitle != null)
            {
                a.subtitle.gameObject.SetActive(false);
            }
        }

        foreach (var e in resetanims)
        {
            e.animator.Play(e.animname, 0);
        }
    }

    public void menutransition()
    {
        reset();

        returnbutton.gameObject.SetActive(false);
        foreach (var c in menus[i].subimage)
        {
            c.gameObject.SetActive(true);
        }

        if (menus[i].subtitle != null)
        {
            menus[i].subtitle.gameObject.SetActive(true);
        }
        SmoothMove.execute(menus[i].cameraposition);

        foreach (var d in menus[i].anims)
        {
            d.animator.Play(d.animname, 0);
        }
    }

    public void menuback()
    {
        i++;
        loop();
        menutransition();
    }

    public void menuforward()
    {
        i--;
        loop();
        menutransition();
    }

    void loop()
    {
        if (i == menus.Length)
        {
            i = 0;
        }
        if (i < 0)
        {
            i = menus.Length - 1;
        }
    }

    public void menudecide()
    {
        hidemenubutton();
        if (i == 1)
        {
            adventurestart();
            return;
        }

        decidetransition(i);
    }

    public void menureturn()
    {
        appermenubutton();
        menutransition();
    }

    public void adventurestart()
    {
        timelinemanager.EventPlay(2);
    }

    // Update is called once per frame
    void Update() { }
}
