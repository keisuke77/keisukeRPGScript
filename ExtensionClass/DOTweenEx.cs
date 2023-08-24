 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using DG.Tweening;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public static class DOTweenEx
{
     public static Tweener FadeOut(this CanvasGroup canvasGroup, float duration)
        {
            return canvasGroup.DOFade(0.0F, duration);
        }

        public static Tweener FadeIn(this CanvasGroup canvasGroup, float duration)
        {
            return canvasGroup.DOFade(1.0F, duration);
        }
    public static Sequence CanvasTween(this CanvasGroup ResultCanvasGroup,ParticleSystem Particle)
    {
          Sequence sequence = DOTween.Sequence()
            .OnStart(() =>
            {
                ResultCanvasGroup.alpha = 0.0f;
                ResultCanvasGroup.transform.localScale = Vector3.one * 3.0f;
            })
            .Append(ResultCanvasGroup.DOFade(1.0f, 2.0f).SetEase(Ease.OutCubic))
            .Join(ResultCanvasGroup.transform.DOScale(1.0f, 2.0f).SetEase(Ease.OutBounce))
            .InsertCallback(0.7f, () => Particle.Play()); // 再生0.7秒後に実行
return sequence;

    }


  public static Sequence ImageTween(this Image StarImage)
    {
       

    Sequence fadeInSequence = DOTween.Sequence()
            .Append(StarImage.DOFade(1.0f, 1.0f))
            .Join(StarImage.transform.DOScale(1.0f, 1.0f))
            .Join(StarImage.rectTransform.DORotate(new Vector3(0.0f, 0.0f, 360.0f), 1.0f, RotateMode.FastBeyond360));

        Sequence fadeOutSequence = DOTween.Sequence()
            .Append(StarImage.DOFade(0.0f, 1.0f))
            .Join(StarImage.rectTransform.DORotate(new Vector3(0.0f, 0.0f, -360.0f), 1.0f, RotateMode.FastBeyond360))
            .Join(StarImage.transform.DOScale(3.0f, 1.0f));

        Sequence sequence = DOTween.Sequence()
            .OnStart(() =>
            {
                StarImage.transform.localScale = Vector3.one * 3.0f;
                StarImage.color = new Color(
                    StarImage.color.r,
                    StarImage.color.g,
                    StarImage.color.b,
                    0.0f
                );
            })
            .Append(fadeInSequence)
            .AppendInterval(2.0f) // 2秒待機
            .Append(fadeOutSequence);
return sequence;

    }

}