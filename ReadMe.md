WHAT THE CHARITY WANTS & WHAT WE NEED TO DO
-----------------------------------------------------------------------------
The charity wants us to add new functionality(to their current site) that will enable prospective board members to search for Charities and vice versa. Prospective Board Members are individuals interested in becoming Board Members of Charities. We will be creating a Web Application and hosting it from inside an iframe on their SiteFinity CMS. Their hosting provider supports all versions of ASP.NET upto v4.0. They support IIS 7.5 and lower versions too.
 
As a part of this process, we will start off by creating two different forms, one for the charities and one for the Prospective Board Members. The prospective board members will need to fill the form indicating their experience/specialty and their Charity preferences. On the other hand, the Charities that are looking for Board Members will also be filling a different form describing their charities and indicating their Board Member preferences. The charity will provide us with all the form fields and the Visuals for the screens. This will provide us with the data required for implementing the search functionality.

We will then need to provide a user interface for the Search functionality. This UI will have a search box and some additional search options and will work as follows:

The Prospective board member will enter the search keywords and select additional search options depending on his/her interest. The application will do a search for these keywords against the Charities data stored in the database. The matching Charity list is then displayed to the user. Details of each of the charities in the list will include all the necessary contact details, besides other information. The Prospective Board Member can then contact the Charity if he/she is interested. A Prospective board member can only search for Charities. They will not be able to view other prospective board members.

The same logic will apply to the Search by a charity for a board member. A charity will be able to search for Board Members only. They will not be able to view other charities.

------------------------------------------------------------------------------------------------------
There are currently two folders:

Docs
This folder contains files with all the details for the work to be done on the web and the database side
Please feel free to add any other similar/related files to this folder

UI
This folder is for all the UI related stuff including mocks and images