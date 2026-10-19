# BlumeBee API DTO updates

## What changed
- Added request DTO classes in `BlumeBee/ModelDTO` for the API entities that previously accepted domain/model classes directly.
- Updated POST/PUT actions in the corresponding controllers to accept request DTOs and map them to the existing model classes before calling repositories.
- Kept the existing DTOs for Parent, Staff, Staff Attendance, Student Attendance, and Visitor Log.
- Added `DtoMapper` to copy matching properties from a request DTO into the existing model without changing repository signatures.
- Added `StudentLookupDto` and updated `GET /api/Student/students` to use the repository instead of opening a separate database connection inside the controller.
- Updated Center and Academic Session controller tests to verify DTO-to-model mapping.

## Compatibility notes
- Existing endpoint routes have been preserved.
- For update endpoints that already include `{id}` in the route, the route ID is now authoritative and is assigned to the mapped model.
- For legacy update endpoints that take the ID in the body, the DTO retains the `Id` property to avoid changing the existing route contract.
- GET endpoints continue returning the model types they returned before, except the student lookup endpoint, which continues returning only `Id` and `StudentCode` via `StudentLookupDto`.

## Validation
The .NET SDK is not installed in the execution environment used to prepare this update, so `dotnet build` and `dotnet test` could not be run here. Please open the solution in Visual Studio and run:
1. Build > Rebuild Solution
2. Test > Run All Tests

The DTO mapping uses matching property names and types. `MasterClassRequestDto` intentionally excludes the nested `Program` navigation property and accepts `ProgramId` instead.
