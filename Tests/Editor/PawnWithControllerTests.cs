using NUnit.Framework;
using UnityEngine;

public class PawnWithControllerTests
{
    [Test]
    public void ReferenceTests()
    {
	    CreateTestObjects(out var pawn, out var controller);
	    controller.Possess(pawn);

	    Assert.NotNull(pawn.OwningController, "Controller.Possess > Pawn.OwningController");
	    Assert.NotNull(controller.OwnedPawn, "Controller.Possess > Controller.OwnedPawn");
    }

    [Test]
    public void EventFunctionCallTests()
    {
	    CreateTestObjects(out var character, out var playerController);

	    Assert.False(character.IsOnPossessedCalled, "Init > Character.IsOnPossessedCalled");
	    Assert.False(character.IsOnUnPossessedCalled, "Init > Character.IsOnUnPossessedCalled");
	    Assert.False(playerController.IsOnPossessCalled, "Init > PlayerController.IsOnPossessCalled");
	    Assert.False(playerController.IsOnUnPossessCalled, "Init > PlayerController.IsOnUnPossessCalled");

	    playerController.Possess(character);

	    Assert.True(character.IsOnPossessedCalled, "Controller.Possess > Character.IsOnPossessedCalled");
	    Assert.False(character.IsOnUnPossessedCalled, "Controller.Possess > Character.IsOnUnPossessedCalled");
	    Assert.True(playerController.IsOnPossessCalled, "Controller.Possess > PlayerController.IsOnPossessCalled");
	    Assert.False(playerController.IsOnUnPossessCalled, "Controller.Possess > PlayerController.IsOnUnPossessCalled");

	    playerController.UnPossess();

	    Assert.True(character.IsOnPossessedCalled, "Controller.UnPossess > Character.IsOnPossessedCalled");
	    Assert.True(character.IsOnUnPossessedCalled, "Controller.UnPossess > Character.IsOnUnPossessedCalled");
	    Assert.True(playerController.IsOnPossessCalled, "Controller.UnPossess > PlayerController.IsOnPossessCalled");
	    Assert.True(playerController.IsOnUnPossessCalled, "Controller.UnPossess > PlayerController.IsOnUnPossessCalled");
    }

    void CreateTestObjects(out Character character, out PlayerController playerController)
    {
	    character = new GameObject().AddComponent<Character>();
	    playerController = new GameObject().AddComponent<PlayerController>();
    }

    internal class Character : Pawn
    {
	    bool _isOnPossessedCalled;
	    bool _isOnUnPossessedCalled;

	    public bool IsOnPossessedCalled => _isOnPossessedCalled;
	    public bool IsOnUnPossessedCalled => _isOnUnPossessedCalled;

	    protected override void OnPossessed(Controller newController)
	    {
		    _isOnPossessedCalled = true;
	    }

	    protected override void OnUnPossessed()
	    {
		    _isOnUnPossessedCalled = true;
	    }
    }

    internal class PlayerController : Controller
    {
	    bool _isOnPossessCalled;
	    bool _isOnUnPossessCalled;

	    public bool IsOnPossessCalled => _isOnPossessCalled;
	    public bool IsOnUnPossessCalled => _isOnUnPossessCalled;

	    protected override void OnPossess(Pawn newPawn)
	    {
		    _isOnPossessCalled = true;
	    }

	    protected override void OnUnPossess()
	    {
		    _isOnUnPossessCalled = true;
	    }
    }
}
