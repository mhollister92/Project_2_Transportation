public class Airplane 
{
	public bool active = false;

	public int x;
	public int y;

	public int cargo = 0;
	public int cargoCapacity = 90;

	public float turn = 1.5f;
	public float timeToAct;

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
