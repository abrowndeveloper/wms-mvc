# wms-mvc
A Warehouse Management System built in MVC using Clean Architecture and MediatR.

If you have previously tried to run this system then please delete your local copy of WmsDb in your database.

# Improvements
Features:
- Charts, perhaps one for best margin by category?
- A create new product feature, got close but thought it best to submit it
- Search function on the table view
- More refined uploading, such as removing "NULL"

Technical:
- Ids in db should be GUID
- No upsert added for Stock
- Didn't get round to domain validation
- Better migration handling
- ProductController would be good
- CostPrice and SellPrice could be different tables as they update over time
- Log errors
- Use npm for CSS & JS
- Actually implement upsert
- You could argue you wouldn't want to update categories or manufacturers when upserting products
- Refine .gitignore
