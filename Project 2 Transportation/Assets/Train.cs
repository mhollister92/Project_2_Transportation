public class Train{

	public bool active = false;

	public int x;
	public int y;

	public int cargo;
	public int cargoCapacity = 550;

	public float turn = 6f;
	public float timeToAct;

	public void moveTrain (int xLocation, int yLocation)
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
