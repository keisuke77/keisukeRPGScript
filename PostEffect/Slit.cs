using UnityEngine;

public class Slit : CustomImageEffect
{
   #region Fields

    [SerializeField]
    [Range(1, 100)]
    private float m_Size;

    [SerializeField]
    [Range(0, 1)]
    private float m_Time;

   #endregion

   #region Properties

    public override string ShaderName
    {
        get { return "Custom/Slit"; }
    }

   #endregion

   #region Methods

    protected override void UpdateMaterial()
    {
        Material.SetFloat("_Size", m_Size);
        Material.SetFloat("_AnimTime", m_Time);
    }

   #endregion

}