using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class TableStuff : MonoBehaviour, IMixedRealityGestureHandler<Vector3>
{
    public GameObject ballPrefab;

    public void SpawnBallThing()
    {
        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z);

        GameObject spawnedBall = Instantiate(ballPrefab, position, this.transform.rotation);
    }

    public void OnGestureCanceled(InputEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnGestureCompleted(InputEventData<Vector3> eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnGestureCompleted(InputEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnGestureStarted(InputEventData eventData)
    {
        Debug.Log($"OnGestureStarted [{Time.frameCount}]: {eventData.MixedRealityInputAction.Description}");

        var gesture = eventData.MixedRealityInputAction.Description;
        if (gesture == "Manipulation Action")
        {
            GameObject spawnedBall = Instantiate(ballPrefab);
        }
    }

    public void OnGestureUpdated(InputEventData<Vector3> eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnGestureUpdated(InputEventData eventData)
    {
        throw new System.NotImplementedException();
    }


}
