using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;

// if you want to interact with anything using MRTK like grabbing an obejct
// it needs to have a NearInteractionGrabbable
// it's like the landing point for gameobjects in scene that you want to grab.
// you add it to any gameobject that has a collider to make it grabbable.

// the ObjectManipulator allows a gameobject to be movable, scalable and rotateable with 
// either one or two hands

public class SpawnBall : MonoBehaviour, IMixedRealityGestureHandler<Vector3>
{
    public GameObject ballPrefab;
    public Transform tableTransform;
    public Text text;

    public void OnGestureCanceled(InputEventData eventData)
    {
        Debug.Log($"OnGestureCanceled [{Time.frameCount}]: {eventData.MixedRealityInputAction.Description}");

        var action = eventData.MixedRealityInputAction.Description;

        if (action == "Hold Action")
        {
            SetText("Hold: canceled");
        }
        else if (action == "Manipulate Action")
        {
            SetText("Manipulation: canceled");
        }
        else if (action == "Navigation Action")
        {
            SetText("Navigation: canceled");
        }
    }

    public void OnGestureCompleted(InputEventData<Vector3> eventData)
    {
        Debug.Log($"OnGestureUpdated [{Time.frameCount}]: {eventData.MixedRealityInputAction.Description}");

        var action = eventData.MixedRealityInputAction.Description;
        if (action == "Manipulate Action")
        {
            SetText($"Manipulation: completed {eventData.InputData}");
        }
        else if (action == "Navigation Action")
        {
            SetText($"Navigation: completed {eventData.InputData}");
        }
    }

    public void OnGestureCompleted(InputEventData eventData)
    {
        var action = eventData.MixedRealityInputAction.Description;

        if (action == "Hold Action")
        {
            SetText($"Hold: completed");
        }
    }

    public void OnGestureStarted(InputEventData eventData)
    {
        var action = eventData.MixedRealityInputAction.Description;

        if (action == "Hold Action")
        {
            SetText($"Hold: started");

            GameObject ball = Instantiate(ballPrefab);
        }
        else if (action == "Manipulate Action")
        {
            SetText($"Manipulation: started");
        }
        else if (action == "Navigation Action")
        {
            SetText($"Navigation: started");
        }
    }

    public void OnGestureUpdated(InputEventData<Vector3> eventData)
    {
        Debug.Log($"OnGestureUpdated [{Time.frameCount}]: {eventData.MixedRealityInputAction.Description}");

        var action = eventData.MixedRealityInputAction.Description;
        if (action == "Manipulate Action")
        {
            SetText($"Manipulation: updated {eventData.InputData}");
        }
        else if (action == "Navigation Action")
        {
            SetText($"Navigation: updated {eventData.InputData}");
        }
    }

    public void OnGestureUpdated(InputEventData eventData)
    {
        var action = eventData.MixedRealityInputAction.Description;

        if (action == "Hold Action")
        {
            SetText($"Hold: updated");
        }
    }

    public void SetText(string gestureType)
    {
        text.text = gestureType;
    }

    public void SpawnBallPrefab()
    {
        Vector3 position = new Vector3(tableTransform.position.x, tableTransform.position.y + 0.25f, tableTransform.position.z);
        GameObject spawnedBall = Instantiate(ballPrefab, position, this.transform.rotation);
    }
}
