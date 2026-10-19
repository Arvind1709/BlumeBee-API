# BlumeBee PreSchool API – missing database modules

This update builds on the supplied DTO-updated solution and adds API controllers, typed request DTOs, and typed response DTOs for the database tables that did not have controllers.

## Added modules

- `student_parent` → `api/StudentParent` (GET all, GET by id, POST, PUT, DELETE)
- `visit` → `api/Visit` (GET all, GET by id, POST, PUT, DELETE)
- `student_document` → `api/StudentDocument` (GET all, GET by id, POST, PUT, DELETE)
- `authorized_pickup` → `api/AuthorizedPickup` (GET all, GET by id, POST, PUT, DELETE)
- `student_health_record` → `api/StudentHealthRecord` (GET all, GET by id, POST, PUT, DELETE)
- `staff_training` → `api/StaffTraining` (GET all, GET by id, POST, PUT, DELETE)
- `staff_verification` → `api/StaffVerification` (GET all, GET by id, POST, PUT, DELETE)
- `payroll` → `api/Payroll` (GET all, GET by id, POST, PUT, DELETE)
- `fee_structure` → `api/FeeStructure` (GET all, GET by id, POST, PUT, DELETE)
- `student_bill` → `api/StudentBill` (GET all, GET by id, POST, PUT, DELETE)
- `student_discount` → `api/StudentDiscount` (GET all, GET by id, POST, PUT, DELETE)
- `student_refund` → `api/StudentRefund` (GET all, GET by id, POST, PUT, DELETE)
- `student_ledger` → `api/StudentLedger` (GET all, GET by id, POST, PUT, DELETE)
- `parent_communication` → `api/ParentCommunication` (GET all, GET by id, POST, PUT, DELETE)
- `parent_meeting` → `api/ParentMeeting` (GET all, GET by id, POST, PUT, DELETE)
- `parent_concern` → `api/ParentConcern` (GET all, GET by id, POST, PUT, DELETE)
- `parent_engagement` → `api/ParentEngagement` (GET all, GET by id, POST, PUT, DELETE)
- `broadcast_log` → `api/BroadcastLog` (GET all, GET by id, POST, PUT, DELETE)
- `daily_child_update` → `api/DailyChildUpdate` (GET all, GET by id, POST, PUT, DELETE)
- `learning_outcome` → `api/LearningOutcome` (GET all, GET by id, POST, PUT, DELETE)
- `student_observation` → `api/StudentObservation` (GET all, GET by id, POST, PUT, DELETE)
- `student_intervention` → `api/StudentIntervention` (GET all, GET by id, POST, PUT, DELETE)
- `student_assessment` → `api/StudentAssessment` (GET all, GET by id, POST, PUT, DELETE)
- `curriculum_annual_map` → `api/CurriculumAnnualMap` (GET all, GET by id, POST, PUT, DELETE)
- `weekly_lesson_plan` → `api/WeeklyLessonPlan` (GET all, GET by id, POST, PUT, DELETE)
- `daily_activity_plan` → `api/DailyActivityPlan` (GET all, GET by id, POST, PUT, DELETE)
- `incident_report` → `api/IncidentReport` (GET all, GET by id, POST, PUT, DELETE)
- `medicine_administration` → `api/MedicineAdministration` (GET all, GET by id, POST, PUT, DELETE)
- `emergency_drill` → `api/EmergencyDrill` (GET all, GET by id, POST, PUT, DELETE)
- `cctv_audit` → `api/CctvAudit` (GET all, GET by id, POST, PUT, DELETE)
- `safety_checklist` → `api/SafetyChecklist` (GET all, GET by id, POST, PUT, DELETE)
- `inventory_item` → `api/InventoryItem` (GET all, GET by id, POST, PUT, DELETE)
- `maintenance_log` → `api/MaintenanceLog` (GET all, GET by id, POST, PUT, DELETE)
- `complaint` → `api/Complaint` (GET all, GET by id, POST, PUT, DELETE)
- `document_tracker` → `api/DocumentTracker` (GET all, GET by id, POST, PUT, DELETE)
- `task_register` → `api/TaskRegister` (GET all, GET by id, POST, PUT, DELETE)
- `event_planner` → `api/EventPlanner` (GET all, GET by id, POST, PUT, DELETE)
- `vendor_amc` → `api/VendorAmc` (GET all, GET by id, POST, PUT, DELETE)

## Shared implementation

- `Services/DynamicCrudService.cs` implements parameterized PostgreSQL CRUD.
- `Services/CrudModuleController.cs` supplies the common HTTP actions and database constraint responses.
- `ModelDTO/Modules/*RequestDto.cs` provides typed request payloads and basic required/string-length validation; matching `*ResponseDto.cs` classes type the GET responses.
- `ReportsController` adds dashboard, active-student, fee-ageing, admissions-funnel, class-count, monthly conversion, fee collection and attendance reporting endpoints using the views/queries in the SQL package.

## Important behavior and verification

- This uses the existing `PostgresDbHelper` and `PostgresConnection` connection string; it does not introduce Entity Framework.
- IDs and default-generated timestamps are omitted from request DTOs. POST omits null properties so PostgreSQL defaults can apply. PUT is full-replacement style for DTO fields: send the complete intended payload; nullable properties sent as null are set to NULL.
- DELETE is a physical delete. Foreign-key constraints may prevent deletion; in that case the API returns HTTP 409. For sensitive/retained records, consider changing the module to a status/soft-delete operation.
- The generic CRUD endpoints do not automatically enforce business workflows (for example, creating an admission and a student in one transaction), authorization by role, or pagination. Those should be added as the app's rules are finalized.
- Apply the SQL package first, ensure the `blumebee` schema and its tables/views exist, configure `ConnectionStrings:PostgresConnection`, then build and test in Visual Studio. This environment has no .NET SDK, so compilation and live PostgreSQL integration could not be run here.
