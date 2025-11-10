using PizzaLibrary.Exceptions;
using PizzaLibrary.Helpers;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

MenuItemRepository mRepo = new MenuItemRepository();
CustomerRepository cRepo = new CustomerRepository();

mRepo.PrintAllMenuItems();
Console.WriteLine();
cRepo.PrintAllCustomers();
Console.WriteLine();

Console.WriteLine(cRepo.GetCustomerByMobile("13131313"));
Console.WriteLine(cRepo.GetCustomerByMobile("12345678"));

Console.WriteLine(cRepo.GetAll()[1]);

//cRepo.GetAll()[1].ClubMember = true;
//Console.WriteLine(cRepo.GetAll()[1]);
//Console.WriteLine();

cRepo.AddCustomer(new Customer("Anders", "23232323", "Street 321", true));
cRepo.AddCustomer(new Customer("Andrea", "32323232", "Road 420", true));
Console.WriteLine();

Console.WriteLine("Added 2 club member customers");
Console.WriteLine("All members in cRepo");
Printer.PrintList(cRepo.GetAllMembers());

cRepo.AddCustomer(new Customer("Michelle", "42424242", "Gade 654, Roskilde", true));
cRepo.AddCustomer(new Customer("Markus", "86868686", "Vej 432, Roskilde", true));

Console.WriteLine();
Console.WriteLine("Added 2 customers from Roskilde");
Console.WriteLine("All customers from Roskilde in cRepo");
//Console.WriteLine(string.Join("\n", cRepo.GetAllAddressMatch("Roskilde")));
Printer.PrintList(cRepo.GetAllAddressMatch("Roskilde"));

Console.WriteLine();
Console.WriteLine("All sandwhiches");
Printer.PrintList(mRepo.GetAllOfType(MenuType.SANDWICHES));

Console.WriteLine();
Console.WriteLine("All pizzas");
Printer.PrintList(mRepo.GetAllOfType(MenuType.PIZZECLASSSICHE));

Console.WriteLine();
Console.WriteLine("Most expensive sandwhich");
Printer.PrintList(mRepo.GetMostExpensiveOfMenuType(MenuType.SANDWICHES));

Console.WriteLine();
Console.WriteLine("Most expensive pizza(s)");
Printer.PrintList(mRepo.GetMostExpensivePizza());

Console.WriteLine();
mRepo.PrintMenu();
Console.WriteLine();
//Console.WriteLine("--------------------------- Testing interactive console ------------------------------------");
//Console.WriteLine();
//PizzaStore BigMamma = new PizzaStore();
//BigMamma.CreateOrder(BigMamma.Customers.GetCustomerByMobile("12121212"));

Console.WriteLine("--------------------UML2 del 2--------------------");
Console.WriteLine();

VIPCustomer vipCustomer = new VIPCustomer("Ole", "12344321", "VIP vej 2", 2);
cRepo.AddCustomer(vipCustomer);

cRepo.PrintAllCustomers();
Console.WriteLine();

try
{
    cRepo.AddCustomer(new Customer("Kurt", "42424242", "Vej 3"));
}
catch (CustomerMobileNumberExist mex)
{
    Console.WriteLine(mex.Message);
}
Console.WriteLine();

try
{
    VIPCustomer highDiscount = new VIPCustomer("Camilla", "65656565", "Gade 2", 26);
}
catch (TooHighDiscountException thex)
{
    Console.WriteLine(thex.Message);
}
Console.WriteLine();

try
{
    VIPCustomer lowDiscount = new VIPCustomer("Camilla", "65656565", "Gade 2", 0);
}
catch (TooLowDiscountException tlex)
{
    Console.WriteLine(tlex.Message);
}
