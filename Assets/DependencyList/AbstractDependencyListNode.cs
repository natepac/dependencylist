using System.Collections.Generic;
using UnityEngine;

public class AbstractDependencyListNode : MonoBehaviour, IDependencyListNode
{
	public bool listNodeComplete { get; set; }
	public bool listNodeRunning { get; set; }
	public List<IDependencyListNode> listNodeDependencies { get; set; } = new List<IDependencyListNode>();

	public virtual void runListNode() { }

	public void addDependency(IDependencyListNode node)
	{
		listNodeDependencies.Add(node);
	}

	public void removeDependency(IDependencyListNode node)
	{
		listNodeDependencies.Remove(node);
	}

	public void clearDependencies()
	{
		listNodeDependencies.Clear();
	}
}
