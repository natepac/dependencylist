using System.Collections.Generic;

public interface IDependencyListNode
{
	bool listNodeComplete { get; set; }
	bool listNodeRunning { get; set; }
	List<IDependencyListNode> listNodeDependencies { get; set; }
	void runListNode();
	void addDependency(IDependencyListNode node);
	void removeDependency(IDependencyListNode node);
	void clearDependencies();
}