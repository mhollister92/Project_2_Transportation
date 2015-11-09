public class Airplane 
{
	public bool active;

	public int x;
	public int y;

	//private int xDirection;
	//private int yDirection;

	public int cargo = 0;
	public int cargoCapacity = 90;

	//public void SetMoveDirection(int xMoveDirection, int yMoveDirection)
	//{
		//xDirection = xMoveDirection;
		//yDirection = yMoveDirection;
	//}

	public void MoveAirplane(int xLocation, int yLocation)
	{
		if (xLocation > x && yLocation > y) {
			x += 1;
			y += 1;
		} else if (xLocation < x && yLocation < y) {
			x -= 1;
			y -= 1;
		} else if (xLocation > x && yLocation < y) {
			x += 1;
			y -= 1;
		} else if (xLocation < x && yLocation > y) {
			x -= 1;
			y += 1;
		} else if (xLocation == x && yLocation < y) {
			y -= 1;
		} else if (xLocation == x && yLocation > y) {
			y += 1;
		} else if (xLocation > x && yLocation == y) {
			x += 1;
		} else if (xLocation < x && yLocation == y) {
			x -= 1;
		}
	}

	public void AddCargo ()
	{
		if (active && cargo < cargoCapacity) {
			cargo += 10;
		}
	}
}
