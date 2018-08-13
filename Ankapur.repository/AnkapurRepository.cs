using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
namespace Ankapur.repository
{
    public class AnkapurRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public static SqlDataReader getrestaurants()
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spgetrest2");
        }
        public static int savecustomerdetails(string customerphone, string customername, string address, string password, string Email)
        {
            int count = SqlHelper.ExecuteNonQuery(ConnectionString, "custregforweb", customerphone, customername, address, password, Email);
            return count;

        }
        //loading total products
        public static SqlDataReader Loadproducts()
        {
            return SqlHelper.ExecuteReader(ConnectionString, "loadproductsforwebapp");
        }
        public static int guestcustomer(string CustomerPhoneNumber, string CustomerName, string Address, string status, string password)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "spRegisterguestcustomer", CustomerPhoneNumber, CustomerName, Address, status, password);
        }
        //guest login
        public static int guestupdatecustomer(string CustomerPhoneNumber, string CustomerName, string Address, string status)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "spupdateguestcustomer", CustomerPhoneNumber, CustomerName, Address, status);
        }
        public static int updatecustomerotp(string CustomerPhoneNumber, string CustomerName, string Address, string OTP)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "spupdatecustomerotp", CustomerPhoneNumber, CustomerName, Address, OTP);
        }
        public static int getguestcustomer(string CustomerPhoneNumber, string Password)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "spgetguestcustomer", CustomerPhoneNumber, Password);
        }
        public static SqlDataReader loadprodoncategory(int catid)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "loadprodoncategory", catid);
        }
        //load product on category1
        public static SqlDataReader loadprodoncategory1(int catid1, int catid2, int catid3)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "loadprodoncategory1", catid1, catid2, catid3);
        }
        public static SqlDataReader getmenubycategory(string categorytype)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "getMenuByCategory", categorytype);
        }
        //save order start
        public static int placeorder(string CustomerPhone, string restcode, string CustRequest, string delivertime, decimal Totalamount, decimal cgst1, decimal sgst1, int deliveryamount, string delarea)
        {
            int count = SqlHelper.ExecuteNonQuery(ConnectionString, "spinsertNewOrder10DT", CustomerPhone, restcode, CustRequest, delivertime, Totalamount, cgst1, sgst1, deliveryamount, delarea);
            return count;
        }

        public static int placeguestorder(string CustomerPhone, string restcode, string CustRequest, string delivertime, decimal Totalamount, decimal cgst1, decimal sgst1, int deliveryamount, string delarea)
        {
            int count = SqlHelper.ExecuteNonQuery(ConnectionString, "spinsertguestodetails", CustomerPhone, restcode, CustRequest, delivertime, Totalamount, cgst1, sgst1, deliveryamount, delarea);
            return count;
        }



        //save order end
        //update order start
        public static int updateorder(string orderid, decimal totalamount, decimal cgst, decimal sgst, int delamount, string checksum, string DeliverTime)
        {
            int count = SqlHelper.ExecuteNonQuery(ConnectionString, "updateorderidforappcsDT", orderid, totalamount, cgst, sgst, delamount, checksum, DeliverTime);
            return count;
        }
        //update order end
        //delete order details start
        public static int deleteorderdetails(string orderid)
        {
            int count = SqlHelper.ExecuteNonQuery(ConnectionString, "deleteorderdetails", orderid);
            return count;
        }
        //delete order details end
        public static SqlDataReader generateorderid(DateTime orderdate, string restcode)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spgetorderidforwebapichecksum", orderdate, restcode);
        }
        public static SqlDataReader generateorderidwebappdisplay(DateTime orderdate, string restcode)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spgetorderidforwebapi", orderdate, restcode);
        }
        public static SqlDataReader generateorderidforcart(DateTime orderdate, string restcode)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spgetorderidforwebapp", orderdate, restcode);
        }
        public static int saveorderdetails(string orderid, int Quantity, string productid)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "insertNewOrdreDetailsBasedOnId", orderid, Quantity, productid);

        }
        public static SqlDataReader validatecustomer(string password, string customerphone)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spValidateCustomerforweb", password, customerphone);
        }
        public static SqlDataReader checkcartdata(string orderid, string quantity, string productid)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "checkcartdataforwebapp", orderid, quantity, productid);
        }
        public static int addtocart(string orderid, string quantity, string productid)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "addtocartforwebapp", orderid, quantity, productid);
        }
        public static int deletecartdetails(string orderid, string productid)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "deletecartitems", orderid, productid);
        }
        public static int updatecart(string orderid, string productid, int quantity)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "updatecart", orderid, productid, quantity);
        }
        public static SqlDataReader getuserprofile(int id)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "getuserprofileforwebapp", id);
        }

        //customer Registration

        public static int Registercustomer(string CustomerPhoneNumber, string CustomerName, string Password, string Address, string OTP, string status)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "spRegisterCustomerDetailsforappOTP", CustomerPhoneNumber, CustomerName, Password, Address, OTP, status);
        }

        //customer login

        public static SqlDataReader customerlogin(string Password, string CustomerPhoneNumber)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "splogincustomerforappwithOTP", Password, CustomerPhoneNumber);
        }

        //update customer address

        public static int updatecustaddress(string phone, string address)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "updatecustaddressforwebapp", phone, address);
        }

        //load billdetails

        public static SqlDataReader getbilldetails(string phone, string orderid)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "loadbilldetailsforwebapp1", phone, orderid);
        }
        public static SqlDataReader getaddressdetails(string phone)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "loadaddressdetailsforwebapp", phone);
        }

        public static SqlDataReader guestloginnewcust(string phone)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "guestloginnewcustforwebapp", phone);
        }

        //orderid for conform page

        public static SqlDataReader orderidforconformpage(DateTime orderdate, string restcode)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "sporderidforconformpage", orderdate, restcode);
        }
        //orderid for cart page

        public static SqlDataReader orderidforcartpage(DateTime orderdate, string restcode)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "sporderidforcartpage", orderdate, restcode);
        }
        //load cart details for confirm page

        public static SqlDataReader loadcartdetailsforconformpage(string orderid)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "sploadcartforconformpage", orderid);
        }
        //load productdetails from cart

        public static SqlDataReader loadproductdetailsfromcart(string orderid)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "loadproductdetailsfromorderdetsils", orderid);
        }

        //update orderstatus and confirm order

        public static int updateorderstatus(string orderid, int statusid, string custinst, string pmname, string pmstatus, decimal totalamount)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "updateorderstatusforwebapp1DT", orderid, statusid, custinst, pmname, pmstatus, totalamount);
        }

        public static int paymentorderstatus(string orderid, int statusid, string custinst, string pmname, string pmstatus, decimal totalamount, string payment)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "paymentorderstatusforwebapp1DT", orderid, statusid, custinst, pmname, pmstatus, totalamount,payment);
        }

        //Display updated address

        public static SqlDataReader displayupdatedaddress(string phone)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "displayupdatedaddress", phone);
        }

        //send password to customer mobile

        public static SqlDataReader sendpwtocustomer(string phone)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spsendpwdtomobile", phone);
        }

        //insert neworder details based oi id
        public static int insertdetailsidbase(string orderid, string productid, int quantity)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "insertNewOrdreDetailsBasedOnId", orderid, quantity, productid);
        }
        public static int insertguestdetailsidbase(string orderid, string productid, int quantity)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, "insertguestOrdreDetailsBasedOnId", orderid, quantity, productid);
        }

        //orderidforwebcart
        public static SqlDataReader generateorderidforwebcart(DateTime orderdate, string restcode)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spgetorderidforwebapi", orderdate, restcode);
        }
        //OTP checking
        public static SqlDataReader checkotp(string OTP, string CustomerPhonenumber)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spvalidateOTPforapp", OTP, CustomerPhonenumber);
        }
        //view orderdetails
        public static SqlDataReader vieworderdetails(string Restcode, string CustomerPhone)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spviewcustordersforappDT", Restcode, CustomerPhone);
        }
        //validate promo
        public static SqlDataReader checkpromo(string promo)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "spvalidatepromo", promo);
        }
        //update profile
        public static int updateprofile(string custphone, string name, string email, string altmobile, string address, string image)
        {
            int count = SqlHelper.ExecuteNonQuery(ConnectionString, "updatecustomerdetails", custphone, name, email, altmobile, address, image);
            return count;
        }
        //getprofile details
        public static SqlDataReader getprofiledetails(string custphone)
        {
            return SqlHelper.ExecuteReader(ConnectionString, "getprofiledetails", custphone);
        }
    }
}
