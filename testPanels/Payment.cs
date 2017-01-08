/*********************************************
* Author:  Thomas Cummings
* Date:    last update 4/22/14
* Class:   CIST 2341 - C# Programming I
* Project: Final
* Title:   payment class
* Descr:   A hotel program
*********************************************/
public class Payment
{
	private double total;
	private double subtotal;
	private double grandtotal;
	private string payment_type;
	private static double TAX = 0.07;
	private double payment_amount;
    private double payment_owed;
	private double change;
    private bool isPaid;

	public Payment()
	{
        if (payment_amount - grandtotal < grandtotal)
            payment_owed = payment_amount - grandtotal;
        else if (payment_amount - grandtotal > grandtotal)
            change = payment_amount - grandtotal;
	}

	public Payment(string payment_type, double payment_amount)
	{
		this.payment_type = payment_type;
		this.payment_amount = payment_amount;
        if (payment_amount - grandtotal < grandtotal)
            payment_owed = payment_amount - grandtotal;
        else if (payment_amount - grandtotal > grandtotal)
            change = payment_amount - grandtotal;
            
	}

	public Payment(double total, string payment_type, double payment_amount)
	{
		this.total = total;
		this.payment_type = payment_type;
		this.payment_amount = payment_amount;
        if (payment_amount - grandtotal < grandtotal)
            payment_owed = payment_amount - grandtotal;
        else if (payment_amount - grandtotal > grandtotal)
            change = payment_amount - grandtotal;
	}

	public Payment(double total, double subtotal, string payment_type, double payment_amount)
	{
		this.total = total;
		this.subtotal = subtotal;
		this.payment_type = payment_type;
		this.payment_amount = payment_amount;
        if (payment_amount - grandtotal < grandtotal)
            payment_owed = payment_amount - grandtotal;
        else if (payment_amount - grandtotal > grandtotal)
            change = payment_amount - grandtotal;
	}

	public Payment(double total, double subtotal, double grandtotal, string payment_type)
	{
		this.total = total;
		this.subtotal = subtotal;
		this.grandtotal = grandtotal;
		this.payment_type = payment_type;
        if (payment_amount - grandtotal < grandtotal)
            payment_owed = payment_amount - grandtotal;
        else if (payment_amount - grandtotal > grandtotal)
            change = payment_amount - grandtotal;
	}
	public virtual void setPayment(double payment_amount, string payment_type)
	{
		this.payment_amount = payment_amount;
		this.payment_type = payment_type;
        payment_owed = payment_amount - grandtotal;
	}
    //getters / setters
    public static double Tax
    {
        get { return TAX; }
    }
    public virtual bool IsPaid
    {
        get { return isPaid; }
        set { this.isPaid = value; }
    }
    public virtual double Change
    {
        get { return change; }
        set { this.change = value; }
    }
    public virtual double Payment_Owed
    {
        get { return payment_owed; }
        set { this.payment_owed = value; }
    }
    public virtual double Payment_Amount
    {
        get { return payment_amount; }
        set { this.payment_amount = value; }
    }
    public virtual string Payment_Type
    {
        get { return payment_type; }
        set { this.payment_type = value; }
    }
    public virtual double Total
    {
        get { return total; }
        set { this.total = value; }
    }
    public virtual double Subtotal
    {
        get { return subtotal; }
        set { this.subtotal = value; }
    }
    public virtual double Grandtotal
    {
        get { return grandtotal; }
        set { this.grandtotal = value; }
    }
    //display
	public virtual string ToString(double subtotal, double grandtotal, string payment_type)
	{
		return "Tax..." + TAX + 
            "\nSubtotal..." + subtotal + 
            "=======================" + 
            "\nGrandtotal..." + grandtotal + 
            "Payment type..." + payment_type;
	}

	public virtual string printRecipt()
	{
		return "";
	}

}//end calss