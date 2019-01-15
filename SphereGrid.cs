using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGrid : MonoBehaviour {

    public GameObject relo;
    public GameObject cube;
	public GameObject[] spheres;
    public float cubeSize = 1f;
    public float sphereSize = 0.25f;

    float lastCubeSize;
	float lastSphereSize;

	void Awake() {
		lastCubeSize = cubeSize;
		lastSphereSize = sphereSize;
	}

   
    void Update () {

		// Scales cube and leaves spheres at constant size
		if (cubeSize > 0 && cubeSize != lastCubeSize) {
			scaleCube (cubeSize);
		}
		// Scales spheres
		if (sphereSize > 0 && sphereSize != lastSphereSize) {
			scaleSphere (sphereSize);
		}
        
	}


    void scaleCube(float cubeSize) {			

		float scale = transform.localScale.x / cubeSize;
		float origSphereSize = spheres [0].transform.localScale.x;

		transform.localScale = new Vector3 (cubeSize, cubeSize, cubeSize);
		foreach (GameObject sphere in spheres) {
			sphere.transform.localScale = new Vector3 (origSphereSize * scale, origSphereSize * scale, origSphereSize * scale);
		}
		lastCubeSize = cubeSize;
	}

	void scaleSphere(float sphereSize) {
		
		foreach (GameObject sphere in spheres) {
			sphere.transform.localScale = new Vector3 (sphereSize, sphereSize, sphereSize);
		}
		lastSphereSize = sphereSize;		
	}

    public void Relocate()
    {
        transform.position = relo.transform.position;
        transform.rotation = relo.transform.rotation;
    }
}
