using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMagicController : MonoBehaviour {
    
	public GameObject firePoint;
	public GameObject cameras;
	public List<GameObject> VFXs = new List<GameObject> ();
    
	private GameObject effectToSpawn;

	void Start () {

		if(VFXs.Count>0)
			effectToSpawn = VFXs[0];
    }

	public void SpawnMagic (GameObject player) {
		GameObject vfx;
		if (firePoint != null) {
			vfx = Instantiate (effectToSpawn, firePoint.transform.position, Quaternion.identity);
        }
        else
			vfx = Instantiate (effectToSpawn);

		var ps = vfx.GetComponent<ParticleSystem> ();

		if (vfx.transform.childCount > 0) {
			ps = vfx.transform.GetChild (0).GetComponent<ParticleSystem> ();
		}
	}
}
