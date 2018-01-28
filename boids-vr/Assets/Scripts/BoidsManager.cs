using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using VRTK;

public class BoidsManager : MonoBehaviour {

	public static BoidsManager instance;

	public UnityEvent ResetEvent = null;
	public GameObject _agentPrefab;
	public Vector3 _instantiationFieldRange;
    private bool _isClicked = false;

	void Awake () {

		instance = this;


	}

    void Start()
    {
        // Subscribe to evemt controller events   

        VRTK.VRTK_SDKManager.instance.scriptAliasRightController.GetComponent<VRTK_ControllerEvents>().TriggerClicked += OnTriggerClicked;
        VRTK.VRTK_SDKManager.instance.scriptAliasRightController.GetComponent<VRTK_ControllerEvents>().TriggerUnclicked += OnTriggerUnclicked;

    }

    private void OnTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
    {
        _isClicked = false;
    }

    private void OnTriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        _isClicked = true;
        // AddAgent();
    }


    // Update is called once per frame
    void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {

			if (ResetEvent != null)
			{
				ResetEvent.Invoke ();
			}

		}

		if (Input.GetKeyDown (KeyCode.A)) {

			AddAgent ();

		}

        if(_isClicked)
        {
            AddAgent();
        }

	}

	void AddAgent() {

        Vector3 controllerPosition = VRTK.VRTK_SDKManager.instance.scriptAliasRightController.gameObject.transform.position;


        Vector3 whereToInstantiate = new Vector3 (
            controllerPosition.x + UnityEngine.Random.Range(-1*_instantiationFieldRange.x,_instantiationFieldRange.x),
            controllerPosition.y + UnityEngine.Random.Range(-1*_instantiationFieldRange.y,_instantiationFieldRange.y),
            controllerPosition.z + UnityEngine.Random.Range(-1*_instantiationFieldRange.z,_instantiationFieldRange.z)
		);

		Instantiate (_agentPrefab, whereToInstantiate, Quaternion.identity);

	}

}
