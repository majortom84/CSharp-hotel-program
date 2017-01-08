/*********************************************
* Author:  Thomas Cummings
* Date:    last update 4/22/14
* Class:   CIST 2341 - C# Programming I
* Project: Final
* Title:   reservation class
* Descr:   A hotel program
*********************************************/
using System;
public class Reservation
{
	private static long res_counter = 000;
    private long res_id = res_counter;
	private Customer customer;
	private Room room;
    private int guests = 1;
    private DateTime from;
    private DateTime to;
    private int amountOfRooms;
    private bool isPaid;
    private bool wakeUp = false;
    private String wakeHour;
    private String wakeMin;
    private String wakeState;
    private String vMake;
    private String vMod;
    private String vPlate;
    /*
     * do i need to pass the customer? 
     * pass room to see what romm is reserved
     * or just pass room# then when searching res use room# to find info to display
    */
    //constructors
	public Reservation()
	{
        customer.IsReservation = true;
        res_counter++;
        res_id = res_counter;
        this.customer.ReservationNum = res_id;
	}
    public Reservation(Customer customer, Room room)
	{
		this.customer = customer;
        this.customer.IsReservation = true;
		this.room = room;
        this.customer.ReservationNum = res_id;
        res_counter++;
        res_id = res_counter;
	}
    public Reservation(Customer customer, Room room, int guests, DateTime from, DateTime to, String vMake, String vMod, String vPlate)
    {
        this.customer = customer;
        this.customer.IsReservation = true;
        this.room = room;
        this.customer.ReservationNum = res_id;
        this.guests = guests;
        this.from = from;
        this.to = to;
        res_counter++;
        res_id = res_counter;
        this.vMake = vMake;
        this.vMod = vMod;
        this.vPlate = vPlate;
        
    }
    public Reservation(Customer customer, Room room, int guests, DateTime from, DateTime to, bool wakeUp, String wakeHour, 
        String wakeMin, String wakeState, String vMake, String vMod, String vPlate)
    {
        this.customer = customer;
        this.customer.IsReservation = true;
        this.room = room;
        this.customer.ReservationNum = res_id;
        this.guests = guests;
        this.from = from;
        this.to = to;
        this.wakeUp = wakeUp;
        this.wakeHour = wakeHour;
        this.wakeMin = wakeMin;
        this.wakeState = wakeState;
        res_counter++;
        res_id = res_counter;
        this.vMake = vMake;
        this.vMod = vMod;
        this.vPlate = vPlate;
    }
    //getters and setters
    /*public void counter()
    {
        res_counter++;
        res_id = res_counter;
    }*/
    public static long Res_Counter
    {
        get { return res_counter; }
        set { res_counter = value; }
    }
    public virtual long Res_Id
    {
        get { return res_id; }
        set { this.res_id = value; }
    }
    public virtual int Guests
    {
        get { return guests; }
        set { this.guests = value; }
    }
    public virtual Room Room
    {
        get { return room; }
    }
    public virtual Customer Customer
    {
        get
        { return customer; }
    }
    public virtual int AmountOfRooms
    {
        get { return amountOfRooms; }
        set { this.amountOfRooms = value; }
    }
    public virtual DateTime From
    {
        get { return from; }
        set { this.from = value; }
    }
    public virtual DateTime To
    {
        get { return to; }
        set { this.to = value; }
    }
    public virtual bool IsPaid
    {
        get { return isPaid; }
        set { this.isPaid = value; }
    }
    public virtual bool WakeUp
    {
        get { return wakeUp; }
        set { this.wakeUp = value; }
    }
    public virtual String WakeHour
    {
        get { return wakeHour; }
        set { this.wakeHour = value; }
    }
    public virtual String WakeMin
    {
        get { return wakeMin; }
        set { this.wakeMin = value; }
    }
    public virtual String WakeState
    {
        get { return wakeState; }
        set { this.wakeState = value; }
    }

    public virtual String VMake
    {
        get { return vMake; }
        set { this.vMake = value; }
    }
    public virtual String VMod
    {
        get { return vMod; }
        set { this.vMod = value; }
    }
    public virtual String VPlate
    {
        get { return vPlate; }
        set { this.vPlate = value; }
    }

    //displays
	public override string ToString()
	{
        return string.Format("\r\nReservation Information : " +
                            "\r\n\nReservation Number : " + this.res_id.ToString() +
                            "\r\nCustomer Information : \r\n" + customer.ToString() + 
                            "\r\nRoom Information : \r\n" + room.ToString() + 
                            "\r\n");
	}
    public string Message()
    {
        String resMess = "";
        if (wakeUp)
        {
            resMess = string.Format("\r\nReservation Information : " +
                                "\r\n\nReservation # : " + this.res_id.ToString() +
                                "\r\n\nCustomer Information : " +
                                "\r\n" + customer.F_name + " " + customer.L_name +
                                "\r\n\nRoom Information : " +
                                "\r\nRoom # : " + room.Room_number +
                                "\r\nRoom Type: " + room.Room_type +
                                "\r\nBed Amount : " + room.Bed_amount +
                                "\r\nBed Size : " + room.Bed_size +
                                "\r\nGuests : " + guests +
                                "\r\nWake up call : " + wakeHour + ":" + wakeMin + " " + wakeState +
                                "\r\nPrice per Night : " + room.Price_per_night +
                                "\r\nStay from : " + from.ToLongDateString() + "  To : " + to.ToLongDateString());
        }
        else
        {
            resMess = string.Format("\r\nReservation Information : " +
                                "\r\n\nReservation # : " + this.res_id.ToString() +
                                "\r\n\nCustomer Information : " +
                                "\r\n" + customer.F_name + " " + customer.L_name +
                                "\r\n\nRoom Information : " +
                                "\r\nRoom # : " + room.Room_number +
                                "\r\nRoom Type: " + room.Room_type +
                                "\r\nBed Amount : " + room.Bed_amount +
                                "\r\nBed Size : " + room.Bed_size +
                                "\r\nGuests : " + guests +
                                "\r\nPrice per Night : " + room.Price_per_night +
                                "\r\nStay from : " + from.ToLongDateString() + "  To : " + to.ToLongDateString() +
                                "\r\n\r\nCheck-in time : 3:00pm" + 
                                "\r\nCheck-out time : 12:00pm");
        }
        return resMess;
    }
}//end class