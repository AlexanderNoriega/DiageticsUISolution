using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickToOverlay : MonoBehaviour
    , IPointerClickHandler
{
    Canvas pdfCanvas;
    UnityEngine.UI.CanvasScaler c;
    Vector3 positionVectors, scaleVectors;

    // Start is called before the first frame update
    void Start()
    {
        pdfCanvas = GetComponent<Canvas>();
        positionVectors = pdfCanvas.transform.position;
        c = GetComponent<UnityEngine.UI.CanvasScaler>();
        scaleVectors = pdfCanvas.transform.localScale;

        //Determines of the canvas object was succesfully found
        if (pdfCanvas != null)
        {
            Debug.Log("Canvas Found!");
        }
        else
        {
            Debug.Log("Canvas Not Found!");
        }

    }

    //Determines the objects current renderMode and switches it to th eother
    void ChangeState(Canvas m_Canvas)
    {
        //Moves object from WorldSpace to Screenspace
        if (m_Canvas.renderMode == RenderMode.WorldSpace)
        {
            m_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            c.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
        }
        //If already in ScreenSpace, it returns it
        else
        {
            m_Canvas.renderMode = RenderMode.WorldSpace;
            m_Canvas.transform.position = positionVectors;
            m_Canvas.transform.localScale = scaleVectors;
        }
    }

    //Activate the on-Click event
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Canvas clicked!");
        ChangeState(pdfCanvas);
    }
}