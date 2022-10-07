using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] PlacementIndicator placementIndicator;
    [SerializeField] Color defaultColour;
    [SerializeField] Color alternateColour;
    bool useDefaultColour = true;

    void Update()
    {
        // Quit when we press back on phone
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Create cube
            var createdCube = Instantiate<GameObject>(cube, placementIndicator.transform.position, placementIndicator.transform.rotation);

            // Set cube colour
            if (useDefaultColour)
            {
                createdCube.GetComponent<MeshRenderer>().material.color = defaultColour;
            }
            else
            {
                createdCube.GetComponent<MeshRenderer>().material.color = alternateColour;
            }
            useDefaultColour = !useDefaultColour;
        }
    }
}
