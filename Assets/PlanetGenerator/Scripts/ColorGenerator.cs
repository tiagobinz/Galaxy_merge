﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator
{
    ColorSettings settings;
    [SerializeField]
    Texture2D texture;
    const int textureResolution = 50;

    public void UpdateSettings(ColorSettings colorSettings)
    {
        this.settings = colorSettings;
        if (!texture)
        {
            texture = new Texture2D(textureResolution, 1);
        }
    }

    public void UpdateElevation(MinMaxHelper elevationMinMax)
    {
        settings.planetMaterial.SetVector("_elevationMinMax", new Vector4(elevationMinMax.Min, elevationMinMax.Max, 0, 0));
    }

    public void UpdateColors()
    {
        Color[] colors = new Color[textureResolution];

        for (int i = 0; i < textureResolution; i++)
        {
            colors[i] = settings.gradient.Evaluate(i / (textureResolution - 1f));
        }
        texture.SetPixels(colors);
        texture.Apply();
        settings.planetMaterial.SetTexture("_texture", texture);
    }
}
