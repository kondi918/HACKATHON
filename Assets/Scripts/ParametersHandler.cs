using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersHandler : MonoBehaviour
{
    private static float defaultAtackSpeedScale = 1f;
    public static float atackSpeedScale = 1f;

    public static float GetDefaultAtackSpeedScale()
    {
        return defaultAtackSpeedScale;
    }

    public static void ResetAtackSpeedScale()
    {
        atackSpeedScale = defaultAtackSpeedScale;
    }
}
