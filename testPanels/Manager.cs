/*********************************************
* Author:  Thomas Cummings
* Date:    last update 4/22/14
* Class:   CIST 2341 - C# Programming I
* Project: Final
* Title:   manager class
* Descr:   A hotel program
*********************************************/
using System.Collections.Generic;

public class Manager : Employee
{

	private int employees;

	public Manager() : base()
	{
		employees = 0;
		base.Role = "Manager";
	}
	public Manager(string first_name, string last_name) : base(first_name, last_name)
	{
		base.Role = "Manager";
	}
	public Manager(string first_name, string last_name, string role) : base(first_name, last_name, role)
	{
	}
	public Manager(string first_name, string last_name, double hr_salary, string role) : base(first_name, last_name, hr_salary, role)
	{
	}
	public Manager(string first_name, string last_name, string password, string username) : base(first_name, last_name,password,username)
	{
		base.Role = "Manager";
	}
	public virtual int Employees
	{
		get
		{
			return employees;
		}
		set
		{
			this.employees = value;
		}
	}
	public virtual void setManager(string f_name, string l_name)
	{
		this.F_name = f_name;
		this.L_name = l_name;
	}
	public virtual void setManager(string f_name, string l_name, string username, string password)
	{
		this.F_name = f_name;
		this.L_name = l_name;
		this.Username = username;
		this.Password = password;
	}
	public virtual void setManager(string f_name, string l_name, int employees)
	{
		this.F_name = f_name;
		this.L_name = l_name;
		this.employees = employees;
	}
	public virtual void addEmployee(ICollection<Employee> employees, string fname, string lname)
	{
		employees.Add(new Employee(fname, lname));
	}
	public virtual void addEmployee(ICollection<Employee> employees, string fname, string lname, string username, string pass)
	{
		// is emp a manager? if so add manager, if else add staff
		employees.Add(new Employee(fname, lname,username,pass));
	}

	/*public override string ToString()
	{
		return "\nName: " + F_name + " " + L_name + "\nEmployee ID: " + Emp_id + "\nNum of employees: " + Employees;
	}*/
    /*public override string ToString()
    {
        return string.Format("{0,-15}{1,-10}{2,-10}" + new string(' ', 1000) +
                             "{3,-15}{4,-10}" + new string(' ', 1000),
                            "Name:", F_name, " " + L_name,
                            "Type: ", Role);
    }*/
}//end class