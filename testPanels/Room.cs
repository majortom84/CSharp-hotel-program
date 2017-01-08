/*********************************************
* Author:  Thomas Cummings
* Date:    last update 4/22/14
* Class:   CIST 2341 - C# Programming I
* Project: Final
* Title:   room class
* Descr:   A hotel program
*********************************************/
public class Room
{
	private static long room_count = 0;
	private long room_number = 1;
	private string bed_size;
	private int bed_amount = 1;
	private double price_per_night = 75.00;
	private string room_type = "Regular";
	private bool available = true;
	private bool clean = true;
	private int floor;

	public Room()
	{
		bed_size = "double";
		bed_amount = 1;
		room_count++;
		room_number = room_count;
		whatFloor(room_number);
	}
	public Room(string bed_size, int bed_amount, bool available)
	{
		this.bed_size = bed_size;
		this.bed_amount = bed_amount;
		this.available = available;
		room_count++;
		room_number = room_count;
		whatFloor(room_number);
	}
	public Room(string bed_size, int bed_amount, bool available, double price_per_night)
	{
		this.bed_size = bed_size;
		this.bed_amount = bed_amount;
		this.available = available;
		this.price_per_night = price_per_night;
		room_count++;
		room_number = room_count;
		whatFloor(room_number);
	}
	public Room(string room_type, string bed_size, int bed_amount, bool available, double price_per_night)
	{
		this.room_type = room_type;
		this.bed_size = bed_size;
		this.bed_amount = bed_amount;
		this.available = available;
		this.price_per_night = price_per_night;
		room_count++;
		room_number = room_count;
		whatFloor(room_number);
	}

	public virtual long Room_number
	{
		get
		{
			return room_number;
		}
		set
		{
			this.room_number = value;
		}
	}


	public virtual string Bed_size
	{
		get
		{
			return bed_size;
		}
		set
		{
			this.bed_size = value;
		}
	}


	public virtual int Bed_amount
	{
		get
		{
			return bed_amount;
		}
		set
		{
			this.bed_amount = value;
		}
	}


	public virtual double Price_per_night
	{
		get
		{
			return price_per_night;
		}
	}


	public virtual string Room_type
	{
		get
		{
			return room_type;
		}
		set
		{
			this.room_type = value;
		}
	}


	public virtual bool Available
	{
		get
		{
			return available;
		}
		set
		{
			this.available = value;
		}
	}

	public virtual bool Clean
	{
		get
		{
			return clean;
		}
		set
		{
			this.clean = value;
		}
	}
	public virtual int Floor
	{
		get
		{
			return floor;
		}
		set
		{
			this.floor = value;
		}
	}
	public static long Room_count
	{
		get
		{
			return room_count;
		}
	}
  
	public virtual int whatFloor(long room_number2)
	{
		if (room_number2 >= 50 && room_number2 < 100)
		{
			//num_of_floors = 2;
			return floor = 2;
		}
		else if (room_number2 >= 100 && room_number2 < 150)
		{
			//num_of_floors = 2;
			return floor = 3;
		}
		else if (room_number2 >= 150 && room_number2 < 200)
		{
			//num_of_floors = 2;
			return floor = 4;
		}
		else
		{
			//num_of_floors = 2;
			return floor = 1;
		}
	}
	public virtual void setRoom(string bed_size, int bed_amount, bool available)
	{
		this.bed_size = bed_size;
		this.bed_amount = bed_amount;
		this.available = available;
	}
	public virtual void setRoom(string bed_size, int bed_amount, bool available, bool clean)
	{
		this.bed_size = bed_size;
		this.bed_amount = bed_amount;
		this.available = available;
		this.clean = clean;
	}
	public override string ToString()
	{
            return string.Format("Room # {0}" + "\r\nFloor: {1}" + "\r\nStyle: {2}" +
                "\r\nBed(s): {3}" + "\r\nSize: {4}" + "\r\nAvailable: {5}" + "\r\nClean: {6}",
                room_number, floor, room_type, bed_amount, bed_size, available, clean);
	}
	//print reservation method
	public virtual string printResRooms()
	{
		return string.Format(" {0,-8} {1,-8} {2,-10} {3,-7} {4,-8} " + 
            "\n {5,-8} {6,-8} {7,-10} {8,-7} {9,-8} ",
            "Room #","Floor","Style","Bed(s)","Size",room_number,floor,room_type,bed_amount,bed_size);
	}
}//end class
