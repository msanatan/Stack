using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] ARRaycastManager raycastManager;

    // Update is called once per frame
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
                    var cubePosition = touches[0].pose.position;
                    cubePosition.y += cube.transform.localScale.y / 2;
                    Instantiate(cube, cubePosition, touches[0].pose.rotation);
                }
            }
        }
    }
}
