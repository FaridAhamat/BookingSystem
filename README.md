# BookingSystem
This repository contains a simple, mock booking system's REST API developed using .NET Core.

This repository is pretty basic, it contains only two entity from what is expected from a booking system.
# Booking
The system allows you to view all bookings, view specific booking, create new booking, or update any booking.

# User
The system allows you to view all users, view specific user and create new user.

# Misc
This repository has been published on Azure. In order to make it easy for you to take a look at what this API has to offer, I have set up the Swagger too! It is on: http://bookingfree.azurewebsites.net/swagger

Please note that the API is hosted on free-tier resource, so the first hit will always be slow. This is due to Azure unloading the worker process that runs the website when it goes idle, and reload it once the site gets hit.

There is also a client mobile app that uses this API: https://github.com/FaridAhamat/BookingApp

Note:
From time to time, I will turn off the resources on Azure, so if it's not running, it's probably because of that :)

This repository is to showcase my skills and understanding on:
- .NET Core Web API
- Swagger
- Unit testing using Moq
- Repository pattern
- Azure WebApp
