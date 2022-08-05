using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    [System.Serializable]
    public class NoiseLayer
    {
        public bool enabled = true;
        public bool useFirstLayerAsMask = true;
        public NoiseSettings noiseSettings;
    }

    public float planetRadius = 1;
    public NoiseLayer[] noiseLayers;
}
