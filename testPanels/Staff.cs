/*********************************************
* Author:  Thomas Cummings
* Date:    last update 4/22/14
* Class:   CIST 2341 - C# Programming I
* Project: Final
* Title:   staff class
* Descr:   A hotel program
*********************************************/
public class Staff : Employee
{

	public Staff() : base()
	{
	}
	public Staff(string first_name, string last_name) : base(first_name, last_name)
	{
	}
	public Staff(string first_name, string last_name, string username, string password) : base(first_name, last_name,username,password)
	{
		base.Role = "Staff";
	}
	public Staff(string first_name, string last_name, double hr_salary, string role) : base(first_name, last_name, hr_salary,role)
	{
	}
	public virtual void setStaff(string first_name, string last_name, double hr_salary, string role)
	{
		F_name = first_name;
		L_name = last_name;
		Hr_salary = hr_salary;
		Role = role;
	}
	/*public override string ToString()
	{
		return string.Format(" {0,-10},{1,-20} {2,-10}", F_name, L_name,Role);
	}*/
   /* public override string ToString()
    {
        return string.Format("{0,-15}{1,-10}{2,-10}" + new string(' ', 1000) +
                             "{3,-15}{4,-10}" + new string(' ', 1000),
                            "Name:", F_name, " " + L_name,
                            "Type of Employee: ", Role);
    }*/

}//end calss