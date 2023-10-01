using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersHandler : MonoBehaviour
{
    public static float atackSpeedScale = 1f;

    public static void ResetAtackSpeedScale()
    {
        atackSpeedScale = 1;
    }
}
