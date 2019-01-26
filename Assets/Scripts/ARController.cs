using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

#if UNITY_EDITOR
using input = GoogleARCore.InstantPreviewInput;
#endif

public class ARController : MonoBehaviour
{
	// We will fill this list with the planes that ARCore detected in the current frame
	private List<TrackedPlane> m_NewTrackedPlanes = new List<TrackedPlane>();

	public GameObject GridPrefab;
	public GameObject Portal;
	public GameObject ARCamera;

	// Start is called before the first frame update
	void Start()
	{
        
	}

	// Update is called once per frame
	void Update()
	{
		return;	// remove this

        	// Check ARCore system status
		if (Session.Status != SessionStatus.Tracking) return;

		// The following function will fill m_NewTrackedPlanes wth the planes that ARCore detected in the current frame
		Session.GetTrackables<TrackedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

		// Instantiate a Grid fo eah TrackedPlane in m_NewTrackedPlanes
		for (int i = 0; i < m_NewTrackedPlanes.Count; i++)
		{
			GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);

			// Set the position of grid and modify the vertices of the attached mesh
			grid.GetComponent<GridVisualizer>().Initialize(m_NewTrackedPlanes[i]);

		}

		// Check if user touches screen
		Touch touch;
		if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
			return;

		// check if user touched a tracked plane
		TrackableHit hit;
		if (Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
		{
			/* place portal on top of tracked plane that was touched */
			// Enable the portal
			Portal.SetActive(true);

			// Create a new Anchor
			Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

			// set the position of the portal to be the same as the hit position
			Portal.transform.position = hit.Pose.position;
			Portal.transform.rotation = hit.Pose.rotation;

			// want portal to face camera
			Vector3 cameraPosition = ARCamera.transform.position;

			// portal should only rotate around y axis
			// locking camera and portal together
			cameraPosition.y = hit.Pose.position.y;

			// rotate portal to face camera
			Portal.transform.LookAt(cameraPosition, Portal.transform.up);

			// ARCore will keep understanding the world and update the anchors accordingly hence we need to attack our portal to the anchor
			Portal.transform.parent = anchor.transform;
		}
	}
}
