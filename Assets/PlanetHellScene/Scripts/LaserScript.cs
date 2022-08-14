using UnityEngine;

public class LaserScript : MonoBehaviour 
{
    [SerializeField]
	private WeaponData weaponData;

	private void Start () => GetComponentInChildren<LineRenderer>().SetPosition(1, Vector3.forward * weaponData.Range);
}
