public class Boat {

	public bool active = false;

	public int x;
	public int y;

	public int cargo;
	public int cargoCapacity = 200;

	public float turn = 4.5f;
	public float timeToAct;

	public void moveBoat (int xLocation, int yLocation)
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

	public void AddCargo()
	{
		if (active && cargo < cargoCapacity) {
			cargo += 10;
		}
	}

}
