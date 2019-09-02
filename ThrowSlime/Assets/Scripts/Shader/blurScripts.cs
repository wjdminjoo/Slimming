using System.Collections;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/RadialBlurFilter")]
public class blurScripts : ImageEffectBase
{

    public float SampleDist = 1f;
    public float SampleStrength = 2.2f;
 
    override protected void Start()
    {
        base.Start();
        this.shader = Shader.Find("Image Effects/RadialBlurFilter");
    }
 
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        this.material.SetTexture("_MainTex", source);
        this.material.SetFloat("_SampleDist", SampleDist);
        this.material.SetFloat("_SampleStrength", SampleStrength);
 
        Graphics.Blit(null, destination, this.material);
    }


}
