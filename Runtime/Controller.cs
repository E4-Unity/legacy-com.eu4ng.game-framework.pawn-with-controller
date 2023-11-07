using UnityEngine;

public abstract class Controller : MonoBehaviour
{
	Pawn _ownedPawn;
	public Pawn OwnedPawn => _ownedPawn;

	public void Possess(Pawn newPawn)
	{
		// 기존 Pawn 빙의 해제
		if (_ownedPawn is not null) UnPossess();

		// 새로운 Pawn 빙의
		_ownedPawn = newPawn;
		_ownedPawn.PossessedBy(this);
		OnPossess(newPawn);
	}

	public void UnPossess()
	{
		OnUnPossess();
		_ownedPawn.UnPossessed();
		_ownedPawn = null;
	}

	protected abstract void OnPossess(Pawn newPawn);
	protected abstract void OnUnPossess();
}
