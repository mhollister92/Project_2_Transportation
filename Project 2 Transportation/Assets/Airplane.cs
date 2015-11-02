public class Airplane 
{
	public bool active;

	public int x;
	public int y;

	private int xDirection;
	private int yDirection;

	public int cargo = 0;
	public int cargoCapacity = 90;

	public void SetMoveDirection(int xMoveDirection, int yMoveDirection)
	{
		xDirection = xMoveDirection;
		yDirection = yMoveDirection;
	}

	public void MoveAirplane()
	{
			x += xDirection;
			y += yDirection;
		    SetMoveDirection (0, 0);
	}
}
