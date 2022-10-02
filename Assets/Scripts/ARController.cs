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
        if (Input.touchCount > 0)
        {
            var touchInput = Input.GetTouch(0);
            if (Input.touchCount > 0 && touchInput.phase == TouchPhase.Began)
            {
                var touches = new List<ARRaycastHit>();
                raycastManager.Raycast(touchInput.position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

                if (touches.Count > 0)
                {
                    Instantiate(cube, touches[0].pose.position, touches[0].pose.rotation);
                }
            }
        }
    }
}
