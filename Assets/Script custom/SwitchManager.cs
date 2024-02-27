using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SwitchController> switches;

    void Start()
    {
        // Sort switches based on their names (from A to Z)
        switches.Sort((a, b) => a.name.CompareTo(b.name));

    }

    public void ForceOff(SwitchController activatedSwitch)
    {
        foreach (SwitchController switchCtrl in switches)
        {
            if (switchCtrl != activatedSwitch && switchCtrl.state == SwitchController.SwitchState.On)
            {
                switchCtrl.ForceOff(); // Turn off the switch
            }
        }
    }


}
