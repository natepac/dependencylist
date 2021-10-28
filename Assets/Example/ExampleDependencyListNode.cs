
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleDependencyListNode : AbstractDependencyListNode
{
	public string exampleSystemName;
	public float exampleAsyncWaitTime;

	public override void runListNode()
	{
		StartCoroutine(asyncExample());
	}

	IEnumerator asyncExample()
	{
		Debug.Log("System Running: " + exampleSystemName);

		yield return new WaitForSeconds(exampleAsyncWaitTime);

		listNodeComplete = true;
		listNodeRunning = false;

		Debug.Log("System COMPLETE: " + exampleSystemName);
	}
}
