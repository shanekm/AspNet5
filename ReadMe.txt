ASP.NET 5 Fundementals

1. Owin and Katana
	a. WebApp object
	b. Startup.cs class - configuration class
	c. Writing your own componenet - middleware
		- extension methods
	d. App.Run() vs App.Use()
		App.Run() - Katana specific 
		App.Use() - Owin low level approach (have to worry about next component)
	e. Api Controller - greeting
		- class library instead of .exe
		- how API knows where to look for startup.cs file

2. Web Api
	a. Help Pages and using // summary tags
	b. IHttpActionResult - built in web api interface 
		- Ok(), NotFound() etc
		- Ok(books)

3. Identity
	a. Request.IsAuthenticated
	b. User.Identity.Name - can be used in View or Controller
	c. Using Immidiate Window
	d. [Authorize] vs. [AllowAnonymous] - overwrite if [Authorize] in Top Controller
	e. Db change - in web.config
	f. ApplicationUser<TUser>
	g. Google Authentication
	h. HttpContext.GetOwinContext()... - additional data for Owin authentication

4. Entity Framework
	a. books : DbContext
	b. DbSet<Book>

5. Tools
	a. Browser Link [Next to > Google Chrome]
	b. Web Essential (.vsx extension) => plugin for VS2013, allows edit in place
	c. LESS - editor for .css
	d. SideWoffle - new templates in VS
	e. Azure 
	f. Glimpse - for viewing db stats (like entity framework, needs Glimpse EF and Glimpse MVC NuGet)
	g. Open Command Line extension
	i. Add new File extension