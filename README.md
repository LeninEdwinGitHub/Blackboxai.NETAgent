# OnlineStore

This is a simple ASP.NET Core MVC application for an online store. It features product listing, product details, shopping cart, and checkout functionality.

## Features

- Product listing with images, descriptions, and prices
- Product details page
- Shopping cart with add/remove functionality
- Checkout form to place orders
- Session-based cart storage
- Styled with Tailwind CSS, Google Fonts, and Font Awesome

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Running the Application

1. Navigate to the project directory:

```bash
cd OnlineStore
```

2. Restore dependencies:

```bash
dotnet restore
```

3. Run the application:

```bash
dotnet run
```

4. Open your browser and go to `https://localhost:5001` or `http://localhost:5000`.

## Notes

- This project uses an in-memory list for products and session storage for the cart.
- No database is configured; orders are not persisted.
- Tailwind CSS is included via CDN for styling.

## License

This project is provided as-is for demonstration purposes.
