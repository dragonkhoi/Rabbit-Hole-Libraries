using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RHL.Scripts.Interactable;

//this class is meant to be attached to a lineRenderer prefab
//and have the playerObject and arcOriginObject gameObjects specified
public class RHTeleportHandler : MonoBehaviour {

	//maximum number of arc segments that will be calculated
	const int maxSegments = 200;

	[SerializeField]
	public GameObject playerObject;
	//this gameobject is the one that will be teleported

	[SerializeField]
	public GameObject arcOriginObject;
	//this object is the one that will generate the teleportation arc

	[SerializeField]
	public float power = 4.5f;
	//this defines how far out the arc will go

	[SerializeField]
	public float playerHeight;
	//this offsets the teleport destination by a vertical amount

	void Update() {
		RaycastHit hit = fire();
		if (TriggerPulled) { //TODO: check the RHL TriggerPulled boolean
			playerObject.transform.position = hit.point + new Vector3(0f, playerHeight, 0f);
		}
	}

	//draws an arc based on the passed array of vectors
	private void drawArc(Vector3[] arc) {
		GetComponent<LineRenderer>().positionCount = arc.Length;
		GetComponent<LineRenderer>().SetPositions(arc);
		GetComponent<LineRenderer>().enabled = true;
	}

	//this function throws the gun in an arc, drawing the arc in the air,
	//and identifying the point at which it lands with a beacon
	public RaycastHit fire() {
		List<Vector3> arcSpots = new List<Vector3>();
		Vector3 pos = arcOriginObject.transform.position;
		Vector3 dir = transform.forward * power;

		arcSpots.Add(arcOriginObject.transform.position - transform.position);
		int segments = 1;
		RaycastHit hit;
		while (!getNextArcSegment(ref pos, ref dir, 5f, Physics.gravity, .1f, out hit)) {
			arcSpots.Add(new Vector3(pos.x, pos.y, pos.z) - transform.position);
			segments++;
			if (segments > maxSegments) {
				GetComponent<LineRenderer>().enabled = false;
				return new RaycastHit();
			}
		}
		arcSpots.Add(new Vector3(pos.x, pos.y, pos.z) - transform.position);

		drawArc(arcSpots.ToArray());

		return hit;
	}

	//helper function that increments the current arc position and velocity vectors by one segment
	//call repeatedly to create an entire arc
	private bool getNextArcSegment(ref Vector3 pos, ref Vector3 velocity, float vScale, Vector3 accel, float timeStep, out RaycastHit ray) {
		Vector3 newPos;
		RaycastHit hit;
		ray = new RaycastHit();

		//calculate new position
		newPos.x = (float)(pos.x + (velocity.x * timeStep) + (0.5 * accel.x * timeStep * timeStep));
		newPos.y = (float)(pos.y + (velocity.y * timeStep) + (0.5 * accel.y * timeStep * timeStep));
		newPos.z = (float)(pos.z + (velocity.z * timeStep) + (0.5 * accel.z * timeStep * timeStep));

		//raycast in that direction until an object is hit or we reach the new position
		Vector3 dir = newPos - pos;
		Physics.Raycast(pos, dir, out hit, dir.magnitude);


		if (hit.point != Vector3.zero) { //we've hit an object, this is the endpoint
			pos = hit.point;
			ray = hit;
			return true;
		} else {
			pos = newPos;
		}
		velocity.x = velocity.x + accel.x * timeStep;
		velocity.y = velocity.y + accel.y * timeStep;
		velocity.z = velocity.z + accel.z * timeStep;
		return false;
	}
}
