using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using System.Collections;
using System.Collections.Generic;

public class cameraFade : MonoBehaviour
{
    [System.Serializable]
    public class UIScreen
    {
        public Transform tra;
        public RawImage img;
        RenderTexture rt;
        GameObject camObj;

        public void NowScreenCreate()
        {
            tra = GameObjectExtension.NowCameraGet().gameObject.transform;
            Create();
        }

        public UIScreen(RawImage imgs, Transform tran = null)
        {
            img = imgs;
            tra = tran;
        }

        public void Create()
        {
            camObj = new GameObject("RenderCam");
            camObj.transform.position = tra.position;
            camObj.transform.rotation = tra.rotation;
            Camera cam = camObj.AddComponent(typeof(Camera)) as Camera;

            rt = new RenderTexture(1024, 1024, 16, RenderTextureFormat.ARGB32);
            rt.Create();
            cam.targetTexture = rt;
            img.enabled = true;
            img.texture = rt;
        }

        public void End()
        {
            img.enabled = false;
            Destroy(camObj);
            Destroy(rt);
        }
    }

    [System.Serializable]
    public class NowScreenDisoolveChange
    {
        UIScreen beforeScreen;
        UIScreen afterScreen;
        public Shader shader;
        public float DissloveSpeed = 1;
        public RawImage ScreenImg;
        public Texture ruletex;
		static readonly int propatyname = Shader.PropertyToID("_step");
	
        public void UIScreenSetUp(ref UIScreen UIScreens)
        {
            GameObject sc = ScreenImg.gameObject.Clone();
            UIScreens = new UIScreen(sc.GetComponent<RawImage>());
        }


        public void BeforeScreenSet(UIScreen UIScreens)
        {
            beforeScreen = UIScreens;
        }

        public UIScreen Play(Transform AfterScreenPoss)
        {
            if (beforeScreen == null)
            {
                UIScreenSetUp(ref beforeScreen);
                beforeScreen.NowScreenCreate();
            }

            UIScreenSetUp(ref afterScreen);
            afterScreen.tra = AfterScreenPoss;
            afterScreen.img.gameObject.transform.AddLocalPosZ(
                beforeScreen.img.gameObject.transform.localPosition.z + 0.1f
            );
            afterScreen.Create();

            Material mat = new Material(shader);

            beforeScreen.img.material = mat;
            mat.SetTexture("rule", ruletex);

            float num = 0;
            keikei.delaycall(()=> DOTween
                .To(
                    () => num, //何に
                    (x) => mat.SetFloat(propatyname, x), //何を
                    1, //どこまで(最終的な値)
                    DissloveSpeed //どれくらいの時間
                )
                .OnComplete(() =>
                {
                    beforeScreen.End();
                }),1f);
           
            return afterScreen;
        }
    }

    public NowScreenDisoolveChange NowScreenDisoolveChanges;

    public void Fade()
    {
        NowScreenDisoolveChanges.BeforeScreenSet(nowScreen);
        nowScreen = NowScreenDisoolveChanges.Play(AfterScreenPos);
    }

    UIScreen nowScreen;
    public Transform AfterScreenPos;

    [Button("Fade", "Fade")]
    public int butn;
}
