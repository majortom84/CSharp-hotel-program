/*********************************************
* Author:  Thomas Cummings
* Date:    last update 4/22/14
* Class:   CIST 2341 - C# Programming I
* Project: Final
* Title:   employee class
* Descr:   A hotel program
*********************************************/
public class Employee
{
	private string f_name;
	private string l_name;
	private static long emp_id_counter = 000;
	private long emp_id = 0000;
	private double hr_salary;
	private double mo_salary;
	private double yr_salary;
	private string role;
	private double sales;
	private string password;
	private string username;
    private string h_number;
    private string m_number;
    private string address;
    private string city;
    private string st;
    private string zip;

	public Employee()
	{
		f_name = "";
		l_name = "";
		username = "";
		password = "";
		sales = 0.00;
		emp_id_counter++;
		emp_id = emp_id_counter;
	}
	public Employee(string first_name, string last_name)
	{
		this.f_name = first_name;
		this.l_name = last_name;
		sales = 0.00;
		emp_id_counter++;
		emp_id = emp_id_counter;
	}
	public Employee(string first_name, string last_name, double hr_salary, string role)
	{
		this.f_name = first_name;
		this.l_name = last_name;
		this.hr_salary = hr_salary;
		this.role = role;
		sales = 0.00;
		emp_id_counter++;
		emp_id = emp_id_counter;
	}
	public Employee(string first_name, string last_name, double hr_salary, string role, string password)
	{
		this.f_name = first_name;
		this.l_name = last_name;
		this.hr_salary = hr_salary;
		this.role = role;
		this.password = password;
		sales = 0.00;
		emp_id_counter++;
		emp_id = emp_id_counter;
	}
	public Employee(string first_name, string last_name, double hr_salary, string role, string username, string password)
	{
		this.f_name = first_name;
		this.l_name = last_name;
		this.hr_salary = hr_salary;
		this.role = role;
		this.password = password;
		this.username = username;
		sales = 0.00;
		emp_id_counter++;
		emp_id = emp_id_counter;
	}
	public Employee(string first_name, string last_name, string password)
	{
		this.f_name = first_name;
		this.l_name = last_name;
		this.password = password;
		sales = 0.00;
		emp_id_counter++;
		emp_id = emp_id_counter;
	}
	public Employee(string first_name, string last_name, string username, string password)
	{
		this.f_name = first_name;
		this.l_name = last_name;
		this.username = username;
		this.password = password;
		sales = 0.00;
		emp_id_counter++;
		emp_id = emp_id_counter;
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
	public virtual long Emp_id
	{
		get
		{
			return emp_id;
		}
		set
		{
			this.emp_id = value;
		}
	}
	public virtual double Hr_salary
	{
		get
		{
			return hr_salary;
		}
		set
		{
			this.hr_salary = value;
		}
	}
	public virtual string Role
	{
		get
		{
			return role;
		}
		set
		{
			this.role = value;
		}
	}

	public virtual double Sales
	{
		get
		{
			return sales;
		}
		set
		{
			this.sales = value;
		}
	}


	public virtual string Password
	{
		get
		{
			return password;
		}
		set
		{
			this.password = value;
		}
	}


	public virtual string Username
	{
		get
		{
			return username;
		}
		set
		{
			this.username = value;
		}
	}


	public virtual double Mo_salary
	{
		get
		{
			return mo_salary;
		}
		set
		{
			this.mo_salary = value;
		}
	}
	public virtual double Yr_salary
	{
		get
		{
			return yr_salary;
		}
		set
		{
			this.yr_salary = value;
		}
	}
	public static long Emp_id_counter
	{
		get
		{
			return emp_id_counter;
		}
	}

    private void addCustomer()//add a customer via employee
    {

    }
    /*public override string ToString()
    {
        return string.Format("{0,-15}{1,-10}{2,-10}" + new string(' ', 1000) +
                            "\r\n{3,-15}{4,-10}" + new string(' ', 1000) +
                            "\r\n{5,31} {6,-3}{7,-7}" + new string(' ', 1000) +
                            "\r\n{8,-16}{9,-10}" + new string(' ', 1000) +
                            "\r\n{10,-16}{11,-12}" + new string(' ', 1000),
                            "Name:", f_name, " " + l_name,
                            "Address:", address,
                             city, st, " " + zip,
                            "Phone:", h_number,
                            "Mobile:", m_number);
    }*/
    public override string ToString()
    {
        return string.Format("{0,-15}{1,-10}{2,-10}" + new string(' ', 1000) +
                             "{3,-17}{4,-10}" + new string(' ', 1000),
                            "Name:", f_name, " " + l_name,
                            "Type: ", role);
    }
	/*public virtual string printSales()
	{
		return string.Format(" {0,-10},{1,-20} {2,10:F}", f_name, l_name,sales);
	}
	public virtual string displayUsername()
	{
		return "Username: " + username;
	}
	public virtual string displaySales()
	{
		return "Sales: " + sales;
	}*/
}//end class