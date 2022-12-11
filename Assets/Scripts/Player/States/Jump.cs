using UnityEngine;

public class Jump : State {

    private PlayerController controller;
    private bool hasJumped;
    private float cooldown;
    
    public Jump(PlayerController controller) : base("Jump") {
        this.controller = controller;
    }

    public override void Enter() {
        base.Enter();

            controller.isJumping = true;
        controller.isGrounded = false;
            ApplyImpulse();

        // Handle animator
        controller.thisAnimator.SetBool("bJumping", true);
    }

    public override void Exit() {
        base.Exit();
        controller.isJumping = false;
        // Handle animator
        controller.thisAnimator.SetBool("bJumping", false);
    }

    public override void Update() {
        base.Update();


        // Switch to Idle
        if(controller.isGrounded ) {
            controller.stateMachine.ChangeState(controller.idleState);
            return;
        }
    }

    public override void LateUpdate() {
        base.LateUpdate();
    }

    public override void FixedUpdate() {
        base.FixedUpdate();

        // Jump
        

        // Create vector
        Vector3 walkVector = new Vector3(controller.movementVector.x, 0, controller.movementVector.y);
        walkVector = controller.GetForward() * walkVector;
        walkVector *= controller.movementSpeed * controller.jumpMovementFactor;

        // Apply input to character
        controller.thisRigidbody.AddForce(walkVector, ForceMode.Force);

        // Rotate character
        controller.RotateBodyToFaceInput();
    }

    private void ApplyImpulse() {
        // Apply impulse
        Vector3 forceVector = Vector3.up * controller.jumpPower;
        controller.thisRigidbody.AddForce(forceVector, ForceMode.Impulse);
    }

}