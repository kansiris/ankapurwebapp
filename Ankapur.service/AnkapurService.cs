using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ankapur.repository;
using System.Data.SqlClient;
namespace Ankapur.service
{
    public class AnkapurService
    {
        public static SqlDataReader getrestaurants()
        {
            return AnkapurRepository.getrestaurants();
        }
        public static int savecustomerdetails(string customerphone, string customername, string address, string password, string Email)
        {
            return AnkapurRepository.savecustomerdetails(customerphone, customername, address, password, Email);
        }
        //loading total products
        public static SqlDataReader Loadproducts()
        {
            return AnkapurRepository.Loadproducts();
        }
        public static SqlDataReader loadprodoncategory(int catid)
        {
            return AnkapurRepository.loadprodoncategory(catid);
        }
        public static SqlDataReader getmenubycategory(string categorytype)
        {
            return AnkapurRepository.getmenubycategory(categorytype);
        }

        //guest login

        public static int guestcustomer(string CustomerPhoneNumber, string CustomerName, string Address, string status, string password)
        {
            return AnkapurRepository.guestcustomer(CustomerPhoneNumber, CustomerName, Address, status, password);
        }
        public static int guestupdatecustomer(string CustomerPhoneNumber, string CustomerName, string Address, string status)
        {
            return AnkapurRepository.guestupdatecustomer(CustomerPhoneNumber, CustomerName, Address, status);
        }
        public static int updatecustomerotp(string CustomerPhoneNumber, string CustomerName, string Address, string OTP)
        {
            return AnkapurRepository.updatecustomerotp(CustomerPhoneNumber, CustomerName, Address, OTP);
        }

        public static int getguestcustomer(string CustomerPhoneNumber, string Password)
        {
            return AnkapurRepository.getguestcustomer(CustomerPhoneNumber, Password);
        }
        //saving order
        public static int placeorder(string CustomerPhone, string restcode, string CustRequest, string delivertime, decimal Totalamount, decimal cgst1, decimal sgst1, int deliveryamount, string delarea)
        {
            return AnkapurRepository.placeorder(CustomerPhone, restcode, CustRequest, delivertime, Totalamount, cgst1, sgst1, deliveryamount, delarea);
        }


        public static int placeguestorder(string CustomerPhone, string restcode, string CustRequest, string delivertime, decimal Totalamount, decimal cgst1, decimal sgst1, int deliveryamount, string delarea)
        {
            return AnkapurRepository.placeguestorder(CustomerPhone, restcode, CustRequest, delivertime, Totalamount, cgst1, sgst1, deliveryamount, delarea);
        }
        //saving order end
        //update order start
        public static int updateorder(string orderid, decimal totalamount, decimal cgst, decimal sgst, int delamount, string checksum, string DeliverTime)
        {
            return AnkapurRepository.updateorder(orderid, totalamount, cgst, sgst, delamount, checksum, DeliverTime);
            //return count;
        }
        //update order end
        //delete order details start
        public static int deleteorderdetails(string orderid)
        {
            return AnkapurRepository.deleteorderdetails(orderid);
            //return count;
        }
        //delete order details end
        public static SqlDataReader generateorderid(DateTime orderdate, string restcode)
        {
            return AnkapurRepository.generateorderid(orderdate, restcode);
        }
        public static SqlDataReader generateorderidwebappdisplay(DateTime orderdate, string restcode)
        {
            return AnkapurRepository.generateorderidwebappdisplay(orderdate, restcode);
        }
        public static SqlDataReader generateorderidforcart(DateTime orderdate, string restcode)
        {
            return AnkapurRepository.generateorderidforcart(orderdate, restcode);
        }
        public static int saveorderdetails(string orderid, int Quantity, string productid)
        {
            return AnkapurRepository.saveorderdetails(orderid, Quantity, productid);
        }
        public static SqlDataReader validatecustomer(string password, string customerphone)
        {
            return AnkapurRepository.validatecustomer(password, customerphone);
        }
        public static SqlDataReader checkcartdata(string orderid, string quantity, string productid)
        {
            return AnkapurRepository.checkcartdata(orderid, quantity, productid);
        }
        public static int addtocart(string orderid, string quantity, string productid)
        {
            return AnkapurRepository.addtocart(orderid, quantity, productid);
        }
        public static int deletecartdetails(string orderid, string productid)
        {
            return AnkapurRepository.deletecartdetails(orderid, productid);
        }
        public static int updatecart(string orderid, string productid, int quantity)
        {
            return AnkapurRepository.updatecart(orderid, productid, quantity);
        }
        //customer Registration

        public static int Registercustomer(string CustomerPhoneNumber, string CustomerName, string Password, string Address, string OTP, string status)
        {
            return AnkapurRepository.Registercustomer(CustomerPhoneNumber, CustomerName, Password, Address, OTP, status);
        }

        //customer login
        public static SqlDataReader customerlogin(string Password, string CustomerPhoneNumber)
        {
            return AnkapurRepository.customerlogin(Password, CustomerPhoneNumber);
        }


        //update customer address

        public static int updatecustaddress(string phone, string address)
        {
            return AnkapurRepository.updatecustaddress(phone, address);
        }
        //load billdetails

        public static SqlDataReader getbilldetails(string phone, string orderid)
        {
            return AnkapurRepository.getbilldetails(phone, orderid);
        }
        public static SqlDataReader getaddressdetails(string phone)
        {
            return AnkapurRepository.getaddressdetails(phone);
        }
        public static SqlDataReader guestloginnewcust(string phone)
        {
            return AnkapurRepository.guestloginnewcust(phone);
        }
        //orderid for conform page

        public static SqlDataReader orderidforconformpage(DateTime orderdate, string restcode)
        {
            return AnkapurRepository.orderidforconformpage(orderdate, restcode);
        }
        //orderid for cart page

        public static SqlDataReader orderidforcartpage(DateTime orderdate, string restcode)
        {
            return AnkapurRepository.orderidforcartpage(orderdate, restcode);
        }
        //load cart details for confirm page

        public static SqlDataReader loadcartdetailsforconformpage(string orderid)
        {
            return AnkapurRepository.loadcartdetailsforconformpage(orderid);
        }
        //load productdetails from cart

        public static SqlDataReader loadproductdetailsfromcart(string orderid)
        {
            return AnkapurRepository.loadproductdetailsfromcart(orderid);
        }

        //update orderstatus and confirm order

        public static int updateorderstatus(string orderid, int statusid, string custinst, string pmname, string pmstatus, decimal totalamount)
        {
            return AnkapurRepository.updateorderstatus(orderid, statusid, custinst, pmname, pmstatus, totalamount);
        }
        public static int paymentorderstatus(string orderid, int statusid, string custinst, string pmname, string pmstatus, decimal totalamount,string payment)
        {
            return AnkapurRepository.paymentorderstatus(orderid, statusid, custinst, pmname, pmstatus, totalamount,payment);
        }


        //Display updated address

        public static SqlDataReader displayupdatedaddress(string phone)
        {
            return AnkapurRepository.displayupdatedaddress(phone);
        }
        //send password to customer mobile

        public static SqlDataReader sendpwtocustomer(string phone)
        {
            return AnkapurRepository.sendpwtocustomer(phone);
        }
        //insert neworder details based oi id
        public static int insertdetailsidbase(string orderid, string productid, int quantity)
        {
            return AnkapurRepository.insertdetailsidbase(orderid, productid, quantity);
        }

        public static int insertguestdetailsidbase(string orderid, string productid, int quantity)
        {
            return AnkapurRepository.insertguestdetailsidbase(orderid, productid, quantity);
        }

        //orderidforwebcart
        public static SqlDataReader generateorderidforwebcart(DateTime orderdate, string restcode)
        {
            return AnkapurRepository.generateorderidforwebcart(orderdate, restcode);
        }
        //load product on category1
        public static SqlDataReader loadprodoncategory1(int catid1, int catid2, int catid3)
        {
            return AnkapurRepository.loadprodoncategory1(catid1, catid2, catid3);
        }
        //OTP checking
        public static SqlDataReader checkotp(string OTP, string CustomerPhonenumber)
        {
            return AnkapurRepository.checkotp(OTP, CustomerPhonenumber);
        }
        //vieworder
        public static SqlDataReader vieworderdetails(string Restcode, string CustomerPhone)
        {
            return AnkapurRepository.vieworderdetails(Restcode, CustomerPhone);
        }
        //validate promo
        public static SqlDataReader checkpromo(string promo)
        {
            return AnkapurRepository.checkpromo(promo);
        }
        //update profile
        public static int updateprofile(string custphone, string name, string email, string altmobile, string address, string image)
        {
            return AnkapurRepository.updateprofile(custphone, name, email, altmobile, address, image);

        }
        //getprofile details
        public static SqlDataReader getprofiledetails(string custphone)
        {
            return AnkapurRepository.getprofiledetails(custphone);
        }
    }
}
