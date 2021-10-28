using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDependencyListManager : MonoBehaviour
{

	public delegate void OnAllNodesComplete();
	public event OnAllNodesComplete onAllNodesComplete;

	private bool _isComplete = false;

	private List<IDependencyListNode> _nodes = new List<IDependencyListNode>();
	
    void Update()
    {
		if (_isComplete) return;
		_isComplete = runNodes();
		if (_isComplete)
		{
			Debug.Log("****** All Nodes Complete! ******");
			clearNodes();
			if (onAllNodesComplete != null) onAllNodesComplete();
		}
	}

	private bool runNodes()
	{
		bool allNodesComplete = true;
		for (int i = 0; i < _nodes.Count; ++i)
		{
			IDependencyListNode node = _nodes[i];
			if (node.listNodeComplete) continue;
			allNodesComplete = false;
			if (node.listNodeRunning) continue;
			bool canRunNode = node.listNodeDependencies.Count == 0 ? true : false; //If it's the head node, this will be true
			for (int j = 0; j < node.listNodeDependencies.Count; ++j)
			{
				IDependencyListNode dependentNode = node.listNodeDependencies[j];
				if (!dependentNode.listNodeComplete)
				{
					canRunNode = false;
					break;
				}
				canRunNode = true;
			}
			if (canRunNode)
			{
				node.listNodeRunning = true;
				node.runListNode();
			}
		}
		return allNodesComplete;
	}

	public void addNode(IDependencyListNode node)
	{
		_nodes.Add(node);
	}

	public void removeNode(IDependencyListNode node)
	{
		_nodes.Remove(node);
	}

	public void clearNodes()
	{
		_nodes.Clear();
	}
}