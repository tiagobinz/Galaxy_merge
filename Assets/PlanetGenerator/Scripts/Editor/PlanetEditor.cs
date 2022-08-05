using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;
    Editor shapeEditor;
    Editor colorEditor;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawSettingsEditor
        (
            planet.GetShapeSettings(),
            planet.OnShapeSettingsUpdated,
            ref shapeEditor
        );
        DrawSettingsEditor
        (
            planet.GetColorSettings(),
            planet.OnColorSettingsUpdated,
            ref colorEditor
        );
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref Editor editor)
    {
        if (settings != null)
        {
            // To detect changes in the GUI
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                // Make a nice sub window for this settings object
                EditorGUILayout.InspectorTitlebar
                (
                    true,   // Always folded out
                    settings
                );

                // Creates a new Editor when necessary
                CreateCachedEditor
                (
                    settings,
                    null,   // Use default editor type
                    ref editor
                );

                editor.OnInspectorGUI();

                // If something changed
                if (check.changed)
                {
                    if (onSettingsUpdated != null)
                    {
                        // Call the system action that was passed
                        onSettingsUpdated();
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }
}
