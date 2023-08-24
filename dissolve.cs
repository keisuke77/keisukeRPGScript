using UnityEngine;

using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "dissolve", menuName = "")]
public class dissolve : ScriptableObject
{
    public Shader dissolveShader;
    public Shader flatShader;
    public Shader fixshader;
    public Color emissioncolor;
    public Color defaultemissioncolor;
    public Texture NoiseTexture;
    public Color _EdgeColor = Color.blue;
    public List<Renderer> meshRenderers;
    public float _EdgeWidth = 0.1f;

    public void dissolveIn(GameObject gameObject)
    {
        meshRenderers = gameObject.GetRender();
        dissolveIn(1);
    }

    public void dissolveOut(GameObject gameObject)
    {
        meshRenderers = gameObject.GetRender();
        dissolveOut(1);
    }

    public void dissolveIn()
    {
        dissolveIn(1);
    }

    public void dissolveIn(float time)
    {
        dissolveIn(time, null);
    }

    public void dissolveIn(Action action)
    {
        dissolveIn(1, action);
    }

    public void dissolveOut()
    {
        dissolveOut(1);
    }

    public void dissolveOut(float time)
    {
        dissolveOut(time, null);
    }

    public void dissolveOut(Action action)
    {
        dissolveOut(1, action);
    }

    public void dissolveIn(float time, Action action)
    {
        DOVirtual
            .Float(
                1f,
                0f,
                time,
                value =>
                {
                    rate(meshRenderers, value);
                }
            )
            .OnComplete(() =>
            {
                action();
            });
    }

    public void dissolveOut(float time, Action action)
    {
        DOVirtual
            .Float(
                0f,
                1f,
                time,
                value =>
                {
                    rate(meshRenderers, value);
                }
            )
            .OnComplete(() =>
            {
                action();
            });
    }

    public void dissolveInOut(float time, Action action)
    {
        dissolveIn(
            time,
            () =>
            {
                action();
                dissolveOut(time);
            }
        );
    }

    public void dissolveOutIn(float time, Action action)
    {
        dissolveOut(
            time,
            () =>
            {
                action();
                dissolveIn(time);
            }
        );
    }

    public void rate(List<Renderer> meshRenderers, float dissolverate)
    {
        foreach (Renderer item in meshRenderers)
        {
            if (item.materials != null)
            {
                Material[] matss = item.materials;
                foreach (var items in matss)
                {
                    if (items.shader != fixshader)
                    {
                        if (dissolveShader != null)
                        {
                            items.shader = dissolveShader;
                        }
                    }

                    items.SetTexture("_NoiseTex", NoiseTexture);
                    items.SetFloat("_EdgeWidth", _EdgeWidth);
                    items.SetColor("_EdgeColor", _EdgeColor);
                    items.SetFloat("_Cutoff", dissolverate);
                    items.SetFloat("_Dissolve", dissolverate);
                }

                item.materials = matss;
            }
        }
    }
}
