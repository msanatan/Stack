using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] ARRaycastManager raycastManager;
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

        if (Input.touchCount > 0)
        {
            var touchInput = Input.GetTouch(0);
            if (Input.touchCount > 0 && touchInput.phase == TouchPhase.Began)
            {
                var touches = new List<ARRaycastHit>();
                raycastManager.Raycast(touchInput.position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

                if (touches.Count > 0)
                {
                    // Set cube position
                    var cubePosition = touches[0].pose.position;
                    cubePosition.y += cube.transform.localScale.y / 2;

                    // Create cube
                    var createdCube = Instantiate<GameObject>(cube, cubePosition, touches[0].pose.rotation);

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
    }
}
