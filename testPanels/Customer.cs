/*********************************************
* Author:  Thomas Cummings
* Date:    last update 4/22/14
* Class:   CIST 2341 - C# Programming I
* Project: Final
* Title:   custoemr class
* Descr:   A hotel program
*********************************************/
using System;
using System.Collections.Generic;

public class Customer
{
	private static long customer_counter = 0;
	private long cust_id = 0;
	private string f_name;
	private string l_name;
	private string email;
	private string h_number;
	private string m_number;
	private string address;
    private string city;
    private string st;
    private string zip;
    private string note;
	private long reservationNum;
	private bool isReservation;
	public List<Reservation> res = new List<Reservation>();
    private List<Payment> pmnts = new List<Payment>();
    private Reservation reserve;
    private Payment pay;
    int index;
	//internal Scanner input = new Scanner(System.in);
	//make reserved object in here make method to set reservation object
	//make temp reservation then ask customer to verify reservation before adding to arraylist

	public Customer()
	{
		f_name = "";
		l_name = "";
		email = "";
		h_number = "";
		m_number = "";
		address = "";
        city = "";
        st = "";
        zip = "";
		customer_counter++;
		cust_id = customer_counter;
        isReservation = false;
	}

    public Customer(string f_name, string l_name, string address, string city, string st,
                    string zip, string h_number, string m_number, string email)
	{
		this.f_name = f_name;
		this.l_name = l_name;
		this.email = email;
		this.h_number = h_number;
		this.m_number = m_number;
		this.address = address;
        this.city = city;
        this.st = st;
        this.zip = zip;
		customer_counter++;
        cust_id = customer_counter;
        isReservation = false;
	}

    public Customer(string f_name, string l_name, string address, string city, string st,
                    string zip, string h_number, string m_number, string email, string note)
    {
        this.f_name = f_name;
        this.l_name = l_name;
        this.email = email;
        this.h_number = h_number;
        this.m_number = m_number;
        this.address = address;
        this.city = city;
        this.st = st;
        this.zip = zip;
        this.note = note;
        customer_counter++;
        cust_id = customer_counter;
        isReservation = false;
    }

    public virtual long Cust_id
    {
        get
        {
            return cust_id;
        }
   
    }
    
	public virtual string F_name
	{
		get
		{
			return f_name;
		}
		set
		{
			this.f_name = value;
		}
	}


	public virtual string L_name
	{
		get
		{
			return l_name;
		}
		set
		{
			this.l_name = value;
		}
	}


	public virtual string Email
	{
		get
		{
			return email;
		}
		set
		{
			this.email = value;
		}
	}


	public virtual string H_number
	{
		get
		{
			return h_number;
		}
		set
		{
			this.h_number = value;
		}
	}


	public virtual string M_number
	{
		get
		{
			return m_number;
		}
		set
		{
			this.m_number = value;
		}
	}


	public virtual string Address
	{
		get
		{
			return address;
		}
		set
		{
			this.address = value;
		}
	}

    public virtual string City
    {
        get
        {
            return city;
        }
        set
        {
            this.city = value;
        }
    }

    public virtual string St
    {
        get
        {
            return st;
        }
        set
        {
            this.st = value;
        }
    }

    public virtual string Zip
    {
        get
        {
            return zip;
        }
        set
        {
            this.zip = value;
        }
    }

    public virtual string Note
    {
        get
        {
            return note;
        }
        set
        {
            this.note = value;
        }

    }

	public virtual long ReservationNum
	{
		get
		{
			return reservationNum;
		}
		set
		{
			this.reservationNum = value;
		}
	}


	public virtual bool IsReservation
	{
		get
		{
			return isReservation;
		}
		set
		{
			this.isReservation = value;
		}
	}

    public List<Reservation> GetResList
    {
        get
        {
            return res;
        }
    }
    public virtual Reservation TempRes
    {
        get
        {
            return reserve;
        }
        set
        {
            this.reserve = value;
        }
    }
    public virtual Payment Pay
    {
        get { return pay; }
        set { this.pay = value; }
    }
    //methods to make reservation constructor
    internal void tempReser(Customer customer, Room room)
    {
        reserve = new Reservation(customer, room);
    }
    internal void tempReser(Customer customer, Room room, int guests, DateTime from, DateTime to, String vMake, String vMod, String vPlate)
    {
        reserve = new Reservation(customer, room, guests, from, to, vMake, vMod, vPlate);
    }
    internal void tempReser(Customer customer, Room room, int guests, DateTime from, DateTime to,
        bool wakeUp, String wakeH, String wakeM, String wakeState, String vMake, String vMod, String vPlate)
    {
        reserve = new Reservation(customer, room, guests, from, to, wakeUp, wakeH, wakeM, wakeState, vMake, vMod, vPlate);
    }
    //method to add payment to list
	public void makeReservation()
	{
		res.Add(reserve);
        //res[res.Count - 1].counter();
	}
    //make a payment obj
    internal void payment(double total, string pmnt_type, double pmnt_amount)
    {
        pay = new Payment(total, pmnt_type, pmnt_amount);
        pmnts.Add(pay);

    }
    //search and return index in reservation list
    public int searchResCustID(int search)
    {
        for (int i = 0; i < res.Count; i++ )
        {
            if (cust_id == search)
            {
                index = i;
            }
            else
            {
                index = -1;
            }
        }
        return index;
    }
    //search payment list
    public int searchPmtCustID(int search)
    {
        for (int i = 0; i < pmnts.Count; i++)
        {
            if (cust_id == search)
            {
                index = i;
            }
            else
            {
                index = -1;
            }
        }
        return index;
    }
	public override string ToString()
	{
        return string.Format("{0,-15}{1,-10}{2,-10}" + new string(' ', 1000) + 
                            "\r\n{3,-15}{4,-10}" + new string(' ', 1000) + 
                            "\r\n{5,31} {6,-3}{7,-7}" + new string(' ', 1000)+ 
                            "\r\n{8,-16}{9,-10}" + new string(' ', 1000)+ 
                            "\r\n{10,-16}{11,-12}" + new string(' ', 1000) + 
                            "\r\n{12,-18}{13,-12}" + new string(' ', 1000) +
                            "\r\n{14,-15}{15,-8}" + new string(' ', 1000),
                            "Name:", f_name, " " + l_name, 
	                        "Address:", address,
	                         City, st, " " + zip,
                            "Phone:", h_number, 
                            "Mobile:", m_number, 
                            "Email:", email,
                            "Customer ID:", cust_id.ToString());

	}
	public virtual string printForReservation()
	{
		return string.Format("{0,-12}{1,-10}{2,-10}\n{3,-12}{4,-10}\n{5,-12}{6,-10}\n{7,-12}{8,-10}",
            "Name:", f_name," " + l_name, "Phone:", h_number, "Mobile:", m_number, "Email:", email);
	}
	//display reservations array
	public virtual void displayRooms()
	{
		foreach (Reservation r in res)
		{
			Console.WriteLine(res + "\r\n");
		}
	}
	public virtual void printReservation()
	{
		displayRooms();
	}
    /*
     * find res by field, display with reservation to string
    */

}//end class