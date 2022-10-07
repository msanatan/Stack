using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    ARRaycastManager raycastManager;
    GameObject plane;
    Vector2 screenDimensions;

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        plane = transform.GetChild(0).gameObject; // Gets the plane object
        plane.SetActive(false); // Off by default
        screenDimensions = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {
        // Shoot raycast from centre of screen
        var hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenDimensions, hits, TrackableType.Planes);

        // If we hit AR plan, update position and rotation of marker
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!plane.activeInHierarchy)
            {
                plane.SetActive(true);
            }
        }
    }
}
