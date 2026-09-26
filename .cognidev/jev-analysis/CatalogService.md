# CatalogService Analysis

## Domain Classification
**Bounded Context**: Catalog Management

## Complexity Score
**Score**: 3/10 (Low complexity)

## Dependencies Identified
- `Product` entity (domain model)
- `Category` entity (domain model)
- `ShopDbContext` (data access - **COUPLING POINT**)

## Data Access Patterns
- Direct `DbContext` usage
- LINQ queries for product/category retrieval
- No repository pattern

## Recommended Bounded Context
**Service**: `catalog-service`

**Rationale**:
- Clear domain boundary around product catalog
- Minimal cross-context logic
- Can be extracted with database-per-service pattern

## Decomposition Notes

### Migration Strategy
1. Extract to standalone `catalog-service`
2. Create dedicated `CatalogDbContext` 
3. Migrate `Products` and `Categories` tables
4. No saga needed - read-only for other contexts

### Breaking Changes
- Other services will need HTTP client for catalog lookups
- `Orders` service calls `GetProduct()` - becomes REST call
- `Inventory` service shares products - needs event-driven sync

### Estimated Effort
- **Lines of Code**: ~50
- **Complexity**: Low
- **Risk**: Low
- **Estimated Hours**: 4-6 hours

## Cross-Service Dependencies

### Consumers
- `OrderService.PlaceOrder()` - needs product validation
- `InventoryService` - needs product metadata

### Providers
None (leaf service)

## Strangler Fig Order
**Priority**: 1 (Foundation service - move first)

No upstream dependencies, enables other services to consume via API.
