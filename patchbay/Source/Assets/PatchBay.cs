using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;

[Serializable]
public class PatchData
{
    public List<int> A;
    public List<int> B;
}

public class PatchBay : MonoBehaviour
{
    public Material highlight = null;
    private Material matprevious = null;

    Ray ray = new Ray();
    RaycastHit hit = new RaycastHit();
    Transform lines = null;
    Transform sighted = null;
    PatchData patch = new PatchData();

    public static int GetCUID(Transform t)
    {
        if (t == null) { return 0; }
        string name = t.name;
        int pos = name.LastIndexOf("#");
        int CUID = 0;
        if (pos > -1) { int.TryParse(name.Substring(pos + 1), out CUID); }
        return CUID;
    }

    //!!!BUG: Signed Overflow Exception: 128-bits required to hold signed 64-bit two's complement integer
    //!!!                                16-bits used instead to make it fit in a 32-bit signed integer
    public static int GenerateRandomCUID(int power = 32)
    {
        return Mathf.RoundToInt(Mathf.Abs(UnityEngine.Random.Range(1.0f, Mathf.Pow(2.0f, power / 2.0f) - 2.0f)));
    }

    public static Transform GetTransformByCUID(int CUID)
    {
        //foreach (Transform t in Resources.FindObjectsOfTypeAll(typeof(Transform))) //!!!BUG: Resources missing in WebGL
        foreach (Transform t in UnityEngine.Object.FindObjectsOfType(typeof(Transform)))
        {
            if (GetCUID(t) == CUID) { return t; }
        }
        return null;
    }

#if UNITY_EDITOR
    [MenuItem("GameObject/Generate CUID")]
    public static void GenerateCUID(MenuCommand menuCommand)
    {
        if (menuCommand.context != Selection.activeObject) { return; }

        foreach (Transform t in Selection.transforms)
        {
            Undo.RegisterCompleteObjectUndo(t.gameObject, //!!!BUG: Undo is stubborn and doesn't accept transforms
                "CUID for " + Selection.transforms.Length.ToString() + " Objects");
        }

        int count = 0;
        int collisions = 0;
        foreach (Transform t in Selection.transforms)
        {
            if (GetCUID(t) == 0)
            {
                int CUID = GenerateRandomCUID();
                while (GetTransformByCUID(CUID) != null)
                {
                    CUID = GenerateRandomCUID();
                    collisions += 1;
                }
                if (!t.name.EndsWith("#")) { t.name += "#"; }
                t.name += CUID.ToString();
                count += 1;
            }
        }

        Debug.Log("Generated " + count.ToString() + " CUID's with " + collisions.ToString() + " Collisions");
    }
#endif

    [DllImport("__Internal")] //See Plugins Folder
    private static extern void GetSightedYield(int cuid);
    public void GetSighted() { GetSightedYield(GetCUID(sighted)); }

    //!!!BUG: Can't clear using transform, must use GameObject of transform
    void ClearLines() { foreach (Transform t in lines) { GameObject.DestroyImmediate(t.gameObject); } }
    void DrawLine(Vector3 a, Vector3 b, Color c, float d)
    {
        GameObject line = new GameObject();
        line.name = "Line";
        line.transform.parent = lines;
        line.transform.position = a;
        line.AddComponent<LineRenderer>();
        LineRenderer liner = line.GetComponent<LineRenderer>();
        //Shader shader = Shader.Find("Particles/Alpha Blended Premultiply"); //!!!BUG: Deprecation Police
        //if (shader == null) { shader = Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"); }
        //if (shader == null) { shader = Shader.Find("Standard"); }
        liner.material = highlight;
        liner.SetPosition(0, a);
        liner.SetPosition(1, b);
        liner.startColor = liner.endColor = c;
        liner.startWidth = liner.endWidth = d;
    }

    public void SetPatch(string json)
    {
        ClearLines();
        patch = JsonUtility.FromJson<PatchData>(json);
        for (int i = 0; i < patch.A.Count; ++i)
        {
            try
            {
                DrawLine(GetTransformByCUID(patch.A[i]).position,
                         GetTransformByCUID(patch.B[i]).position,
                         new Color(1.0f, 0.0f, 0.25f), 1.0f);
            } catch { Debug.Log("Link Error"); }
        }
    }

    void Start()
    {
        lines = transform.Find("/Lines");
        SetPatch("{\"A\": [63260], \"B\": [33905]}");
    }

    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        if (Physics.Raycast(ray, out hit))
        {
            if (sighted) { sighted.gameObject.GetComponent<Renderer>().material = matprevious; }
            sighted = hit.collider.transform;
            matprevious = sighted.gameObject.GetComponent<Renderer>().material;
            sighted.gameObject.GetComponent<Renderer>().material = highlight;
        }
        else
        {
            if (sighted) { sighted.gameObject.GetComponent<Renderer>().material = matprevious; }
            sighted = null;
        }
    }
}
