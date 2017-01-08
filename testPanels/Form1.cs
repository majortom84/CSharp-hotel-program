/*********************************************
* Author:  Thomas Cummings
* Date:    last update 4/22/14
* Class:   CIST 2341 - C# Programming I
* Project: Final
* Title:   Form 1
* Descr:   A hotel program
*********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransylvaniaTowers
{
    public partial class Form1 : Form  
    {
        //global data fields
        private int login_count = 3;// 3 attempts to login
        private bool found = false;
        private StringBuilder current_login = new StringBuilder();
        private string pass = ""; // change to string builder.<<<<<<<<<<<<<<<<<
        private DateTime from;
        private DateTime to;
        private int guests;
        //substring name search variables 
        private String searchThis;
        private String searchForThis;
        //for payment
        double subTotal;
        double TAX;
        double salesTax;

        private int floor;//holds floor number

        //arrays to hold data
        //list fro Employees, customers, rooms
        private List<Employee> employees = new List<Employee>();//list that holds all emps
        private List<Customer> customers = new List<Customer>();//list that holds all cutomers
        private List<Room> floor1 = new List<Room>();
        private List<Room> floor2 = new List<Room>();
        private List<Room> floor3 = new List<Room>();
        private List<Room> floor4 = new List<Room>();
        private Button[] roomBtn = new Button[80];//room buttons
        private List<Customer> searched = new List<Customer>();//hold searched list of customers
        private List<Employee> searched2 = new List<Employee>();//hold searched list of customers
        private Employee currentEmp;//To store current employee
        private Customer currentCust;//To store current customer
        private Room selectedRoom;//To store the selected room
        private DateTime EndOfTime;
        int altCust = 0;//for alternate row colors (control)

        public Form1()
        {
            InitializeComponent();
            managmentControl.Visible = false; // <<<<<<<<<<<<<<<<<<<<<<<<<<<<< make tabs in managers stuff invisible
            addButtons(); // add room buttons to form
            this.AcceptButton = loginBtn;//enable enter keypress to fire click loginBtn

            pickFloor.SelectedIndex = 0;//set default combobox selection
            resGuestsTxt.SelectedIndex = 0;
            //dateFromPick.MinDate = DateTime.Today; //set datetimepicker min 
            //dateToPick.MinDate = DateTime.Now.AddDays(1); //set datetimepicker min 

            //for time labels
            time.Tick += new EventHandler(timer1_Tick);
            time.Enabled = true;
            time.Start();
            //FormBorderStyle = FormBorderStyle.None; //maximize window no task bar
            /*
             * date and time pickers and formatting
             */
            dateFromPick.Format = DateTimePickerFormat.Custom;
            dateFromPick.CustomFormat = "ddd, MMM dd yyyy";
            dateToPick.Format = DateTimePickerFormat.Custom;
            dateToPick.CustomFormat = "ddd, MMM dd yyyy";
            dateToPick.Value = DateTime.Today.AddDays(1);//set to picker to 1 day ahead
            setTabsDiss();
            passTxt.PasswordChar = '\u25CF';//make password textbox echo circle char to hide password

            //add manager to arraylist for testing
            addToArrayListX(employees, "Admin", "Admin", "admin", "admin");//manager
            addToArrayListY(employees, "Admin2", "Admin2", "admin2", "admin2");//reg. staff
            addToArrayListX(employees, "Thomas", "Ward", "tward1", "tomw84");

            //FOR TESTING customers
            customers.Add(new Customer("Thomas", "Cummings", "1503 E PArk ave", "Valdosta", "GA",
              "31602", "5052030822", "5052030822", "@gmail.com", "This guy is a jerk!"));
            customers.Add(new Customer("Janai", "Germany", "4400 Washington ST NE", "Albuquerque", "NM",
              "87109", "5059676521", "", "@gmail.com", "Poop Butt!"));
            customers.Add(new Customer("Heather", "Cummings", "1503 E PArk ave", "Valdosta", "GA",
              "31602", "5052030822", "5052030822", "@gmail.com"));
            customers.Add(new Customer("Heather", "Ward", "1503 E PArk ave", "Valdosta", "GA",
              "31602", "5052030822", "5052030822", "@gmail.com"));
            customers.Add(new Customer("Thomas", "Ward", "225 westmin", "Atlanta", "GA",
              "55142", "5552224444", "4446662205", "@ymail.com"));
            customers.Add(new Customer("Thomas", "West", "225 Orange", "Spring hill", "FL",
              "55141", "5552224444", "4446662205", "@ymail.com"));
            customers.Add(new Customer("Le'Don", "Sapp", "225 Cherry Tree", "Orlando", "FL",
              "22654", "5552224444", "4446662205", "@ymail.com", "CS student at VSU"));
            customers.Add(new Customer("Deborha", "Stone", "225 Tech", "Valtech", "GA",
              "55154", "5552224444", "4446662205", "@ymail.com"));
            customers.Add(new Customer("Judy", "M", "25 Western trail", "Tijeras", "NM",
              "87124", "5552224444", "4446662205", "@gmail.com"));
            customers.Add(new Customer("Travis", "DeMateo", "1515 butter st", "Spring hill", "NY",
              "00118", "5552224444", "4446662205", "@gmail.com"));
            customers.Add(new Customer("Thomas", "Cummings", "2401 Lema", "Rio Rancho", "NM",
              "87124", "5052030822", "5052030822", "@gmail.com", "Dad"));
            customers.Add(new Customer("Thomas", "Cummings", "2598 Bell Ave", "Jersy City", "NJ",
              "55155", "5052030822", "5052030822", "@gmail.com"));

            //Rooms for testing
            //Floor 1
            for (int i = 0; i < 10; i++)
            {
                floor1.Add(new Room("Standard", "Queen", 1, true, 80.00));
            }
            for (int i = 0; i < 20; i++)
            {
                floor1.Add(new Room("Standard", "Queen", 2, true, 90.00));
            }
            for (int i = 0; i < 15; i++)
            {
                floor1.Add(new Room("Delux", "Queen", 1, true, 82.95));
            }
            for (int i = 0; i < 10; i++)
            {
                floor1.Add(new Room("Standard", "Double", 2, true, 82.95));
            }
            for (int i = 0; i < 10; i++)
            {
                floor1.Add(new Room("Delux", "Queen", 2, true, 88.95));
            }
            for (int i = 0; i < 10; i++)
            {
                floor1.Add(new Room("Delux", "King", 2, true, 88.95));
            }
            for (int i = 0; i < 5; i++)
            {
                floor1.Add(new Room("Delux Office", "Queen", 1, true, 112.95));
            }
            //Floor 2
            for (int i = 0; i < 5; i++)
            {
                floor2.Add(new Room("Standard", "Queen", 1, true, 80.00));
            }
            for (int i = 0; i < 5; i++)
            {
                floor2.Add(new Room("Standard", "Queen", 2, true, 90.00));
            }
            for (int i = 0; i < 5; i++)
            {
                floor2.Add(new Room("Delux", "Queen", 1, true, 82.95));
            }
            for (int i = 0; i < 5; i++)
            {
                floor2.Add(new Room("Standard", "Double", 2, true, 82.95));
            }
            for (int i = 0; i < 5; i++)
            {
                floor2.Add(new Room("Delux", "Queen", 2, true, 88.95));
            }
            for (int i = 0; i < 5; i++)
            {
                floor2.Add(new Room("Delux", "King", 2, true, 88.95));
            }
        }//end form1
        private void Form1_Load(object sender, EventArgs e)//when form loads do this
        {
            //set unsername field to be selected on load
            usernameTxt.Focus();
            custFNameTxt.TextChanged += new EventHandler(custFNameTxt_TextChanged);
        }

        // Time display and set format
        private void timer1_Tick(object sender, EventArgs e)//for time timer
        {
            this.date3.Text = DateTime.Now.ToString("d/M/yyyy\r\nh:mm:ss tt");
            this.date2.Text = DateTime.Now.ToString("d/M/yyyy\r\nh:mm:ss tt");
            this.date.Text = DateTime.Now.ToString("d/M/yyyy\r\nh:mm:ss tt");
            this.date4.Text = DateTime.Now.ToString("d/M/yyyy\r\nh:mm:ss tt");
            this.date5.Text = DateTime.Now.ToString("d/M/yyyy\r\nh:mm:ss tt");
            this.date6.Text = DateTime.Now.ToString("d/M/yyyy\r\nh:mm:ss tt");
            this.date7.Text = DateTime.Now.ToString("d/M/yyyy\r\nh:mm:ss tt");
        }


        //methods for payment options when cliked (Views)
        private void credit_payment_CheckedChanged(object sender, EventArgs e)
        {
            if (credit_payment.Checked == true)
            {
                credit_info.Visible = true;
                check_info.Visible = false;
            }
        }
        private void check_payment_CheckedChanged(object sender, EventArgs e)
        {
            if (check_payment.Checked == true)
            {
                credit_info.Visible = false;
                check_info.Visible = true;
            }
        }
        private void cash_payment_CheckedChanged(object sender, EventArgs e)
        {
            if (cash_payment.Checked == true)
            {
                credit_info.Visible = false;
                check_info.Visible = false;
            }
        }


        //managers tools for window control
        private void exitProgram_Click(object sender, EventArgs e)      //exit program
        {
            this.Close();
        }
        private void exitFullScreen_Click(object sender, EventArgs e)   //exit full screen
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
        }
        private void fullScreen_Click(object sender, EventArgs e)       //re-enable full screen
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }//end manager tools section

        private void addCustomerBtn_Click(object sender, EventArgs e)// add customer BTN
        {
            //get data from textboxes and other fields then add customer with them
            if (!string.IsNullOrEmpty(custNotesTxt.Text))//if notes field is not empty use constructor w/ notes
                customers.Add(new Customer(custFNameTxt.Text, custLNameTxt.Text, custStAddTxt.Text, custCityTxt.Text, custStateComBox.Text,
                    custZipTxt.Text, custHPhoneTxt.Text, custMPhoneTxt.Text, custEmailTxt.Text, custNotesTxt.Text));
            else
                customers.Add(new Customer(custFNameTxt.Text, custLNameTxt.Text, custStAddTxt.Text, custCityTxt.Text, custStateComBox.Text,
                    custZipTxt.Text, custHPhoneTxt.Text, custMPhoneTxt.Text, custEmailTxt.Text));

            //clear fields after adding customer
            custFNameTxt.Clear();
            custLNameTxt.Clear();
            custStAddTxt.Clear();
            custCityTxt.Clear();
            custStateComBox.SelectedIndex = -1;
            custZipTxt.Clear();
            custHPhoneTxt.Clear();
            custMPhoneTxt.Clear();
            custEmailTxt.Clear();
            //add if notes != null clear
        }//end add customer Btn method

        //method for authentication to access the program (starting point of program)
        private void authenticate()
        {
            foreach (Employee em in employees)//iterate through employee list
            {
                if (current_login.ToString().Equals(em.Username) && pass.ToString().Equals(em.Password))
                {
                    //if username and password is in list
                    found = true;
                    //set current employee object
                    currentEmp = em;
                    //return true;
                    displayCurrentLogin();
                    empViews();
                    empControl.SelectedTab = customerTab;// change tabs
                }
            }//end foreach loop
               if (!found) //if login is invalid 
               {
                        login_count--;//count down to lockout
                        if (login_count >= 2 || login_count == 1)//show tries (user warning)
                        {
                            MessageBox.Show("You have " + login_count + " tries");
                            current_login.Clear();//clear old text for username
                        }
                        else if (login_count <= 0)//invalid login lock out/////////////////////////
                        {
                            MessageBox.Show("You have excited your login attempts please restart and try again" +
                                            "\r\nYou will be unable to login for 1 minute(s)");
                            passTxt.Enabled = false;
                            usernameTxt.Enabled = false;
                            loginBtn.Enabled = false;
                            logoutBtn.Enabled = false;
                            EndOfTime = DateTime.Now.AddMinutes(5);//set time to 5 min from systime
                            lockoutTimer.Tick += new EventHandler(lockoutTimer_Tick);
                            lockoutTimer.Enabled = true;
                            lockoutTimer.Start();
                        }//end lock out if statement
               }//end if not found block 
        }//end authentication

        public void displayCurrentLogin()//display the currently logged in employee
        {
            MessageBox.Show("Welcome: " + currentEmp.F_name + " " + currentEmp.L_name);
                currentEmpLabel1.Text = "Logged in as: " + currentEmp.Username;
                currentEmpLabel2.Text = "Logged in as: " + currentEmp.Username;
                currentEmpLabel3.Text = "Logged in as: " + currentEmp.Username;
                currentEmpLabel4.Text = "Logged in as: " + currentEmp.Username;
                currentEmpLabel5.Text = "Logged in as: " + currentEmp.Username;
                currentEmpLabel6.Text = "Logged in as: " + currentEmp.Username;
        }//end display currently logged in employee

        //methods for adding Managers to employee arraylist FOR TESTING (managers add emps only)
        public void addToArrayListX(ICollection<Employee> employees, string fname, string lname)
        {
            employees.Add(new Manager(fname, lname));
        }
        public void addToArrayListX(ICollection<Employee> employees, string fname, string lname, string username, string pass)
        {
            employees.Add(new Manager(fname, lname, username, pass));
        }
        public void addToArrayListY(ICollection<Employee> employees, string fname, string lname, string username, string pass)
        {
            employees.Add(new Staff(fname, lname, username, pass));
        }
        private void loginBtn_Click(object sender, EventArgs e)//login to the program
        {
            if (!string.IsNullOrEmpty(usernameTxt.Text) && !string.IsNullOrEmpty(passTxt.Text))
            {
                //on click get text from username and password fields
                current_login.Append(usernameTxt.Text);
                pass = passTxt.Text;
                authenticate();//validate user credentals
                //clear textboxes
                passTxt.Clear();
                usernameTxt.Clear();
                usernameTxt.Focus();//reset tab field focus 
            }
            else if (string.IsNullOrEmpty(usernameTxt.Text) && !string.IsNullOrEmpty(passTxt.Text))
                MessageBox.Show("Missing Username ");
            else if (string.IsNullOrEmpty(passTxt.Text) && !string.IsNullOrEmpty(usernameTxt.Text))
                MessageBox.Show("Missing Password ");
            else if (string.IsNullOrEmpty(usernameTxt.Text) && string.IsNullOrEmpty(passTxt.Text))
                MessageBox.Show("Missing both Username and Password");
        }//end login btn click

        //depending on the type of employee control is different
        private void empViews()//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Log-In
        {
            if (currentEmp is Manager)//managers have more control
            {
                paymntTab.Enabled = true;
                customerTab.Enabled = true;
                roomsTab.Enabled = true;
                managmentControlTab.Enabled = true;
                managmentControl.Visible = true;
            }
            else // staff, less control
            {
                paymntTab.Enabled = true;
                customerTab.Enabled = true;
                roomsTab.Enabled = true;
                managmentControl.Visible = false;
            }
        }//end empView method

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(      //set messagebox to result for switch
            "Are you sure you want to logout", // the message to show
            "Logout",                          // the title for the dialog box
            MessageBoxButtons.YesNo,          // show two buttons: Yes and No
            MessageBoxIcon.Question);         // show a question mark icon
            switch (result)
            {
                case DialogResult.Yes:   // Yes button pressed
                    MessageBox.Show(current_login + " Now logged out");//let user know they have looged out
                    //reset all data fields
                    pass = "";
                    current_login.Clear();
                    login_count = 3;
                    found = false;
                    setTabsDiss();
                    break;
                case DialogResult.No:    // No button pressed
                    break;
                default:                 // Neither Yes nor No pressed (just in case)
                    MessageBox.Show("?");
                    break;
            }
        }//end logout btn click

        private void setTabsDiss()//make tabs so that no one can access (dissable)
        {
            paymntTab.Enabled = false;
            customerTab.Enabled = false;
            roomsTab.Enabled = false;
            managmentControlTab.Enabled = false;
        }//end set tabs to dissabled method

        private void logInTab_Click(object sender, EventArgs e)
        {
            usernameTxt.Select();
            //usernameTxt.Focus();
            //ActiveControl = usernameTxt;
        }

        //invalid user credentals lockout timer
        private void lockoutTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = EndOfTime.Subtract(DateTime.Now);//counter for time spent
            if (ts.TotalMinutes <= 0)
                lockoutTimer.Enabled = false;//stop timer
            //reset textboxes and buttons
            passTxt.Enabled = true;
            usernameTxt.Enabled = true;
            loginBtn.Enabled = true;
            logoutBtn.Enabled = true;
            //reset data fields
            pass = "";
            current_login.Clear();
            login_count = 3;
            usernameTxt.Focus();
        }//end lockout timer


        /*
        *  Search by first name when text box contents changed 
        * 
        */
        private void custFNameTxt_TextChanged(object sender, EventArgs e)
        {
            searched.Clear();
            custSearchList.Text = String.Empty;
            searchFirstName(custFNameTxt, customers);//search first name make searched list
            custSearchList.Clear();
            custSearchList.Text = String.Empty;
            foreach (Customer custs in searched)
            {
                altRowColor(searched, custSearchList);//iterate throught list alt row color
            }
            altCust = 0;//reset altCust to avoid errors
        }// end text changed for first name

        /*
         *  Search by last name when text box contents changed 
         * 
         */
        private void custLNameTxt_TextChanged(object sender, EventArgs e)
        {

        }// end text changed for last name


        private void searchCustomerBtn_Click(object sender, EventArgs e) //search customer BTN
        {
            custSearchList.Clear();//clear last searched customers from textbox results
            searched.Clear();//clear searched list
            if (!string.IsNullOrEmpty(custIdTxt.Text))//search by id
            {
                //custSearchList.Clear();//clear last searched customers
                seachCustId();
            }

            else if (!string.IsNullOrEmpty(custFNameTxt.Text) && string.IsNullOrEmpty(custIdTxt.Text) ||
                !string.IsNullOrEmpty(custLNameTxt.Text) && !string.IsNullOrEmpty(custFNameTxt.Text) ||
                string.IsNullOrEmpty(custLNameTxt.Text) && !string.IsNullOrEmpty(custFNameTxt.Text)) 
            {
                searchFirstName(custFNameTxt, customers);//search first name make searched list
                custSearchList.Clear();
                foreach (Customer custs in searched)
                {
                    altRowColor(searched, custSearchList);//iterate throught list alt row color
                }
                altCust = 0;//reset altCust to avoid errors
                if (!string.IsNullOrEmpty(custFNameTxt.Text) && !string.IsNullOrEmpty(custLNameTxt.Text))//Narrow down the search
                {
                    narrowByLast();//narrow method
                    custSearchList.Clear();//clear text
                    foreach (Customer custs in searched)
                    {
                        altRowColor(searched, custSearchList);//iterate throught list alt row color
                    }
                    altCust = 0;//reset altCust to avoid errors
                }
            }
            else if (!string.IsNullOrEmpty(custLNameTxt.Text) && string.IsNullOrEmpty(custFNameTxt.Text))//search by last name
            {
                searched.Clear();//clear searched list
                custSearchList.Clear();//clear text
                searchLastName();//search last name make searched list
                foreach (Customer custs in searched)
                {
                    altRowColor(searched, custSearchList);//iterate throught list alt row color
                }
                altCust = 0;//reset altCust to avoid errors
            }//end if full lastname search
        }//end search BTN

        private void custResRoomBtn_Click(object sender, EventArgs e) //reserve room with current customer fields BTN
        {
            if (currentCust != null)// if a current customer is selected send cust info to res tab fields
            {
                resCustIdTxt.Text = currentCust.Cust_id.ToString();
                resCustFNameTxt.Text = currentCust.F_name;
                resCustLNameTxt.Text = currentCust.L_name;
                empControl.SelectedTab = roomsTab;
            }
            else
                MessageBox.Show("No current customer selected");
        }

        private void updateCustNoteBtn_Click(object sender, EventArgs e) //update customer notes BTN
        {
            /*ADD universal update (able to update all customer fields)
             * messagebox to confirm old to new update
             * if textbox != currentCust.field messagebox
             * if not cancel and reset textbox
             * else change customer
            */
            if (currentCust != null && custNotesTxt.Text.Length != 0)
            {
                currentCust.Note = custNotesTxt.Text;
                MessageBox.Show("Note for " + currentCust.F_name + " " + currentCust.L_name + " Updated");
            }
            else if (custNotesTxt.Text.Length == 0 && currentCust != null)
                MessageBox.Show("No text entered in notes area");
            else
                MessageBox.Show("No current customer selected");
        }//end update method
        private void custClearBtn_Click(object sender, EventArgs e) //clear customer form fields BTN
        {
            custIdTxt.Clear();
            custFNameTxt.Clear();
            custLNameTxt.Clear(); 
            custStAddTxt.Clear(); 
            custCityTxt.Clear(); 
            custStateComBox.SelectedIndex = -1;
            custZipTxt.Clear(); 
            custHPhoneTxt.Clear(); 
            custMPhoneTxt.Clear(); 
            custEmailTxt.Clear();
            custNotesTxt.Clear();
            custResNumTxt.Clear();
            currentCust = null;
        }

        private void custResLookupBtn_Click(object sender, EventArgs e) //look up customer reservation BTN
        {
            if (currentCust != null)//check to see if a current customer is selected
            {
                if (currentCust.IsReservation != false) //if current customer has a reservation send info to reservation tab
                {
                    custResNumTxt.Text = currentCust.ReservationNum.ToString();//send cust res num to cust txt field
                    //send reservation info to rooms tab
                    resCustIdTxt.Text = currentCust.City;
                    resCustFNameTxt.Text = currentCust.F_name;
                    resCustLNameTxt.Text = currentCust.L_name;
                    //empControl.SelectedTab = roomsTab;
                }
                else if (currentCust.IsReservation == false) //if current customer does not have a reservation
                    MessageBox.Show("Customer does not have a reservation");
            }
            else
                MessageBox.Show("No customer selected");//if no current customer selected message
        }//end customer lookup BTN method



        /*
         * methods for searching customers
         * would like to try to implement a search while you type filter (passive search, no button)
         * on key events when textbox text changes re-search
         */
        /**
         * create a search method that takes a string to search (searchFor) in the list
         * try to match the string
         * set keypress for textbox each time you type it searches the listfor matches
         * narrowing down list of searched
         * Search char by char with substring
         **/
        private void searchFirstName<T>(Control textBox, List<T> list)//method to search customers by first name
        {
            if (list.GetType() == typeof(List<Customer>))
            {
                searchForThis = (textBox as TextBox).Text.ToUpper().Trim().ToString();
                for (int i = 0; i < customers.Count -1; i++)
                {
                    searchThis = customers[i].F_name.ToUpper().Trim();
                    string searchThis2 = new string(searchThis.Take(searchForThis.Length).ToArray());

                    if (searchThis2 == searchForThis)
                    {
                        searched.Add(customers[i]);
                    }
                }//end for loop
            }//end if type of customer
            else if (list.GetType() == typeof(List<Employee>))
            {
                searchForThis = (textBox as TextBox).Text.ToUpper();
                for (int i = 0; i < employees.Count -1; i++)
                {
                    searchThis = employees[i].F_name.ToUpper().Substring(0, searchForThis.Length);
                    if (searchThis.Equals(searchForThis))
                    {
                        //Add to list
                        searched2.Add(employees[i]);
                        //Console.WriteLine("found");//TESTING
                    }
                }//end for loop
            }//end if type of employee
        }//end search by first name method

        private void searchLastName<T>(Control textBox, List<T> list)//method to search customers by first name
        {
            if (list.GetType() == typeof(List<Customer>))
            {
                searchForThis = (textBox as TextBox).Text.ToUpper().Trim().ToString();
                for (int i = 0; i < customers.Count - 1; i++)
                {
                    searchThis = customers[i].L_name.ToUpper().Trim();
                    string searchThis2 = new string(searchThis.Take(searchForThis.Length).ToArray());

                    if (searchThis2 == searchForThis)
                    {
                        searched.Add(customers[i]);
                    }
                }//end for loop
            }//end if type of customer
            else if (list.GetType() == typeof(List<Employee>))
            {
                searchForThis = (textBox as TextBox).Text.ToUpper();
                for (int i = 0; i < employees.Count - 1; i++)
                {
                    searchThis = employees[i].L_name.ToUpper().Substring(0, searchForThis.Length);
                    if (searchThis.Equals(searchForThis))
                    {
                        //Add to list
                        searched2.Add(employees[i]);
                        //Console.WriteLine("found");//TESTING
                    }
                }//end for loop
            }//end if type of employee
        }//end search by last name method



        private void searchLastName()//method to search customers by last name
        {
            searchForThis = custLNameTxt.Text.ToUpper();
            for (int i = 0; i < customers.Count; i++)
            {
                searchThis = customers[i].L_name.ToUpper();
                //change to substring to search
                if (searchThis.Equals(searchForThis))
                {
                    //Add to list
                    searched.Add(customers[i]);
                }
            }//end for loop
            if (searchThis.Length > 1 && !searchThis.Equals(searchForThis))//if not found 
                MessageBox.Show("No customer found");
        }//end search by last name method


        private void narrowByLast<T>(Control textBox, List<T> list)//narrow results by lastname
        {

            if (list.GetType() == typeof(List<Customer>))
            {
                searchForThis = (textBox as TextBox).Text.ToUpper().Trim().ToString();
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < searched.Count; i++)
                    {
                        searchThis = searched[i].L_name.ToUpper().Substring(0, searchForThis.Length);
                        string searchThis2 = new string(searchThis.Take(searchForThis.Length).ToArray());
                        if (!searchForThis.Equals(searchThis2))
                        {
                            //remove from list
                            searched.RemoveAt(i);
                        }
                    }//end inner loop
                }//end outter loop
            }//end if type of customer

            else if (list.GetType() == typeof(List<Employee>))
            {
                searchForThis = (textBox as TextBox).Text.ToUpper().Trim().ToString();
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < searched2.Count; i++)
                    {
                        searchThis = searched2[i].L_name.ToUpper().Substring(0, searchForThis.Length);
                        string searchThis2 = new string(searchThis.Take(searchForThis.Length).ToArray());
                        if (!searchForThis.Equals(searchThis2))
                        {
                            //remove from list
                            searched2.RemoveAt(i);
                        }
                    }//end inner loop
                }//end outter loop
            }//end if type of employee

        }//end narrow search

        private void narrowByLast()//narrow results by lastname
        {
            searchForThis = custLNameTxt.Text.ToUpper();
            
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < searched.Count; i++)
                {
                    searchThis = searched[i].L_name.ToUpper().Substring(0, searchForThis.Length);
                    if (!searchThis.Equals(searchForThis))
                    {
                        //remove from list
                        //Console.WriteLine("Remove " + searchedCusts[i].L_name);//TESTING
                        searched.RemoveAt(i);
                    }
                }//end inner loop
            }//end outter loop
        }//end narrow search





        private void seachCustId()//search by cust id
        {
            // add bool for found or not
            foreach (Customer cust in customers)
            {
                if (Convert.ToInt64(custIdTxt.Text) == cust.Cust_id)
                {
                    custIdTxt.Text = cust.Cust_id.ToString();
                    custFNameTxt.Text = cust.F_name;
                    custLNameTxt.Text = cust.L_name;
                    custStAddTxt.Text = cust.Address;
                    custCityTxt.Text = cust.City;
                    custStateComBox.Text = cust.St;
                    custZipTxt.Text = cust.Zip;
                    custHPhoneTxt.Text = cust.H_number;
                    custMPhoneTxt.Text = cust.M_number;
                    custEmailTxt.Text = cust.Email;
                    custNotesTxt.Text = cust.Note;
                    currentCust = cust;// set current customer
                    if (currentCust.IsReservation != false)//check if cust has a reservation, if so add text o field
                        custResNumTxt.Text = currentCust.ReservationNum.ToString();
                    if (currentCust.Note != null)//check if cust has a note, if so add text o field
                        custNotesTxt.Text = currentCust.Note;
                }//end if statement
            }//end for loop
        }//end search customer by id method
        private void altRowColor<T>(List<T> searched, Control c)//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< view any array in any Richtextbox with alt colors
        {
            (c as RichTextBox).SelectionBackColor = Color.White;//set default background
            while (altCust < searched.Count) // keep going till end of list
            {
                if (altCust % 2 == 0) //everyother cust color = light gray
                {
                    (c as RichTextBox).SelectionBackColor = Color.LightGray;
                }
                break;// to brake up text
            }
            (c as RichTextBox).SelectedText += Environment.NewLine + searched[altCust];//add text to textbox
            altCust++;//increment altcust
        }//end view all method

        private void viewAllCustBtn_Click(object sender, EventArgs e)//View all customers
        {
            custSearchList.Clear();//clear textbox
            /*searchedCusts.Clear();
            searchedCusts = customers.GetRange(0, customers.Count);//copy customers list to searched*/
            foreach (Customer custs in customers)
            {
                altRowColor(customers, custSearchList);
            }
            altCust = 0;//reset altCust to avoid errors
        }
        private void pickFloor_SelectedIndexChanged(object sender, EventArgs e)//change floors, send rooms to buttons
        {
            floor = Convert.ToInt16(pickFloor.SelectedItem);
            switch (floor)
            {
                case 1:
                    f1Labels();
                    break;
                case 2:
                    f2Labels();
                    break;
                case 3:
                    f3Labels();
                    break;
                case 4:
                    f4Labels();
                    break;
                default:                 
                    break;
            }
        }
        //add labels to room buttons
        private void f1Labels()
        {

            for (int i = 0; i < roomBtn.Length; i++)
            {
                roomBtn[i].Text = (i + 1).ToString();
            }
            
        }
        private void f2Labels()
        {
            int index = 81;
            for (int i = 0; i < roomBtn.Length; i++)
            {
                roomBtn[i].Text = (index).ToString();
                //Console.WriteLine(index.ToString()); TESTING
                index++;
            }
        }
        private void f3Labels()
        {
            int index = 161;
            for (int i = 0; i < roomBtn.Length; i++)
            {
                roomBtn[i].Text = (index).ToString();
                index++;
            }
        }
        private void f4Labels()
        {
            int index = 241;
            for (int i = 0; i < roomBtn.Length; i++)
            {
                roomBtn[i].Text = (index).ToString();
                index++; 
            }
        }
        //link room buttons to room set btn background to red if not available
        /*private void roomBtnColor()//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            for (int i = 0; i < roomBtn.Length; i++)
            {
                if (selectedRoom.Available == false)
                {
                    roomBtn[i].BackColor = Color.Red;
                }
            }
        }*/
        private void roomBtn_Click(object sender, EventArgs e)//room buttons event
        {
            Button btn = sender as Button;//creat object from seneder
            if (floor == 1)
            {
                foreach (Room room in floor1)
                {
                    if (btn.Text.Equals(room.Room_number.ToString()))//check sending objects field
                    {
                        roomInfoTxt.Text = room.ToString();//send room info to textbox
                        selectedRoom = room;//set currently selected room
                        resRoomTxt.Text = selectedRoom.Room_number.ToString();//display room info
                    }
                }
            }
            else if (floor == 2)
            {
                foreach (Room room in floor2)
                {
                    if (btn.Text.Equals(room.Room_number.ToString()))
                    {
                        roomInfoTxt.Text = room.ToString();
                        selectedRoom = room;
                        resRoomTxt.Text = selectedRoom.Room_number.ToString();
                    }
                }
            }
            else if (floor == 3)
            {
                foreach (Room room in floor3)
                {
                    if (btn.Text.Equals(room.Room_number.ToString()))
                    {
                        roomInfoTxt.Text = room.ToString();
                        selectedRoom = room;
                        resRoomTxt.Text = selectedRoom.Room_number.ToString();
                    }
                }
            }
            else if (floor == 4)
            {
                foreach (Room room in floor4)
                {
                    if (btn.Text.Equals(room.Room_number.ToString()))
                    {
                        roomInfoTxt.Text = room.ToString();
                        selectedRoom = room;
                        resRoomTxt.Text = selectedRoom.Room_number.ToString();
                    }
                }
            }
            else
                MessageBox.Show("no go");
        }

        private void addButtons()//add Room buttons to roomsgroup control (dynamicly add)
        {
            //start x,y locations
             int start_x = 5;
             int start_y = 20;
            //size of btns
             int width = 34;
             int height = 23;
             for (int i = 0; i < roomBtn.Length; i++)//loop to add btn to array, set event, setsize,loc,
                                                     // add to group and display
             {
                 roomBtn[i] = new Button();
                 roomBtn[i].Click += new System.EventHandler(this.roomBtn_Click);//add event to all buttons
                 roomBtn[i].Size = new Size(width, height);
                 roomBtn[i].Location = new Point(start_x, start_y);
                 roomsGroup.Controls.Add(roomBtn[i]);
                 start_x += 39;
                 if (i == 9 || i == 19 || i == 29 || i == 39 || i == 49 || i == 59 || i == 69
                     || i == 79)
                 {
                     start_y += 30;//move row down
                     start_x = 5;//reset x
                 }
             }
        }//end add buttons method
        //=======================================================
        //=======================================================>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Rooms/reservation tab

        private void resRoomBtn_Click(object sender, EventArgs e)// Reserve room button
        {
            //get dates
            from = dateFromPick.Value.Date;
            to = dateToPick.Value.Date;
            //get amount of guests
            guests = int.Parse(resGuestsTxt.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(resRoomTxt.Text))
            {
                if (currentCust != null)// if a customer is selected
                {
                    //add if statements to restrict out of bounds dates
                    if (!(from >= DateTime.Today))
                    {
                        MessageBox.Show("Cannot reserve a room's start date that is less than Today's date");
                    }
                    else if (!(to > from))
                    {
                        MessageBox.Show("Cannot reserve a room's end date that is less than the start date");
                    }
                    else if (from >= DateTime.Today || to > from)
                    {
                        //use constructor with wake up call
                        if (wakeUpCall.Checked)
                        {
                            currentCust.tempReser(currentCust, selectedRoom, guests, from, to,
                                wakeUpCall.Checked, wakUpCallHour.SelectedItem.ToString(), wakeUpCallMin.SelectedItem.ToString(),
                                WakeUpCallAmPm.SelectedItem.ToString(), resVMakeTxt.Text, resVModTxt.Text, resVPlateTxt.Text);
                        }
                        else//reg. constructor
                            currentCust.tempReser(currentCust, selectedRoom, guests, from, to, 
                                resVMakeTxt.Text, resVModTxt.Text, resVPlateTxt.Text);
                        selectedRoom.Available = false;
                        roomInfoTxt.Text = selectedRoom.ToString();//refresh room text box
                        String message = "Confirm Reservation : \r\n" + currentCust.TempRes.Message();

                        var result = MessageBox.Show(        //set messagebox to result for switch
                        message,                            // message
                        "Logout",                          // the title for the dialog box
                        MessageBoxButtons.YesNo,          // show two buttons: Yes and No
                        MessageBoxIcon.Question);        // show a question mark icon
                        switch (result)
                        {
                            case DialogResult.Yes:   // Yes button pressed
                                currentCust.makeReservation();
                                MessageBox.Show("Reservation for " + currentCust.F_name + " " + currentCust.L_name + " created" +
                                            "\r\n" + currentCust.res[currentCust.res.Count - 1].Message());
                                resNumTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].Res_Id.ToString();//display reservation num
                                break;
                            case DialogResult.No:    // No button pressed
                                selectedRoom.Available = true;//set room to available
                                roomInfoTxt.Text = selectedRoom.ToString();//refresh room text box
                                currentCust.IsReservation = false;// remove the reservation bool from customer
                                //res_counter = res_counter - 1;
                                Reservation.Res_Counter = Reservation.Res_Counter -1;//make sure counter does not count a reservation that was not made
                                break;
                            default:                 // Neither Yes nor No pressed (just in case)
                                MessageBox.Show("?");
                                break;
                        }
                    }
                }
                else
                    MessageBox.Show("No current customer selected");
            }
            else
                MessageBox.Show("No Room selected");
        }

        private void resLookUpBtn_Click(object sender, EventArgs e)//<<<<<<<<<<<<<<<<<< Look up customer reservation
        {
            if (currentCust != null && checkForCust())
            {
                if (currentCust.IsReservation)
                {
                    //populate fields
                    //resNumTxt.Text = currentCust.ReservationNum.ToString();
                    resNumTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].Res_Id.ToString();
                    resCustFNameTxt.Text = currentCust.F_name;
                    resCustLNameTxt.Text = currentCust.L_name;
                    //get current cust res info then populate it
                    resRoomTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].Room.Room_number.ToString();
                    dateFromPick.Value = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].From;
                    dateToPick.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].To.ToString();
                    resVMakeTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].VMake;
                    resVModTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].VMod;
                    resVPlateTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].VPlate;
                    wakUpCallHour.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].WakeHour;
                    wakeUpCallMin.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].WakeMin;
                    WakeUpCallAmPm.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].WakeState;
                    wakeUpCall.Checked = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].WakeUp;
                }
                else
                    MessageBox.Show(currentCust.F_name + " " + currentCust.L_name +
                        " does not have reservation");
            }
            else if (currentCust == null && !string.IsNullOrEmpty(resCustIdTxt.Text)) // if no customer is seleced search for customer with cust_id on room tab
            {
                foreach (Customer cust in customers)
                {
                    if (Convert.ToInt64(resCustIdTxt.Text) == cust.Cust_id)
                    {
                        custIdTxt.Text = cust.Cust_id.ToString();
                        custFNameTxt.Text = cust.F_name;
                        custLNameTxt.Text = cust.L_name;
                        custStAddTxt.Text = cust.Address;
                        custCityTxt.Text = cust.City;
                        custStateComBox.Text = cust.St;
                        custZipTxt.Text = cust.Zip;
                        custHPhoneTxt.Text = cust.H_number;
                        custMPhoneTxt.Text = cust.M_number;
                        custEmailTxt.Text = cust.Email;
                        custNotesTxt.Text = cust.Note;
                        currentCust = cust;// set current customer
                        if (currentCust.IsReservation != false)//check if cust has a reservation, if so add text o field
                            custResNumTxt.Text = currentCust.ReservationNum.ToString();
                        if (currentCust.Note != null)//check if cust has a note, if so add text o field
                            custNotesTxt.Text = currentCust.Note;
                    }//end if statement
                }
                if (currentCust.IsReservation)
                {
                    //populate fields
                    //resNumTxt.Text = currentCust.ReservationNum.ToString();
                    resNumTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].Res_Id.ToString();
                    resCustFNameTxt.Text = currentCust.F_name;
                    resCustLNameTxt.Text = currentCust.L_name;
                    resRoomTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].Room.Room_number.ToString();
                    dateFromPick.Value = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].From;
                    dateToPick.Value = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].To;
                    resVMakeTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].VMake;
                    resVModTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].VMod;
                    resVPlateTxt.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].VPlate;
                    wakUpCallHour.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].WakeHour;
                    wakeUpCallMin.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].WakeMin;
                    WakeUpCallAmPm.Text = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].WakeState;
                    wakeUpCall.Checked = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].WakeUp;
                }
            }//end else if currentCust == null
            else
                MessageBox.Show("No customer selected");
        }

        private void cansResBtn_Click(object sender, EventArgs e)
        {
            if (currentCust != null)
            {
                //cancel reservation unless customer has paid then ask for a manager
                if (currentCust.IsReservation)
                {
 
                }
                else
                    MessageBox.Show(currentCust.F_name + " " + currentCust.L_name +
                        " does not have reservation");
            }
            else
                MessageBox.Show("No current customer selected");
        }

        private void resClearBtn_Click(object sender, EventArgs e)//clear all fields in reservation text areas
        {
            resNumTxt.Clear();
            resCustIdTxt.Clear();
            resCustFNameTxt.Clear();
            resCustLNameTxt.Clear();
            wakUpCallHour.SelectedIndex = -1;
            wakeUpCallMin.SelectedIndex = - 1;
            WakeUpCallAmPm.SelectedIndex = -1;
            resGuestsTxt.SelectedIndex = 0;
            resRoomTxt.Clear();
            resPaymentIdTxt.Clear();
            resVMakeTxt.Clear();
            resVModTxt.Clear();
            resVPlateTxt.Clear();
            currentCust = null;
        }

        private void resMkPaymntBtn_Click(object sender, EventArgs e)//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< send payment info from reservation
        {
            if (currentCust != null)
            {
                if (currentCust.IsReservation)
                {
                    //change tab
                    empControl.SelectedTab = paymntTab;
                    //send payment info over to fields (room rate, ect..)
                    subTotal = currentCust.res[currentCust.searchResCustID((int)currentCust.Cust_id)].Room.Price_per_night;
                    TAX = Payment.Tax;
                    salesTax = (subTotal * TAX);
                    pmntSubtotalTxt.Text = subTotal.ToString();
                    pmntSalesTaxTxt.Text = string.Format("{0:0.00}", salesTax);
                    pmntGrandTotalTxt.Text = string.Format("{0:0.00}", (subTotal + salesTax));
                }
                else
                    MessageBox.Show("Customer does not have a reservation to pay");
            }
            else
                MessageBox.Show("No customer selected");
        }
        private bool checkForCust()//used to check for customer when reserving
        {
             bool isHere = false;
             foreach (Customer cust in customers)
             {
                 if (Convert.ToInt64(resCustIdTxt.Text) == cust.Cust_id)
                 {
                     isHere = true;
                 }
             }
             return isHere;
        }
        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Payment tab
         * <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
         */
        private void paymentBtn_Click(object sender, EventArgs e)// make payment button
        {
            /* Get grand total and make a paymrnt obj in current cust
             * Then send grandtotal to current emp sales to keep track
             * calculate if you need more payment or change due
             * 
             */
            if (currentCust != null)//check to see if a customer is seleceted
            {
                if (currentCust.IsReservation)
                {
                    currentCust.payment((subTotal + salesTax),
                        GetSelectedRadioButtonText(paymntTypegroup), Convert.ToDouble(paymentTxt.Text));
                    //send sales to emp sales record
                    currentEmp.Sales = (subTotal + salesTax);
                }
                else
                    MessageBox.Show("Customer does not have a reservation to pay for");
            }
            else
                MessageBox.Show("No customer selected");
        }
        //get seleced radio btn text from group
        private string GetSelectedRadioButtonText(GroupBox grb)
        {
            return grb.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;
        }

        private void paymntClearBtn_Click(object sender, EventArgs e)
        {

        }

        private void printReceiptBtn_Click(object sender, EventArgs e)
        {

        }

        private void lookUpPaymntBtn_Click(object sender, EventArgs e)
        {

        }
        /*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Manager controls
         *<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Employee tab
         * Add, Del, update, look up, all employee related stuff
         * 
         */
        private void addEmpBtn_Click(object sender, EventArgs e)
        {

        }

        private void remEmpBtn_Click(object sender, EventArgs e)
        {

        }

        private void searchEmpBtn_Click(object sender, EventArgs e)// search for a employee
        {
            searchFirstName(empSearchList, employees);//search first name make searched list
            empSearchList.Clear();
            foreach (Employee emps in searched2)
            {
                altRowColor(searched2, empSearchList);//iterate throught list alt row color
            }
            altCust = 0;//reset altCust to avoid errors
        }

        private void empViewAllEmps_Click(object sender, EventArgs e)// View all Employees
        {
            empSearchList.Clear();//clear textbox
            foreach (Employee emps in employees)
            {
                altRowColor(employees, empSearchList);
            }
            altCust = 0;//reset altCust to avoid errors
        }

        private void empClearBtn_Click(object sender, EventArgs e)
        {

        }

        private void updateEmpNotesBtn_Click(object sender, EventArgs e)
        {

        }
        /*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Sales tab
         *<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
         *<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
         */
        private void displaySalesBtn_Click(object sender, EventArgs e)
        {

        }

        private void printSalesBtn_Click(object sender, EventArgs e)
        {

        }

        private void clearSalesTxt_Click(object sender, EventArgs e)
        {

        }

        private void custResNumTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }//end class
}//end namespace