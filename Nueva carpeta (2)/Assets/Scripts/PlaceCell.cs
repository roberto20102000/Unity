using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceCell : MonoBehaviour
{
    public GameObject cellPrefab;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject placedCell;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        if (raycastManager.Raycast(
            touch.position,
            hits,
            TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (placedCell == null)
            {
                placedCell = Instantiate(
                    cellPrefab,
                    hitPose.position,
                    hitPose.rotation
                );
            }
            else
            {
                placedCell.transform.SetPositionAndRotation(
                    hitPose.position,
                    hitPose.rotation
                );
            }
        }
    }
}