# wms-mvc
A Warehouse Management System built in MVC using Clean Architecture and MediatR.

# Improvements
- Refine .gitignore
- Use npm for CSS & JS
- Stop navigation properties in EF
- Better migration handling
- CostPrice and SellPrice could be different tables as they update over time
- Ids in db should be GUID
- Upload should be in a new controller
- Log errors
- Actually implement upsert
- You could argue you wouldn't want to update categories or manufacturers when upserting products
- No upsert added for Stock