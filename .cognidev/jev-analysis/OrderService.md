# OrderService Analysis

## Domain Classification
**Bounded Context**: Order Management

## Complexity Score
**Score**: 8/10 (High complexity)

## Dependencies Identified
- `Order`, `OrderLine` entities
- `CatalogService.GetProduct()` - **CROSS-CONTEXT CALL**
- `CustomerService.GetCustomer()` - **CROSS-CONTEXT CALL**
- `InventoryService.Reserve()` - **CROSS-CONTEXT CALL**
- `PaymentService.Charge()` - **CROSS-CONTEXT CALL**
- `ShopDbContext` (god context) - **MAJOR COUPLING**

## Saga Detected
**CreateOrder Saga** - Coordinates 4 services in one transaction:
```
1. Get Product (Catalog)
2. Validate Customer (Customers)
3. Reserve Stock (Inventory) 
4. Charge Payment (Payments)
5. Save Order (Orders)
```

**Current State**: All in one `SaveChanges()` transaction
**Target State**: Distributed saga with compensation

## Recommended Bounded Context
**Service**: `orders-service`

**Rationale**:
- Core order orchestration logic
- Owns order aggregate
- Natural saga coordinator

## Decomposition Notes

### Migration Strategy
1. Extract last (after all dependencies)
2. Implement saga pattern (Wolverine)
3. Replace direct calls with saga steps
4. Add outbox pattern for reliability
5. Implement compensation handlers

### Breaking Changes
**CRITICAL**: Loss of ACID transaction
- Was: 1 transaction across 4 contexts
- Will be: Eventually consistent saga

### Compensation Required
- `InventoryService.CancelReservation()`
- `PaymentService.Refund()`

### Estimated Effort
- **Lines of Code**: ~80
- **Complexity**: High (saga orchestration)
- **Risk**: High (distributed transaction)
- **Estimated Hours**: 24-32 hours

## Cross-Service Dependencies

### Consumers
None (orchestrator service)

### Providers
- Catalog API (product validation)
- Customers API (customer validation)
- Inventory API (stock reservation)
- Payments API (payment processing)

## Strangler Fig Order
**Priority**: 5 (Move last - depends on all others)

Cannot move until Catalog, Customers, Inventory, and Payments are extracted.

## Data Ownership
**Tables**: `Orders`, `OrderLines`

**Migration**: Database-per-service
