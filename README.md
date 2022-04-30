# Announcements_Api
I did not quite understand exactly how pagination should be implemented.
So I decided to take the page number as a parameter, but if the number is not entered, or 0 is entered, the entire database will be displayed.
The documentation file is in the "Documentation" folder
******************************************************************************************************
Documentation: ***************************************************************************************
******************************************************************************************************

1. "Create" method
URL: / api / Create
Type : POST
Input parameters:
{
	string title (default  null, not allow empty field) - announcement title

	string description (allow null) - announcement description

	int price (default = 0, not allow empty field) - price 

	string mainfoto (default = null, not allow empty field) - main photo link

	string addfoto1 (default = null, allow empty field) - add photo link 1

	string addfoto2 (default = null, allow empty field) - add photo link 2
}
Description : 
{
	Create new Announcement. 
	
}
******************************************************************************************************

2. Method "DataAll"
URL : /api/DataAll
Type : GET

Input parameters :
{
	string order_by (default null, allow empty field)) - sorting argument ("price" or "date" ), if empty field, sorting off
	bool decreasing (default true, allow empty field)) - sort by increase or decrease. If field is empty, use decreasing 
	int  page (default = 0, allow empty field) - number of page. If 0, returns all database
}
Description : 
{
	Get and sort  all data from database. 
}

******************************************************************************************************
3. Method "Delete"
URL : /api/Delete
Type : DELETE
Input parameters :
{
	string id (default = null, not allows empty field) - element id in database
	string title (default = null, allow empty field ) - element title in database
}
Description : 
{
	Delete existing item from database
}
******************************************************************************************************
4. Method "GetById"
URL : /api/GetById
Type : GET
Input parameters :
{
	string id (default = null, not allow empty field) - elements id in database
	bool fields (default = false, allow empty field) - all fields or default

}
Description : 
{
	Get item from database with equal id 
}
******************************************************************************************************
