using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // A cube has 6 faces
    const int NumberOfFaces = 6;

    [Range(2, 256), SerializeField]
    int resolution = 10;

    [SerializeField]
    ShapeSettings shapeSettings = null;
    [SerializeField]
    ColorSettings colorSettings = null;

    ShapeGenerator shapeGenerator = new ShapeGenerator();
    ColorGenerator colorGenerator = new ColorGenerator();

    // They are serialized in order to be saved in the inspector
    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;

    // This function is called when the script is loaded or a value
    // is changed in the Inspector (Called in the editor only).
    private void OnValidate()
    {
        GeneratePlanet();
    }

    void Awake()
    {
        GeneratePlanet();
    }

    void Initialize()
    {
        if (!shapeSettings || !colorSettings)
            return;

        shapeGenerator.UpdateSettings(shapeSettings);
        colorGenerator.UpdateSettings(colorSettings);

        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[NumberOfFaces];
        }
        
        terrainFaces = new TerrainFace[NumberOfFaces];

        // The 6 directions of the cube faces
        Vector3[] directions =
        {
            Vector3.up,
            Vector3.down,
            Vector3.left,
            Vector3.right,
            Vector3.forward,
            Vector3.back
        };

        for (int i = 0; i < meshFilters.Length; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("face" + i);
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colorSettings.planetMaterial;

            terrainFaces[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    public void GeneratePlanet()
    {
        Initialize();
        GenerateMesh();
        GenerateColors();
    }

    public void OnShapeSettingsUpdated()
    {
        Initialize();
        GenerateMesh();
    }

    public void OnColorSettingsUpdated()
    {
        Initialize();
        GenerateColors();
    }

    void GenerateMesh()
    {
        foreach(TerrainFace terrainFace in terrainFaces)
        {
            terrainFace.ConstructMesh();
        }

        colorGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
    }

    void GenerateColors()
    {
        colorGenerator.UpdateColors();
    }

    public ShapeSettings GetShapeSettings()
    {
        return shapeSettings;
    }

    public ColorSettings GetColorSettings()
    {
        return colorSettings;
    }
}
