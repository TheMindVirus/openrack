using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRack : MonoBehaviour
{
    public void SetTexture(string data)
    {
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(System.Convert.FromBase64String(data));
        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", tex);
        GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", tex);
    }
}
