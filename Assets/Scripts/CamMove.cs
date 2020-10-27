using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    [SerializeField]
    private Camera cam;
    private Vector3 dragOrigin;
    private float targetZoom;
    private float zoomFactor = 3f;
    private float zoomLerpSpeed = 10;
   // public bool zoomStartActive = false;
   // public Vector3[] activeZoomTarget;
   // public float activeZoomSpd;
  //  public Transform camTransform;
   // public Transform camFocusTarget;
    //public FloorMaker fMaker;

    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main;
        //zoomStartActive = true;
        targetZoom = cam.orthographicSize;
        //camFocusTarget = fMaker.floorMaker.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //camTransform.position = camFocusTarget.position +new Vector3(0f,0f,-10f);
        PanCamera();
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom = targetZoom - scrollData * zoomFactor;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
        targetZoom = Mathf.Clamp(targetZoom, 4.5f, 20f);
    }
   /*private void LateUpdate()
    {
        if (zoomStartActive == true)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, activeZoomSpd);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, activeZoomSpd);
        }
    }*/

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }

    }
}
