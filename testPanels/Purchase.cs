public class Purchase
{
	private double total;
	private double subtotal;
	private double grandtotal;
	private string payment_type;
	private readonly double TAX = 0.07;
	private double payment_amount;
	private double change;

	public Purchase()
	{
	}

	public Purchase(string payment_type, double payment_amount)
	{
		this.payment_type = payment_type;
		this.payment_amount = payment_amount;
	}

	public Purchase(double total, string payment_type, double payment_amount)
	{
		this.total = total;
		this.payment_type = payment_type;
		this.payment_amount = payment_amount;
	}

	public Purchase(double total, double subtotal, string payment_type, double payment_amount)
	{
		this.total = total;
		this.subtotal = subtotal;
		this.payment_type = payment_type;
		this.payment_amount = payment_amount;
	}

	public Purchase(double total, double subtotal, double grandtotal, string payment_type)
	{
		this.total = total;
		this.subtotal = subtotal;
		this.grandtotal = grandtotal;
		this.payment_type = payment_type;
	}
	public virtual void setPayment(double payment_amount, string payment_type)
	{
		this.payment_amount = payment_amount;
		this.payment_type = payment_type;
	}

	public virtual string ToString(double subtotal, double grandtotal, string payment_type)
	{
		return "Tax..." + TAX + "\nSubtotal..." + subtotal + "=======================" + "\nGrandtotal..." + grandtotal + "Payment type..." + payment_type;
	}

	public virtual string printRecipt()
	{
		return "";
	}

}
