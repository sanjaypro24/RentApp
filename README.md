RentApp

RentApp is a rental service application that allows users to rent books and cars while incorporating discount mechanisms based on customer type and vehicle engine type. The application follows the SOLID design principles to ensure maintainability and scalability.

Features

User, Book, and Car rental management

Discount calculation based on customer type and vehicle engine type

Price calculation including duration and location-based discounts

Implements SOLID principles for maintainability

API Endpoints

User

GET /api/user - Get all users

POST /api/user - Create a new user

Book

GET /api/book - Get all books

POST /api/book - Add a new book

RideCar

GET /api/ridecar - Get all rental cars

POST /api/ridecar - Rent a car

Price Calculation

The PriceCalculator applies:

Base price per hour: 45

Location discount: Chennai gets 10% off

Engine-based discount: Applied in EngineDiscount

Customer-based discount:

NormalCustomer: 5% off

PremiumCustomer: 10% off
