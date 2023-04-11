using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject Toggle;
    public TurretData Laser;
    public TurretData Missile;
    public TurretData Standard;
    public TurretData selectedTurret;
    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurret = Laser;
            //Toggle.GetComponentsInChildren<bool>(isOn);
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
            selectedTurret = Missile;
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
            selectedTurret = Standard;
    }
}
