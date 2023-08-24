using UnityEngine;

using System;

using System.Collections.Generic;
using System.Linq;

namespace osero
{
    [System.Serializable]
    public class board
    {
        public GameObject komaobj;
       
        public koma[,] komas;

        [Range(4, 25)]
        public int boardsize = 8;

        public int whitecount;
        public int blackcount;
public int empty;
        public board Clone()
        {
            return MemberwiseClone() as board;
        }

        public void KomaDestroy()
        {
            if (komas != null)
            {
                foreach (var item in komas)
                {
                    keikei.destroy(item?.komaobj);
                }
            }
        }

        public void Counter()
        {
            whitecount = 0;
            blackcount = 0;
            empty=0;
            foreach (koma item in komas)
            {
                switch (item.komatype)
                {
                    case komatype.black:
                        blackcount++;
                        break;
                    case komatype.white:
                        whitecount++;
                        break;  case komatype.none:
                        empty++;
                        break;
                }
            }
        }

        int n;

        public int RestSpaceCount()
        {
            n = 0;
            foreach (koma item in komas)
            {
                if (item.komatype == komatype.none)
                {
                    n++;
                }
            }
            return n;
        }

        public void Reset()
        {komas=null;
            komas = new koma[boardsize, boardsize];
            Reload();
        }

public void render(){

    foreach (var item in komas)
    {
        item.ReChange();
    }
  

}
        public void Reload()
        {
            var boards = Clone();
            KomaDestroy(); 
            komas = new koma[boardsize, boardsize];
            var scale = komaobj.transform.localScale.x;
            for (var x = 0; x < boardsize; x++)
            {
                for (var y = 0; y < boardsize; y++)
                {
                    komas[x, y] = new koma(komaobj, new Vector2(x, y));

                  
                }
            }
            render();
            Counter();
        }

        public koma GetKoma(GameObject obj)
        {
            foreach (koma item in komas)
            {
                if (item.komaobj == obj)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
