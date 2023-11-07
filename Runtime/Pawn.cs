using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
	Controller _owningController;
	public Controller OwningController => _owningController;

	public void PossessedBy(Controller newController)
	{
		_owningController = newController;
		OnPossessed(newController);
	}

	public void UnPossessed()
	{
		OnUnPossessed();
		_owningController = null;
	}

	protected abstract void OnPossessed(Controller newController);
	protected abstract void OnUnPossessed();
}
