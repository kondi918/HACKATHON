using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillUpgrade : MonoBehaviour, IPointerClickHandler
{
    public bool isClicked = false;
    public bool isActive = false;
    public void OnPointerClick(PointerEventData eventData)
    {

        if (isActive)
        {
            isClicked = true;
        }

    }
}
