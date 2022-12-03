public class FSM_State
{
	public delegate void EnterFunc();

	public delegate void UpdateFunc(float delta);

	public delegate FSM_State InputFunc();

	public EnterFunc Enter;

	public UpdateFunc Update;

	public InputFunc HandleInput;
}

