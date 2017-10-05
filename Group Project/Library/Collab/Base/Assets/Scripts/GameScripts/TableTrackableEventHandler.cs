/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

using Vuforia;
public class TableTrackableEventHandler : MonoBehaviour,
ITrackableEventHandler
{
	#region PRIVATE_MEMBER_VARIABLES

	private TrackableBehaviour mTrackableBehaviour;

	#endregion // PRIVATE_MEMBER_VARIABLES



	#region UNTIY_MONOBEHAVIOUR_METHODS

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	#endregion // UNTIY_MONOBEHAVIOUR_METHODS



	#region PUBLIC_METHODS

	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
	}

	#endregion // PUBLIC_METHODS



	#region PRIVATE_METHODS

	private void setBallKinematic(){

		GameObject rack = GameObject.Find ("Rack");
		if (rack) {
			rack.BroadcastMessage ("setKinematic");

		}

		GameObject cueBall = GameObject.Find ("Cue Ball");
		if (cueBall)
			cueBall.SendMessage ("setKinematic");


	}

	private void unsetBallKinematic(){

		GameObject rack = GameObject.Find ("Rack");
		if (rack) {

			rack.BroadcastMessage ("unsetKinematic");
		}
		GameObject cueBall = GameObject.Find ("Cue Ball");
		if (cueBall)
			cueBall.SendMessage ("unsetKinematic");

	}

	private void OnTrackingFound()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);



		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}

		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}
		unsetBallKinematic ();
		Debug.Log("2222Trackable " + mTrackableBehaviour.TrackableName + " found");
	}


	private void OnTrackingLost()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}

		// Disable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = false;
		}
		setBallKinematic ();
		Debug.Log("2222Trackable " + mTrackableBehaviour.TrackableName + " lost");
	}

	#endregion // PRIVATE_METHODS
}
