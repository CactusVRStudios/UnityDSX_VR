/* 2024 - Cactus VR Studios
 * 
 * DSX Version 3.1+ needs to be running!
 * 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSVR2TriggerExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.Normal); // Resets the Right Controller to normal
        PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Left, Shared.TriggerMode.Normal); // Resets the Left Controller to normal
    }

    [ContextMenu("Set Rigid")]
    void SetToRigid()
    {
        PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.Rigid); // Set the Right Controller to Rigid being all spongy 
        PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Left, Shared.TriggerMode.Rigid); // Sets the Left Controller to Rigid being all spongy 
    }
    [ContextMenu("Set Vibrate")]
    void SetToVibrate()
    {
        PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.Rigid); // Resets the Right Controller to normal
        PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Left, Shared.TriggerMode.Rigid); // Resets the Left Controller to normal
    }


    private void OnDestroy()
    {
        PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Right, Shared.TriggerMode.Normal); // Resets the Right Controller to normal
        PSVR2TriggerController.Instance.SetTriggerState(Shared.Trigger.Left, Shared.TriggerMode.Normal); // Resets the Left Controller to normal
    }
}
