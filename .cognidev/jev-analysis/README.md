# Jev Analysis Summary

This directory contains Jev-powered analysis of the monolith's services and controllers.

Each file contains:
- **Domain Classification**: Which bounded context it belongs to
- **Complexity Score**: 1-10 rating
- **Dependencies**: What other services/components it uses
- **Recommended Bounded Context**: Where it should live in microservices
- **Decomposition Notes**: Specific migration considerations

## Generated Files

- CatalogController.md
- CatalogService.md
- CustomersController.md
- CustomerService.md
- PaymentService.md
