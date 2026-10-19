# BlumeBee PreSchool – API Module Catalog

The generated module controllers expose the following routes. Base URL is your configured API origin (for example, `http://localhost:2030`). All table names below are in PostgreSQL schema `blumebee`.

## CRUD endpoints

| Database table | Route | Operations | Request DTO | Response DTO |
|---|---|---|---|---|
| `authorized_pickup` | `/api/AuthorizedPickup` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `AuthorizedPickupRequestDto` | `AuthorizedPickupResponseDto` |
| `broadcast_log` | `/api/BroadcastLog` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `BroadcastLogRequestDto` | `BroadcastLogResponseDto` |
| `cctv_audit` | `/api/CctvAudit` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `CctvAuditRequestDto` | `CctvAuditResponseDto` |
| `complaint` | `/api/Complaint` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `ComplaintRequestDto` | `ComplaintResponseDto` |
| `curriculum_annual_map` | `/api/CurriculumAnnualMap` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `CurriculumAnnualMapRequestDto` | `CurriculumAnnualMapResponseDto` |
| `daily_activity_plan` | `/api/DailyActivityPlan` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `DailyActivityPlanRequestDto` | `DailyActivityPlanResponseDto` |
| `daily_child_update` | `/api/DailyChildUpdate` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `DailyChildUpdateRequestDto` | `DailyChildUpdateResponseDto` |
| `document_tracker` | `/api/DocumentTracker` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `DocumentTrackerRequestDto` | `DocumentTrackerResponseDto` |
| `emergency_drill` | `/api/EmergencyDrill` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `EmergencyDrillRequestDto` | `EmergencyDrillResponseDto` |
| `event_planner` | `/api/EventPlanner` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `EventPlannerRequestDto` | `EventPlannerResponseDto` |
| `fee_structure` | `/api/FeeStructure` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `FeeStructureRequestDto` | `FeeStructureResponseDto` |
| `incident_report` | `/api/IncidentReport` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `IncidentReportRequestDto` | `IncidentReportResponseDto` |
| `inventory_item` | `/api/InventoryItem` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `InventoryItemRequestDto` | `InventoryItemResponseDto` |
| `learning_outcome` | `/api/LearningOutcome` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `LearningOutcomeRequestDto` | `LearningOutcomeResponseDto` |
| `maintenance_log` | `/api/MaintenanceLog` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `MaintenanceLogRequestDto` | `MaintenanceLogResponseDto` |
| `medicine_administration` | `/api/MedicineAdministration` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `MedicineAdministrationRequestDto` | `MedicineAdministrationResponseDto` |
| `parent_communication` | `/api/ParentCommunication` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `ParentCommunicationRequestDto` | `ParentCommunicationResponseDto` |
| `parent_concern` | `/api/ParentConcern` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `ParentConcernRequestDto` | `ParentConcernResponseDto` |
| `parent_engagement` | `/api/ParentEngagement` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `ParentEngagementRequestDto` | `ParentEngagementResponseDto` |
| `parent_meeting` | `/api/ParentMeeting` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `ParentMeetingRequestDto` | `ParentMeetingResponseDto` |
| `payroll` | `/api/Payroll` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `PayrollRequestDto` | `PayrollResponseDto` |
| `safety_checklist` | `/api/SafetyChecklist` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `SafetyChecklistRequestDto` | `SafetyChecklistResponseDto` |
| `staff_training` | `/api/StaffTraining` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StaffTrainingRequestDto` | `StaffTrainingResponseDto` |
| `staff_verification` | `/api/StaffVerification` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StaffVerificationRequestDto` | `StaffVerificationResponseDto` |
| `student_assessment` | `/api/StudentAssessment` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentAssessmentRequestDto` | `StudentAssessmentResponseDto` |
| `student_bill` | `/api/StudentBill` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentBillRequestDto` | `StudentBillResponseDto` |
| `student_discount` | `/api/StudentDiscount` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentDiscountRequestDto` | `StudentDiscountResponseDto` |
| `student_document` | `/api/StudentDocument` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentDocumentRequestDto` | `StudentDocumentResponseDto` |
| `student_health_record` | `/api/StudentHealthRecord` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentHealthRecordRequestDto` | `StudentHealthRecordResponseDto` |
| `student_intervention` | `/api/StudentIntervention` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentInterventionRequestDto` | `StudentInterventionResponseDto` |
| `student_ledger` | `/api/StudentLedger` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentLedgerRequestDto` | `StudentLedgerResponseDto` |
| `student_observation` | `/api/StudentObservation` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentObservationRequestDto` | `StudentObservationResponseDto` |
| `student_parent` | `/api/StudentParent` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentParentRequestDto` | `StudentParentResponseDto` |
| `student_refund` | `/api/StudentRefund` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `StudentRefundRequestDto` | `StudentRefundResponseDto` |
| `task_register` | `/api/TaskRegister` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `TaskRegisterRequestDto` | `TaskRegisterResponseDto` |
| `vendor_amc` | `/api/VendorAmc` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `VendorAmcRequestDto` | `VendorAmcResponseDto` |
| `visit` | `/api/Visit` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `VisitRequestDto` | `VisitResponseDto` |
| `weekly_lesson_plan` | `/api/WeeklyLessonPlan` | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` | `WeeklyLessonPlanRequestDto` | `WeeklyLessonPlanResponseDto` |

## Reporting endpoints

| Route | Purpose |
|---|---|
| `/api/reports/dashboard` | Overall lead, admission, active-student, pending-fee, incident and follow-up totals |
| `/api/reports/active-students` | Active students from `v_active_students` |
| `/api/reports/fee-ageing` | Fee balance ageing from `v_fee_ageing` |
| `/api/reports/admissions-funnel` | Leads grouped by pipeline stage |
| `/api/reports/class-wise-students` | Student counts by class |
| `/api/reports/monthly-leads-admissions` | Monthly leads and admissions |
| `/api/reports/fee-collection-trend` | Monthly fee collection |
| `/api/reports/attendance-percentage` | Student attendance percentage |

## Notes

- Existing controllers/repositories were retained. New modules share `DynamicCrudService` and `CrudModuleController` to avoid copying the same CRUD code 38 times.
- New request DTOs live in `BlumeBee/ModelDTO/Modules`; response DTOs live beside them.
- The shared CRUD endpoints support basic persistence, not module-specific workflows. For example, an admission API does not automatically create a student, parent mappings, bills and ledger entries in one transaction.
- For `PUT`, send a complete DTO payload; nullable fields omitted by JSON become null and are written as null. For `POST`, null properties are omitted so PostgreSQL defaults can apply.
- `DELETE` is a physical delete. Foreign-key constraints can reject it. For student, parent, finance and safeguarding records, soft delete/status transitions may be preferable.
- Configure `ConnectionStrings:PostgresConnection` and a strong `Jwt:Key` before running. The included appsettings values are placeholders.
- Build and run tests in Visual Studio; the environment used to prepare this archive does not have the .NET SDK, so compile-time and live database tests could not be executed here.
