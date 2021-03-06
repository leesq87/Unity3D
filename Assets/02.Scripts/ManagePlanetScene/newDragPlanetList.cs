﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class newDragPlanetList : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    float deltaX;

    static bool moving = false;

    csPlanetPanalSet script;


    void Start()
    {
        deltaX = 0;
        script = GameObject.Find("Manager/UIManager").GetComponent<csPlanetPanalSet>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        GameObject.Find("Manager").GetComponent<ManagePlanetRay>().enabled = false;

        SoundManager.Instance().PlaySfx(SoundManager.Instance().dragPlanet);
    }


    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        deltaX = eventData.delta.y;

        Debug.Log("out Moving"+moving);
        //if (Mathf.Abs(deltaX) < 10) return;
        if (!moving)
        {
            Debug.Log("if moving = false : active");
            StartCoroutine(dragFlase());

            if (deltaX > 0)
            {
                Debug.Log("deltaX > 0");
                //csPlanetPanalSet.nowPlanetNum++;
                //if(csPlanetPanalSet.nowPlanetNum > csPlanetPanalSet.PlanetCount)
                //{
                //    csPlanetPanalSet.nowPlanetNum = 1;
                //}

                MovePlanet.Instance.insertDrag();
                MovePlanet.Instance.moveUp();
            }
            else if (deltaX < 0)
            {
                Debug.Log("deltaX < 0");
                //csPlanetPanalSet.nowPlanetNum--;
                //if(csPlanetPanalSet.nowPlanetNum <= 0)
                //{
                //    csPlanetPanalSet.nowPlanetNum = csPlanetPanalSet.PlanetCount;
                //}

                MovePlanet.Instance.insertDrag();
                MovePlanet.Instance.moveDown();

            }

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject.Find("Manager").GetComponent<ManagePlanetRay>().enabled = true;

    }

    IEnumerator dragFlase()
    {
        moving = true;
        Debug.Log("corutine before yield" + moving);
        //script.setPanalNotVisible();
        yield return new WaitForSeconds(0.4f);
        //script.setPanalVisible();
        //script.ChangeText();
        moving = false;
        Debug.Log("corutine after yield" + moving);
    }
}
