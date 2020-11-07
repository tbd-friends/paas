### The Idea

A continuing effort to demonstrate and create discussion points for distributed systems, microservices and all those fun buzzwords. 

![The Idea](/docs/PizzaEmporium_11032020.svg "The Diagram")

### Pre-Requisites

- Docker

### Getting Started

- Checkout repository
- Start Required Services
- docker-compose -f docker-compose.infra.yml up -d 
- start website, loyalty and customers services
- Navigate to https://localhost:5001 
- Register
- Enter details
- You should see the Customers service pick up some details
- You should see the Loyalty service pick up some details
- Connect to mongo on 27018, you'll find customers 