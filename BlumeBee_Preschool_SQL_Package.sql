
CREATE SCHEMA blumebee;

CREATE TABLE blumebee.center (
    id int PRIMARY KEY,
    code VARCHAR(20) UNIQUE NOT NULL,
    name VARCHAR(150) NOT NULL,
    address_line1 VARCHAR(255),
    city VARCHAR(100),
    state VARCHAR(100),
    country VARCHAR(100) DEFAULT 'India',
    pincode VARCHAR(20),
    phone VARCHAR(20),
    email VARCHAR(120),
    is_active bit DEFAULT 1
);

CREATE TABLE blumebee.academic_session (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    is_active BOOLEAN DEFAULT TRUE
);

CREATE TABLE blumebee.master_gender (
    id SERIAL PRIMARY KEY,
    code VARCHAR(10) UNIQUE NOT NULL,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE blumebee.master_program (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    age_min_months INT,
    age_max_months INT,
    is_active BOOLEAN DEFAULT TRUE,
    sort_order INT DEFAULT 0
);

CREATE TABLE blumebee.master_class (
    id SERIAL PRIMARY KEY,
    program_id INT REFERENCES blumebee.master_program(id),
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    capacity INT DEFAULT 0,
    is_active BOOLEAN DEFAULT TRUE,
    sort_order INT DEFAULT 0
);

CREATE TABLE blumebee.master_lead_source (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    sort_order INT DEFAULT 0
);

CREATE TABLE blumebee.master_lead_status (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    sort_order INT DEFAULT 0
);

CREATE TABLE blumebee.master_payment_status (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE blumebee.master_payment_mode (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE blumebee.master_attendance_code (
    id SERIAL PRIMARY KEY,
    code VARCHAR(10) UNIQUE NOT NULL,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE blumebee.master_staff_role (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    sort_order INT DEFAULT 0
);

CREATE TABLE blumebee.master_department (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE
);

CREATE TABLE blumebee.master_leave_type (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE blumebee.master_incident_type (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE blumebee.master_severity (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    severity_rank INT DEFAULT 0
);

CREATE TABLE blumebee.master_communication_type (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE blumebee.master_inventory_category (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE blumebee.master_item_condition (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE blumebee.master_parent_relationship (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE blumebee.master_student_status (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE blumebee.development_domain (
    id SERIAL PRIMARY KEY,
    code VARCHAR(30) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL
);



CREATE TABLE blumebee.parent (
    id BIGSERIAL PRIMARY KEY,
    full_name VARCHAR(150) NOT NULL,
    relationship_master_id INT REFERENCES blumebee.master_parent_relationship(id),
    phone_primary VARCHAR(20),
    phone_whatsapp VARCHAR(20),
    email VARCHAR(120),
    occupation VARCHAR(120),
    address_line1 VARCHAR(255),
    address_line2 VARCHAR(255),
    city VARCHAR(100),
    state VARCHAR(100),
    pincode VARCHAR(20),
    aadhaar_ref VARCHAR(100),
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.student (
    id BIGSERIAL PRIMARY KEY,
    student_code VARCHAR(30) UNIQUE NOT NULL,
    center_id INT REFERENCES blumebee.center(id),
    first_name VARCHAR(80) NOT NULL,
    last_name VARCHAR(80),
    full_name VARCHAR(160) NOT NULL,
    gender_id INT REFERENCES blumebee.master_gender(id),
    dob DATE NOT NULL,
    blood_group VARCHAR(10),
    allergies TEXT,
    medical_notes TEXT,
    special_support_notes TEXT,
    address_line1 VARCHAR(255),
    address_line2 VARCHAR(255),
    city VARCHAR(100),
    state VARCHAR(100),
    pincode VARCHAR(20),
    aadhaar_ref VARCHAR(100),
    student_status_id INT REFERENCES blumebee.master_student_status(id),
    remarks TEXT,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.student_parent (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id) ON DELETE CASCADE,
    parent_id BIGINT NOT NULL REFERENCES blumebee.parent(id) ON DELETE CASCADE,
    relationship_label VARCHAR(50),
    is_primary_contact BOOLEAN DEFAULT FALSE,
    is_emergency_contact BOOLEAN DEFAULT FALSE,
    is_pickup_authorized BOOLEAN DEFAULT FALSE,
    UNIQUE(student_id, parent_id)
);

CREATE TABLE blumebee.lead (
    id BIGSERIAL PRIMARY KEY,
    lead_code VARCHAR(30) UNIQUE NOT NULL,
    center_id INT REFERENCES blumebee.center(id),
    inquiry_date DATE NOT NULL,
    lead_source_id INT REFERENCES blumebee.master_lead_source(id),
    parent_name VARCHAR(150) NOT NULL,
    child_name VARCHAR(150),
    child_dob DATE,
    parent_contact_number VARCHAR(20),
    whatsapp_number VARCHAR(20),
    email VARCHAR(120),
    preferred_program_id INT REFERENCES blumebee.master_program(id),
    interested_class_id INT REFERENCES blumebee.master_class(id),
    location_area VARCHAR(120),
    working_parents BOOLEAN,
    counselor_staff_id BIGINT,
    follow_up_date DATE,
    lead_status_id INT REFERENCES blumebee.master_lead_status(id),
    last_contact_date DATE,
    first_response_at TIMESTAMP,
    pipeline_stage VARCHAR(50),
    lost_reason VARCHAR(150),
    probability_percent NUMERIC(5,2),
    remarks TEXT,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.visit (
    id BIGSERIAL PRIMARY KEY,
    visit_code VARCHAR(30) UNIQUE NOT NULL,
    lead_id BIGINT REFERENCES blumebee.lead(id) ON DELETE SET NULL,
    visit_date DATE NOT NULL,
    parent_name VARCHAR(150),
    child_name VARCHAR(150),
    purpose_of_visit VARCHAR(100),
    counsellor_staff_id BIGINT,
    parent_feedback TEXT,
    child_interaction_notes TEXT,
    visit_outcome VARCHAR(100),
    admission_probability VARCHAR(50),
    registration_done BOOLEAN DEFAULT FALSE,
    next_follow_up_date DATE,
    remarks TEXT,
    created_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.admission (
    id BIGSERIAL PRIMARY KEY,
    admission_code VARCHAR(30) UNIQUE NOT NULL,
    lead_id BIGINT REFERENCES blumebee.lead(id),
    student_id BIGINT REFERENCES blumebee.student(id),
    center_id INT REFERENCES blumebee.center(id),
    registration_date DATE,
    admission_date DATE,
    academic_session_id INT REFERENCES blumebee.academic_session(id),
    program_id INT REFERENCES blumebee.master_program(id),
    class_id INT REFERENCES blumebee.master_class(id),
    previous_school VARCHAR(150),
    registration_fee NUMERIC(10,2) DEFAULT 0,
    admission_fee NUMERIC(10,2) DEFAULT 0,
    security_fee NUMERIC(10,2) DEFAULT 0,
    monthly_fee NUMERIC(10,2) DEFAULT 0,
    day_care_fee NUMERIC(10,2) DEFAULT 0,
    transport_fee NUMERIC(10,2) DEFAULT 0,
    discount_amount NUMERIC(10,2) DEFAULT 0,
    payment_status_id INT REFERENCES blumebee.master_payment_status(id),
    admission_status VARCHAR(50),
    remarks TEXT,
    created_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.student_document (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id) ON DELETE CASCADE,
    document_name VARCHAR(100) NOT NULL,
    submitted BOOLEAN DEFAULT FALSE,
    submission_date DATE,
    verified_by_staff_id BIGINT,
    remarks TEXT
);

CREATE TABLE blumebee.authorized_pickup (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id) ON DELETE CASCADE,
    adult_name VARCHAR(150) NOT NULL,
    relationship_to_child VARCHAR(80),
    phone_number VARCHAR(20),
    id_reference VARCHAR(100),
    photo_verified BOOLEAN DEFAULT FALSE,
    is_active BOOLEAN DEFAULT TRUE,
    remarks TEXT
);

CREATE TABLE blumebee.student_health_record (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id) ON DELETE CASCADE,
    blood_group VARCHAR(10),
    allergy_details TEXT,
    medical_condition TEXT,
    doctor_name VARCHAR(150),
    emergency_contact VARCHAR(20),
    medication_instructions TEXT,
    vaccination_record_submitted BOOLEAN DEFAULT FALSE,
    special_notes TEXT,
    updated_at TIMESTAMP DEFAULT NOW()
);



CREATE TABLE blumebee.student_attendance (
    id BIGSERIAL PRIMARY KEY,
    attendance_date DATE NOT NULL,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id) ON DELETE CASCADE,
    class_id INT REFERENCES blumebee.master_class(id),
    attendance_code_id INT REFERENCES blumebee.master_attendance_code(id),
    remarks TEXT,
    UNIQUE(attendance_date, student_id)
);

CREATE TABLE blumebee.staff (
    id BIGSERIAL PRIMARY KEY,
    employee_code VARCHAR(30) UNIQUE NOT NULL,
    center_id INT REFERENCES blumebee.center(id),
    full_name VARCHAR(150) NOT NULL,
    gender_id INT REFERENCES blumebee.master_gender(id),
    role_id INT REFERENCES blumebee.master_staff_role(id),
    department_id INT REFERENCES blumebee.master_department(id),
    joining_date DATE,
    qualification VARCHAR(150),
    experience_years NUMERIC(4,1),
    contact_number VARCHAR(20),
    email VARCHAR(120),
    address_line1 VARCHAR(255),
    city VARCHAR(100),
    state VARCHAR(100),
    pincode VARCHAR(20),
    salary NUMERIC(10,2),
    bank_details TEXT,
    aadhaar_ref VARCHAR(100),
    emergency_contact VARCHAR(20),
    employment_status VARCHAR(50),
    probation_end_date DATE,
    remarks TEXT,
    created_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.staff_attendance (
    id BIGSERIAL PRIMARY KEY,
    attendance_date DATE NOT NULL,
    staff_id BIGINT NOT NULL REFERENCES blumebee.staff(id),
    attendance_code_id INT REFERENCES blumebee.master_attendance_code(id),
    leave_type_id INT REFERENCES blumebee.master_leave_type(id),
    remarks TEXT,
    UNIQUE(attendance_date, staff_id)
);

CREATE TABLE blumebee.staff_training (
    id BIGSERIAL PRIMARY KEY,
    staff_id BIGINT NOT NULL REFERENCES blumebee.staff(id) ON DELETE CASCADE,
    training_type VARCHAR(100),
    training_date DATE NOT NULL,
    trainer_name VARCHAR(150),
    completion_status VARCHAR(50),
    valid_till DATE,
    remarks TEXT
);

CREATE TABLE blumebee.staff_verification (
    id BIGSERIAL PRIMARY KEY,
    staff_id BIGINT NOT NULL REFERENCES blumebee.staff(id) ON DELETE CASCADE,
    police_verification BOOLEAN DEFAULT FALSE,
    reference_check BOOLEAN DEFAULT FALSE,
    medical_fitness BOOLEAN DEFAULT FALSE,
    pocso_orientation BOOLEAN DEFAULT FALSE,
    first_aid_training BOOLEAN DEFAULT FALSE,
    remarks TEXT,
    updated_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.payroll (
    id BIGSERIAL PRIMARY KEY,
    payroll_month DATE NOT NULL,
    staff_id BIGINT NOT NULL REFERENCES blumebee.staff(id),
    gross_salary NUMERIC(10,2) NOT NULL,
    deductions NUMERIC(10,2) DEFAULT 0,
    leave_deduction NUMERIC(10,2) DEFAULT 0,
    bonus_incentive NUMERIC(10,2) DEFAULT 0,
    net_pay NUMERIC(10,2) NOT NULL,
    payment_date DATE,
    payment_mode_id INT REFERENCES blumebee.master_payment_mode(id),
    remarks TEXT,
    UNIQUE(payroll_month, staff_id)
);

CREATE TABLE blumebee.fee_structure (
    id BIGSERIAL PRIMARY KEY,
    center_id INT REFERENCES blumebee.center(id),
    program_id INT REFERENCES blumebee.master_program(id),
    class_id INT REFERENCES blumebee.master_class(id),
    fee_head VARCHAR(100) NOT NULL,
    amount NUMERIC(10,2) NOT NULL,
    frequency VARCHAR(50),
    applicable_from DATE NOT NULL,
    applicable_to DATE
);

CREATE TABLE blumebee.student_bill (
    id BIGSERIAL PRIMARY KEY,
    receipt_invoice_no VARCHAR(40) UNIQUE NOT NULL,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    class_id INT REFERENCES blumebee.master_class(id),
    fee_month DATE NOT NULL,
    total_fee_due NUMERIC(10,2) NOT NULL,
    discount_amount NUMERIC(10,2) DEFAULT 0,
    net_due NUMERIC(10,2) NOT NULL,
    due_date DATE NOT NULL,
    amount_paid NUMERIC(10,2) DEFAULT 0,
    balance_pending NUMERIC(10,2) NOT NULL,
    payment_date DATE,
    payment_mode_id INT REFERENCES blumebee.master_payment_mode(id),
    payment_status_id INT REFERENCES blumebee.master_payment_status(id),
    late_fee NUMERIC(10,2) DEFAULT 0,
    reminder_stage VARCHAR(50),
    risk_flag VARCHAR(50),
    remarks TEXT,
    created_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.student_discount (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    discount_type VARCHAR(100),
    discount_value NUMERIC(10,2),
    discount_percent NUMERIC(5,2),
    approved_by_staff_id BIGINT,
    effective_from DATE,
    effective_to DATE,
    remarks TEXT
);

CREATE TABLE blumebee.student_refund (
    id BIGSERIAL PRIMARY KEY,
    refund_code VARCHAR(30) UNIQUE NOT NULL,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    refund_reason TEXT,
    refund_amount NUMERIC(10,2) NOT NULL,
    approval_status VARCHAR(50),
    refund_date DATE,
    remarks TEXT
);

CREATE TABLE blumebee.student_ledger (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    entry_date DATE NOT NULL,
    entry_type VARCHAR(50) NOT NULL,
    reference_table VARCHAR(50),
    reference_id BIGINT,
    debit_amount NUMERIC(10,2) DEFAULT 0,
    credit_amount NUMERIC(10,2) DEFAULT 0,
    remarks TEXT
);

CREATE TABLE blumebee.parent_communication (
    id BIGSERIAL PRIMARY KEY,
    communication_date DATE NOT NULL,
    student_id BIGINT REFERENCES blumebee.student(id),
    parent_id BIGINT REFERENCES blumebee.parent(id),
    communication_type_id INT REFERENCES blumebee.master_communication_type(id),
    subject VARCHAR(200),
    discussion_summary TEXT,
    action_required TEXT,
    responsible_staff_id BIGINT,
    follow_up_date DATE,
    closure_date DATE,
    status VARCHAR(50),
    remarks TEXT
);

CREATE TABLE blumebee.parent_meeting (
    id BIGSERIAL PRIMARY KEY,
    meeting_date DATE NOT NULL,
    student_id BIGINT REFERENCES blumebee.student(id),
    parent_id BIGINT REFERENCES blumebee.parent(id),
    class_id INT REFERENCES blumebee.master_class(id),
    meeting_type VARCHAR(100),
    purpose TEXT,
    discussion_notes TEXT,
    concerns_raised TEXT,
    action_agreed TEXT,
    teacher_staff_id BIGINT,
    next_follow_up DATE,
    closure_status VARCHAR(50)
);

CREATE TABLE blumebee.parent_concern (
    id BIGSERIAL PRIMARY KEY,
    concern_date DATE NOT NULL,
    student_id BIGINT REFERENCES blumebee.student(id),
    parent_id BIGINT REFERENCES blumebee.parent(id),
    severity_id INT REFERENCES blumebee.master_severity(id),
    concern_subject VARCHAR(200),
    concern_description TEXT,
    owner_staff_id BIGINT,
    promised_resolution_date DATE,
    closure_date DATE,
    status VARCHAR(50),
    sla_breached BOOLEAN DEFAULT FALSE,
    remarks TEXT
);

CREATE TABLE blumebee.parent_engagement (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT REFERENCES blumebee.student(id),
    parent_id BIGINT REFERENCES blumebee.parent(id),
    event_name VARCHAR(150),
    event_date DATE,
    ptm_attended BOOLEAN DEFAULT FALSE,
    activity_participation BOOLEAN DEFAULT FALSE,
    homework_shared BOOLEAN DEFAULT FALSE,
    feedback_score NUMERIC(4,2),
    remarks TEXT
);

CREATE TABLE blumebee.broadcast_log (
    id BIGSERIAL PRIMARY KEY,
    broadcast_date DATE NOT NULL,
    broadcast_type VARCHAR(100),
    subject VARCHAR(200),
    message_body TEXT,
    target_group VARCHAR(100),
    sent_by_staff_id BIGINT,
    channel VARCHAR(50),
    remarks TEXT
);

CREATE TABLE blumebee.daily_child_update (
    id BIGSERIAL PRIMARY KEY,
    update_date DATE NOT NULL,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    class_id INT REFERENCES blumebee.master_class(id),
    attendance_code_id INT REFERENCES blumebee.master_attendance_code(id),
    meal_notes TEXT,
    toileting_notes TEXT,
    nap_notes TEXT,
    mood VARCHAR(50),
    class_participation VARCHAR(100),
    special_note TEXT,
    pickup_person VARCHAR(150),
    teacher_staff_id BIGINT,
    UNIQUE(update_date, student_id)
);

CREATE TABLE blumebee.learning_outcome (
    id BIGSERIAL PRIMARY KEY,
    class_id INT REFERENCES blumebee.master_class(id),
    domain_id INT REFERENCES blumebee.development_domain(id),
    milestone VARCHAR(255) NOT NULL,
    description TEXT,
    age_band VARCHAR(50),
    is_active BOOLEAN DEFAULT TRUE
);

CREATE TABLE blumebee.student_observation (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    class_id INT REFERENCES blumebee.master_class(id),
    domain_id INT REFERENCES blumebee.development_domain(id),
    learning_outcome_id BIGINT REFERENCES blumebee.learning_outcome(id),
    observation_date DATE NOT NULL,
    progress_level VARCHAR(50),
    teacher_observation TEXT,
    strengths TEXT,
    improvement_area TEXT,
    classroom_support TEXT,
    parent_shared BOOLEAN DEFAULT FALSE,
    rag_status VARCHAR(10),
    term_name VARCHAR(50),
    remarks TEXT
);

CREATE TABLE blumebee.student_intervention (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    concern_type VARCHAR(100),
    identified_date DATE NOT NULL,
    support_plan TEXT,
    responsible_staff_id BIGINT,
    review_date DATE,
    status VARCHAR(50),
    parent_counselling_needed BOOLEAN DEFAULT FALSE,
    remarks TEXT
);

CREATE TABLE blumebee.student_assessment (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    class_id INT REFERENCES blumebee.master_class(id),
    assessment_period VARCHAR(50),
    assessment_date DATE NOT NULL,
    domain_id INT REFERENCES blumebee.development_domain(id),
    assessment_method VARCHAR(100),
    grade_level VARCHAR(50),
    teacher_feedback TEXT,
    parent_feedback TEXT,
    report_shared_date DATE,
    remarks TEXT
);

CREATE TABLE blumebee.curriculum_annual_map (
    id BIGSERIAL PRIMARY KEY,
    academic_session_id INT REFERENCES blumebee.academic_session(id),
    class_id INT REFERENCES blumebee.master_class(id),
    month_no INT NOT NULL,
    theme VARCHAR(150),
    sub_theme VARCHAR(150),
    remarks TEXT
);

CREATE TABLE blumebee.weekly_lesson_plan (
    id BIGSERIAL PRIMARY KEY,
    academic_session_id INT REFERENCES blumebee.academic_session(id),
    class_id INT REFERENCES blumebee.master_class(id),
    week_start_date DATE NOT NULL,
    week_end_date DATE NOT NULL,
    theme VARCHAR(150),
    sub_theme VARCHAR(150),
    domain_id INT REFERENCES blumebee.development_domain(id),
    learning_objective TEXT,
    planned_activity TEXT,
    circle_time_topic TEXT,
    rhyme_story TEXT,
    art_craft_activity TEXT,
    teaching_aids_required TEXT,
    teacher_staff_id BIGINT,
    completion_status VARCHAR(50),
    remarks TEXT
);

CREATE TABLE blumebee.daily_activity_plan (
    id BIGSERIAL PRIMARY KEY,
    activity_date DATE NOT NULL,
    class_id INT REFERENCES blumebee.master_class(id),
    assembly_circle_time TEXT,
    main_theme_activity TEXT,
    language_activity TEXT,
    numeracy_activity TEXT,
    art_craft TEXT,
    free_play TEXT,
    outdoor_play TEXT,
    snack_time TEXT,
    story_time TEXT,
    dispersal_notes TEXT,
    teacher_remarks TEXT,
    teacher_staff_id BIGINT
);

CREATE TABLE blumebee.incident_report (
    id BIGSERIAL PRIMARY KEY,
    incident_code VARCHAR(30) UNIQUE NOT NULL,
    incident_date DATE NOT NULL,
    incident_time TIME,
    student_id BIGINT REFERENCES blumebee.student(id),
    class_id INT REFERENCES blumebee.master_class(id),
    incident_type_id INT REFERENCES blumebee.master_incident_type(id),
    description TEXT,
    severity_id INT REFERENCES blumebee.master_severity(id),
    reported_by_staff_id BIGINT,
    immediate_action_taken TEXT,
    first_aid_given BOOLEAN DEFAULT FALSE,
    parent_informed BOOLEAN DEFAULT FALSE,
    follow_up_required BOOLEAN DEFAULT FALSE,
    closure_status VARCHAR(50),
    remarks TEXT,
    created_at TIMESTAMP DEFAULT NOW()
);

CREATE TABLE blumebee.medicine_administration (
    id BIGSERIAL PRIMARY KEY,
    student_id BIGINT NOT NULL REFERENCES blumebee.student(id),
    administration_date DATE NOT NULL,
    administration_time TIME NOT NULL,
    medicine_name VARCHAR(150),
    dosage VARCHAR(100),
    instruction TEXT,
    administered_by_staff_id BIGINT,
    parent_consent_received BOOLEAN DEFAULT FALSE,
    remarks TEXT
);

CREATE TABLE blumebee.emergency_drill (
    id BIGSERIAL PRIMARY KEY,
    drill_date DATE NOT NULL,
    drill_type VARCHAR(100),
    conducted_by_staff_id BIGINT,
    observations TEXT,
    action_points TEXT,
    closure_date DATE,
    remarks TEXT
);

CREATE TABLE blumebee.cctv_audit (
    id BIGSERIAL PRIMARY KEY,
    audit_date DATE NOT NULL,
    area VARCHAR(120),
    status VARCHAR(50),
    checked_by_staff_id BIGINT,
    issue_found TEXT,
    corrective_action TEXT,
    closure_date DATE,
    remarks TEXT
);

CREATE TABLE blumebee.safety_checklist (
    id BIGSERIAL PRIMARY KEY,
    checklist_date DATE NOT NULL,
    checklist_item VARCHAR(150),
    area VARCHAR(100),
    status VARCHAR(50),
    checked_by_staff_id BIGINT,
    issue_found TEXT,
    corrective_action TEXT,
    closure_date DATE,
    remarks TEXT
);

CREATE TABLE blumebee.inventory_item (
    id BIGSERIAL PRIMARY KEY,
    item_code VARCHAR(30) UNIQUE NOT NULL,
    item_name VARCHAR(150) NOT NULL,
    category_id INT REFERENCES blumebee.master_inventory_category(id),
    quantity NUMERIC(10,2) DEFAULT 0,
    unit VARCHAR(30),
    purchase_date DATE,
    vendor_name VARCHAR(150),
    location_name VARCHAR(120),
    condition_id INT REFERENCES blumebee.master_item_condition(id),
    maintenance_due_date DATE,
    assigned_to_staff_id BIGINT,
    status VARCHAR(50),
    remarks TEXT
);

CREATE TABLE blumebee.maintenance_log (
    id BIGSERIAL PRIMARY KEY,
    task_date DATE NOT NULL,
    area VARCHAR(100),
    task_type VARCHAR(100),
    description TEXT,
    assigned_to_staff_id BIGINT,
    status VARCHAR(50),
    checked_by_staff_id BIGINT,
    remarks TEXT
);

CREATE TABLE blumebee.visitor_log (
    id BIGSERIAL PRIMARY KEY,
    visit_date DATE NOT NULL,
    visitor_name VARCHAR(150) NOT NULL,
    contact_number VARCHAR(20),
    purpose_of_visit VARCHAR(150),
    in_time TIME,
    out_time TIME,
    person_met VARCHAR(150),
    id_verified BOOLEAN DEFAULT FALSE,
    remarks TEXT
);

CREATE TABLE blumebee.complaint (
    id BIGSERIAL PRIMARY KEY,
    complaint_code VARCHAR(30) UNIQUE NOT NULL,
    complaint_date DATE NOT NULL,
    complaint_by VARCHAR(150),
    reference_type VARCHAR(30),
    reference_id BIGINT,
    category VARCHAR(100),
    description TEXT,
    assigned_to_staff_id BIGINT,
    action_taken TEXT,
    resolution_date DATE,
    status VARCHAR(50),
    remarks TEXT
);

CREATE TABLE blumebee.document_tracker (
    id BIGSERIAL PRIMARY KEY,
    entity_type VARCHAR(30) NOT NULL,
    entity_id BIGINT NOT NULL,
    class_or_department VARCHAR(100),
    document_name VARCHAR(100) NOT NULL,
    submitted BOOLEAN DEFAULT FALSE,
    submission_date DATE,
    verified_by_staff_id BIGINT,
    pending_status VARCHAR(50),
    remarks TEXT
);

CREATE TABLE blumebee.task_register (
    id BIGSERIAL PRIMARY KEY,
    task_date DATE NOT NULL,
    module_name VARCHAR(100),
    task_title VARCHAR(200) NOT NULL,
    task_description TEXT,
    priority VARCHAR(30),
    status VARCHAR(50),
    assigned_to_staff_id BIGINT,
    escalated_to_staff_id BIGINT,
    due_date DATE,
    completed_date DATE,
    related_entity_type VARCHAR(30),
    related_entity_id BIGINT,
    remarks TEXT
);

CREATE TABLE blumebee.event_planner (
    id BIGSERIAL PRIMARY KEY,
    event_name VARCHAR(150) NOT NULL,
    event_date DATE NOT NULL,
    target_group VARCHAR(100),
    coordinator_staff_id BIGINT,
    budget_amount NUMERIC(10,2),
    status VARCHAR(50),
    remarks TEXT
);

CREATE TABLE blumebee.vendor_amc (
    id BIGSERIAL PRIMARY KEY,
    vendor_name VARCHAR(150) NOT NULL,
    service_type VARCHAR(100),
    contract_start_date DATE,
    contract_end_date DATE,
    contact_person VARCHAR(150),
    phone VARCHAR(20),
    amc_amount NUMERIC(10,2),
    renewal_due_date DATE,
    status VARCHAR(50),
    remarks TEXT
);



CREATE INDEX idx_lead_inquiry_date ON blumebee.lead(inquiry_date);
CREATE INDEX idx_lead_follow_up_date ON blumebee.lead(follow_up_date);
CREATE INDEX idx_visit_date ON blumebee.visit(visit_date);
CREATE INDEX idx_admission_date ON blumebee.admission(admission_date);
CREATE INDEX idx_student_attendance_date ON blumebee.student_attendance(attendance_date);
CREATE INDEX idx_staff_attendance_date ON blumebee.staff_attendance(attendance_date);
CREATE INDEX idx_student_bill_due_date ON blumebee.student_bill(due_date);
CREATE INDEX idx_student_bill_fee_month ON blumebee.student_bill(fee_month);
CREATE INDEX idx_parent_concern_date ON blumebee.parent_concern(concern_date);
CREATE INDEX idx_incident_date ON blumebee.incident_report(incident_date);
CREATE INDEX idx_task_due_date ON blumebee.task_register(due_date);

CREATE VIEW blumebee.v_active_students AS
SELECT s.id, s.student_code, s.full_name, c.name AS class_name, ss.name AS student_status
FROM blumebee.student s
LEFT JOIN blumebee.admission a ON a.student_id = s.id
LEFT JOIN blumebee.master_class c ON c.id = a.class_id
LEFT JOIN blumebee.master_student_status ss ON ss.id = s.student_status_id
WHERE ss.code = 'ACTIVE';

CREATE VIEW blumebee.v_fee_ageing AS
SELECT sb.id,
       sb.receipt_invoice_no,
       s.student_code,
       s.full_name AS student_name,
       sb.net_due,
       sb.amount_paid,
       sb.balance_pending,
       sb.due_date,
       CURRENT_DATE - sb.due_date AS overdue_days,
       CASE
           WHEN sb.balance_pending <= 0 THEN 'Paid'
           WHEN CURRENT_DATE - sb.due_date BETWEEN 0 AND 15 THEN '0-15'
           WHEN CURRENT_DATE - sb.due_date BETWEEN 16 AND 30 THEN '16-30'
           WHEN CURRENT_DATE - sb.due_date BETWEEN 31 AND 60 THEN '31-60'
           WHEN CURRENT_DATE - sb.due_date > 60 THEN '60+'
           ELSE 'Not Due'
       END AS ageing_bucket
FROM blumebee.student_bill sb
JOIN blumebee.student s ON s.id = sb.student_id;

CREATE VIEW blumebee.v_admissions_funnel AS
SELECT pipeline_stage, COUNT(*) AS lead_count
FROM blumebee.lead
GROUP BY pipeline_stage;



INSERT INTO blumebee.center (code, name, address_line1, city, state, pincode, phone, email)
VALUES ('BBK-SRC', 'BlumeBee Preschool', 'Sri Ram Colony', 'Barabanki', 'Uttar Pradesh', '225001', '9555805638', 'info@blumebee.com');

INSERT INTO blumebee.academic_session (name, start_date, end_date, is_active)
VALUES ('2026-27', '2026-04-01', '2027-03-31', TRUE);

INSERT INTO blumebee.master_gender (code, name) VALUES
('M', 'Male'), ('F', 'Female'), ('O', 'Other');

INSERT INTO blumebee.master_program (code, name, age_min_months, age_max_months, sort_order) VALUES
('PG', 'Playgroup', 24, 36, 1),
('NS', 'Nursery', 36, 48, 2),
('LKG', 'LKG', 48, 60, 3),
('UKG', 'UKG', 60, 72, 4),
('DC', 'Day Care', 24, 72, 5),
('AC', 'Activity Centre', 24, 72, 6);

INSERT INTO blumebee.master_class (program_id, code, name, capacity, sort_order) VALUES
(1, 'PG', 'Playgroup', 18, 1),
(2, 'NS', 'Nursery', 22, 2),
(3, 'LKG', 'LKG', 24, 3),
(4, 'UKG', 'UKG', 24, 4),
(5, 'DC', 'Day Care', 20, 5),
(6, 'AC', 'Activity Centre', 20, 6);

INSERT INTO blumebee.master_lead_source (code, name, sort_order) VALUES
('WALKIN', 'Walk-in', 1),
('REF', 'Referral', 2),
('META', 'Meta Ads', 3),
('WA', 'WhatsApp', 4),
('WEB', 'Website', 5),
('EVENT', 'School Event', 6),
('HOARD', 'Hoarding', 7);

INSERT INTO blumebee.master_lead_status (code, name, sort_order) VALUES
('NEW', 'New', 1),
('CONTACTED', 'Contacted', 2),
('VISIT_SCH', 'Visit Scheduled', 3),
('VISIT_DONE', 'Visit Done', 4),
('REG_DONE', 'Registration Done', 5),
('ADM_WON', 'Admission Won', 6),
('ADM_LOST', 'Admission Lost', 7),
('NO_RESPONSE', 'No Response', 8);

INSERT INTO blumebee.master_payment_status (code, name) VALUES
('PENDING', 'Pending'),
('PARTIAL', 'Partial'),
('PAID', 'Paid'),
('OVERDUE', 'Overdue'),
('REFUNDED', 'Refunded');

INSERT INTO blumebee.master_payment_mode (code, name) VALUES
('CASH', 'Cash'),
('UPI', 'UPI'),
('BANK', 'Bank Transfer'),
('CARD', 'Card'),
('CHEQUE', 'Cheque');

INSERT INTO blumebee.master_attendance_code (code, name) VALUES
('P', 'Present'),
('A', 'Absent'),
('L', 'Leave'),
('H', 'Holiday');

INSERT INTO blumebee.master_staff_role (code, name, sort_order) VALUES
('DIR', 'Director', 1),
('CH', 'Centre Head', 2),
('CNS', 'Counsellor', 3),
('TCH', 'Teacher', 4),
('AT', 'Assistant Teacher', 5),
('DCS', 'Day Care Staff', 6),
('SUP', 'Support Staff', 7),
('NNY', 'Nanny', 8),
('WB', 'Ward Boy', 9),
('ADM', 'Admin', 10);

INSERT INTO blumebee.master_department (code, name) VALUES
('ACADEMIC', 'Academic'),
('ADMISSION', 'Admissions'),
('FINANCE', 'Finance'),
('ADMIN', 'Administration'),
('OPERATIONS', 'Operations');

INSERT INTO blumebee.master_leave_type (code, name) VALUES
('CL', 'Casual Leave'),
('SL', 'Sick Leave'),
('PL', 'Paid Leave'),
('UL', 'Unpaid Leave'),
('HD', 'Half Day');

INSERT INTO blumebee.master_incident_type (code, name) VALUES
('MINOR_INJ', 'Minor Injury'),
('ILLNESS', 'Illness'),
('BEHAVIOUR', 'Behavioural Incident'),
('PEER_CONFLICT', 'Conflict with Peer'),
('SAFETY', 'Safety Concern'),
('PICKUP', 'Pickup Issue'),
('OTHER', 'Other');

INSERT INTO blumebee.master_severity (code, name, severity_rank) VALUES
('LOW', 'Low', 1),
('MED', 'Medium', 2),
('HIGH', 'High', 3),
('CRIT', 'Critical', 4);

INSERT INTO blumebee.master_communication_type (code, name) VALUES
('CALL', 'Call'),
('WHATSAPP', 'WhatsApp'),
('SMS', 'SMS'),
('EMAIL', 'Email'),
('MEETING', 'Meeting'),
('COMPLAINT', 'Complaint'),
('APPRECIATION', 'Appreciation'),
('COUNSELLING', 'Counselling');

INSERT INTO blumebee.master_inventory_category (code, name) VALUES
('CLASS_MAT', 'Classroom Material'),
('TOYS', 'Toys'),
('FURN', 'Furniture'),
('TAIDS', 'Teaching Aids'),
('IT', 'IT Equipment'),
('SAFETY', 'Safety Equipment'),
('CLEAN', 'Cleaning Supplies'),
('OFFICE', 'Office Supplies');

INSERT INTO blumebee.master_item_condition (code, name) VALUES
('NEW', 'New'),
('GOOD', 'Good'),
('FAIR', 'Fair'),
('REPAIR', 'Needs Repair'),
('SCRAP', 'Scrap');

INSERT INTO blumebee.master_parent_relationship (code, name) VALUES
('FATHER', 'Father'),
('MOTHER', 'Mother'),
('GUARDIAN', 'Guardian'),
('GRANDPARENT', 'Grandparent'),
('OTHER', 'Other');

INSERT INTO blumebee.master_student_status (code, name) VALUES
('ACTIVE', 'Active'),
('RESERVED', 'Reserved'),
('WAITLIST', 'Waitlist'),
('WITHDRAWN', 'Withdrawn'),
('ALUMNI', 'Alumni');

INSERT INTO blumebee.development_domain (code, name) VALUES
('LANG', 'Language Development'),
('COG', 'Cognitive Development'),
('SOC', 'Social Skills'),
('EMO', 'Emotional Development'),
('FM', 'Fine Motor Skills'),
('GM', 'Gross Motor Skills'),
('NUM', 'Numeracy Readiness'),
('LIT', 'Pre-literacy Skills'),
('CRE', 'Creativity'),
('BEH', 'Classroom Behaviour');



INSERT INTO blumebee.staff
(employee_code, center_id, full_name, gender_id, role_id, department_id, joining_date, qualification, experience_years,
 contact_number, email, city, state, salary, employment_status)
VALUES
('BB-BBK-CH-001', 1, 'Akansha Verma', 2, 2, 4, '2026-03-01', 'BA (Education)', 4.0, '9000000001', 'akansha@blumebee.com', 'Barabanki', 'Uttar Pradesh', 25000, 'Active'),
('BB-BBK-CNS-001', 1, 'Shashi Yadav', 2, 3, 2, '2026-03-16', 'MA, D.El.Ed, NTT', 3.0, '9000000002', 'shashi@blumebee.com', 'Barabanki', 'Uttar Pradesh', 18000, 'Active'),
('BB-BBK-TCH-001', 1, 'Pooja Singh', 2, 4, 1, '2026-03-10', 'B.Ed', 5.0, '9000000003', 'pooja@blumebee.com', 'Barabanki', 'Uttar Pradesh', 16000, 'Active'),
('BB-BBK-AT-001', 1, 'Ritu Verma', 2, 5, 1, '2026-03-10', 'Graduate', 2.0, '9000000004', 'ritu@blumebee.com', 'Barabanki', 'Uttar Pradesh', 12000, 'Active'),
('BB-BBK-ADM-001', 1, 'Ankit Gupta', 1, 10, 4, '2026-03-10', 'B.Com', 4.0, '9000000005', 'ankit@blumebee.com', 'Barabanki', 'Uttar Pradesh', 15000, 'Active');

INSERT INTO blumebee.parent
(full_name, relationship_master_id, phone_primary, phone_whatsapp, email, occupation, city, state, pincode, is_active)
VALUES
('Rahul Mishra', 1, '9800000001', '9800000001', 'rahul.mishra@example.com', 'Private Job', 'Barabanki', 'Uttar Pradesh', '225001', TRUE),
('Neha Mishra', 2, '9800000002', '9800000002', 'neha.mishra@example.com', 'Teacher', 'Barabanki', 'Uttar Pradesh', '225001', TRUE),
('Amit Singh', 1, '9800000003', '9800000003', 'amit.singh@example.com', 'Business', 'Barabanki', 'Uttar Pradesh', '225001', TRUE),
('Priya Singh', 2, '9800000004', '9800000004', 'priya.singh@example.com', 'Homemaker', 'Barabanki', 'Uttar Pradesh', '225001', TRUE),
('Vivek Verma', 1, '9800000005', '9800000005', 'vivek.verma@example.com', 'Banking', 'Barabanki', 'Uttar Pradesh', '225001', TRUE);

INSERT INTO blumebee.student
(student_code, center_id, first_name, last_name, full_name, gender_id, dob, blood_group, city, state, student_status_id)
VALUES
('BB-STU-PG-26-001', 1, 'Aarav', 'Mishra', 'Aarav Mishra', 1, '2022-07-15', 'B+', 'Barabanki', 'Uttar Pradesh', 1),
('BB-STU-NS-26-002', 1, 'Myra', 'Singh', 'Myra Singh', 2, '2021-11-04', 'O+', 'Barabanki', 'Uttar Pradesh', 1),
('BB-STU-LKG-26-003', 1, 'Vihaan', 'Verma', 'Vihaan Verma', 1, '2020-08-21', 'A+', 'Barabanki', 'Uttar Pradesh', 1),
('BB-STU-UKG-26-004', 1, 'Anaya', 'Srivastava', 'Anaya Srivastava', 2, '2019-12-01', 'B+', 'Barabanki', 'Uttar Pradesh', 3),
('BB-STU-DC-26-005', 1, 'Kabir', 'Shukla', 'Kabir Shukla', 1, '2021-02-18', 'AB+', 'Barabanki', 'Uttar Pradesh', 2);

INSERT INTO blumebee.student_parent
(student_id, parent_id, relationship_label, is_primary_contact, is_emergency_contact, is_pickup_authorized)
VALUES
(1, 1, 'Father', TRUE, TRUE, TRUE),
(1, 2, 'Mother', FALSE, TRUE, TRUE),
(2, 3, 'Father', TRUE, TRUE, TRUE),
(2, 4, 'Mother', FALSE, TRUE, TRUE),
(3, 5, 'Father', TRUE, TRUE, TRUE);

INSERT INTO blumebee.lead
(lead_code, center_id, inquiry_date, lead_source_id, parent_name, child_name, child_dob, parent_contact_number, whatsapp_number, email,
 preferred_program_id, interested_class_id, location_area, working_parents, counselor_staff_id, follow_up_date, lead_status_id,
 last_contact_date, first_response_at, pipeline_stage, probability_percent, remarks)
VALUES
('BB-LD-2603-001', 1, '2026-03-10', 3, 'Rahul Mishra', 'Aarav Mishra', '2022-07-15', '9800000001', '9800000001', 'rahul.mishra@example.com', 1, 1, 'Sri Ram Colony', TRUE, 2, '2026-03-18', 6, '2026-03-15', '2026-03-10 10:30:00', 'Admission Won', 95.00, 'Converted after centre visit'),
('BB-LD-2603-002', 1, '2026-03-11', 4, 'Amit Singh', 'Myra Singh', '2021-11-04', '9800000003', '9800000003', 'amit.singh@example.com', 2, 2, 'Civil Lines', TRUE, 2, '2026-03-19', 5, '2026-03-16', '2026-03-11 12:05:00', 'Registration Done', 75.00, 'Awaiting final payment'),
('BB-LD-2603-003', 1, '2026-03-12', 2, 'Vivek Verma', 'Vihaan Verma', '2020-08-21', '9800000005', '9800000005', 'vivek.verma@example.com', 3, 3, 'Lakhpedabagh', TRUE, 2, '2026-03-20', 4, '2026-03-15', '2026-03-12 09:10:00', 'Visit Done', 65.00, 'Interested in premium classroom setup'),
('BB-LD-2603-004', 1, '2026-03-13', 1, 'Anjali Srivastava', 'Anaya Srivastava', '2019-12-01', '9800000006', '9800000006', 'anjali.s@example.com', 4, 4, 'Naka Satrikh', FALSE, 2, '2026-03-21', 3, '2026-03-14', '2026-03-13 14:00:00', 'Visit Scheduled', 55.00, 'Needs transport clarity'),
('BB-LD-2603-005', 1, '2026-03-14', 7, 'Sandeep Shukla', 'Kabir Shukla', '2021-02-18', '9800000007', '9800000007', 'sandeep.s@example.com', 5, 5, 'K.D. Singh Babu Stadium Road', TRUE, 2, '2026-03-22', 2, '2026-03-15', '2026-03-14 16:20:00', 'Contacted', 40.00, 'Considering day care support');

INSERT INTO blumebee.visit
(visit_code, lead_id, visit_date, parent_name, child_name, purpose_of_visit, counsellor_staff_id, parent_feedback,
 child_interaction_notes, visit_outcome, admission_probability, registration_done, next_follow_up_date, remarks)
VALUES
('BB-VS-2603-001', 1, '2026-03-12', 'Rahul Mishra', 'Aarav Mishra', 'Centre Tour', 2, 'Liked safety and hygiene', 'Child settled well in play zone', 'Positive', 'High', TRUE, '2026-03-15', 'Converted'),
('BB-VS-2603-002', 2, '2026-03-14', 'Amit Singh', 'Myra Singh', 'Counselling', 2, 'Comfortable with curriculum', 'Strong response to rhyme corner', 'Positive', 'High', TRUE, '2026-03-18', 'Registration done'),
('BB-VS-2603-003', 3, '2026-03-15', 'Vivek Verma', 'Vihaan Verma', 'Trial Class', 2, 'Asked about assessment style', 'Child engaged in numeracy corner', 'Positive', 'Medium', FALSE, '2026-03-20', 'Need fee closure'),
('BB-VS-2603-004', 4, '2026-03-18', 'Anjali Srivastava', 'Anaya Srivastava', 'Scheduled Visit', 2, NULL, NULL, 'Pending', 'Medium', FALSE, '2026-03-21', 'Upcoming visit'),
('BB-VS-2603-005', 5, '2026-03-16', 'Sandeep Shukla', 'Kabir Shukla', 'Day Care Enquiry', 2, 'Needs flexible timing', 'Child tired but responsive', 'Neutral', 'Low', FALSE, '2026-03-22', 'Follow-up required');

INSERT INTO blumebee.admission
(admission_code, lead_id, student_id, center_id, registration_date, admission_date, academic_session_id, program_id, class_id,
 previous_school, registration_fee, admission_fee, security_fee, monthly_fee, day_care_fee, transport_fee, discount_amount,
 payment_status_id, admission_status, remarks)
VALUES
('BB-ADM-26-001', 1, 1, 1, '2026-03-12', '2026-03-15', 1, 1, 1, NULL, 1000, 5000, 3000, 2500, 0, 0, 0, 3, 'Confirmed', 'Joined Playgroup'),
('BB-ADM-26-002', 2, 2, 1, '2026-03-14', NULL, 1, 2, 2, 'Tiny Tots', 1000, 5000, 3000, 2600, 0, 0, 500, 2, 'Registered', 'Pending final admission'),
('BB-ADM-26-003', 3, 3, 1, NULL, NULL, 1, 3, 3, 'Little Buds', 0, 0, 0, 2800, 0, 0, 0, 1, 'Pipeline', 'Visit complete'),
('BB-ADM-26-004', 4, 4, 1, NULL, NULL, 1, 4, 4, 'Rainbow Kids', 0, 0, 0, 3000, 0, 500, 0, 1, 'Pipeline', 'Awaiting visit'),
('BB-ADM-26-005', 5, 5, 1, NULL, NULL, 1, 5, 5, NULL, 0, 0, 0, 0, 3500, 0, 0, 1, 'Pipeline', 'Day care interest only');

INSERT INTO blumebee.fee_structure
(center_id, program_id, class_id, fee_head, amount, frequency, applicable_from)
VALUES
(1, 1, 1, 'Registration Fee', 1000, 'One-time', '2026-04-01'),
(1, 1, 1, 'Admission Fee', 5000, 'One-time', '2026-04-01'),
(1, 1, 1, 'Tuition Fee', 2500, 'Monthly', '2026-04-01'),
(1, 2, 2, 'Tuition Fee', 2600, 'Monthly', '2026-04-01'),
(1, 5, 5, 'Day Care Fee', 3500, 'Monthly', '2026-04-01');

INSERT INTO blumebee.student_bill
(receipt_invoice_no, student_id, class_id, fee_month, total_fee_due, discount_amount, net_due, due_date, amount_paid, balance_pending,
 payment_date, payment_mode_id, payment_status_id, late_fee, reminder_stage, risk_flag, remarks)
VALUES
('BB-RCPT-2604-001', 1, 1, '2026-04-01', 2500, 0, 2500, '2026-04-10', 2500, 0, '2026-04-08', 2, 3, 0, 'None', 'Low', 'Paid on time'),
('BB-RCPT-2604-002', 2, 2, '2026-04-01', 2600, 500, 2100, '2026-04-10', 1000, 1100, '2026-04-09', 2, 2, 0, 'Friendly Reminder', 'Medium', 'Balance pending'),
('BB-RCPT-2604-003', 3, 3, '2026-04-01', 2800, 0, 2800, '2026-04-10', 0, 2800, NULL, NULL, 4, 100, 'Second Reminder', 'High', 'Overdue'),
('BB-RCPT-2604-004', 4, 4, '2026-04-01', 3000, 0, 3000, '2026-04-10', 0, 3000, NULL, NULL, 1, 0, 'Not Due', 'Medium', 'Not yet converted'),
('BB-RCPT-2604-005', 5, 5, '2026-04-01', 3500, 0, 3500, '2026-04-10', 0, 3500, NULL, NULL, 1, 0, 'Not Due', 'Low', 'Day care pipeline');

INSERT INTO blumebee.student_ledger
(student_id, entry_date, entry_type, reference_table, reference_id, debit_amount, credit_amount, remarks)
VALUES
(1, '2026-04-01', 'bill', 'student_bill', 1, 2500, 0, 'April tuition'),
(1, '2026-04-08', 'receipt', 'student_bill', 1, 0, 2500, 'Payment received'),
(2, '2026-04-01', 'bill', 'student_bill', 2, 2100, 0, 'April tuition after discount'),
(2, '2026-04-09', 'receipt', 'student_bill', 2, 0, 1000, 'Part payment'),
(3, '2026-04-01', 'bill', 'student_bill', 3, 2800, 0, 'April tuition');

INSERT INTO blumebee.learning_outcome
(class_id, domain_id, milestone, description, age_band, is_active)
VALUES
(1, 1, 'Responds to simple instructions', 'Follows one-step classroom instructions', '2-3 years', TRUE),
(2, 2, 'Sorts by color and size', 'Demonstrates early cognitive classification', '3-4 years', TRUE),
(3, 7, 'Recognises numbers 1-10', 'Shows early numeracy readiness', '4-5 years', TRUE),
(4, 8, 'Identifies beginning sounds', 'Shows pre-literacy awareness', '5-6 years', TRUE),
(5, 3, 'Transitions with support', 'Demonstrates separation comfort in care routine', '2-6 years', TRUE);

INSERT INTO blumebee.student_observation
(student_id, class_id, domain_id, learning_outcome_id, observation_date, progress_level, teacher_observation,
 strengths, improvement_area, classroom_support, parent_shared, rag_status, term_name, remarks)
VALUES
(1, 1, 1, 1, '2026-04-12', 'Developing', 'Aarav follows simple instructions during circle time', 'Responds well to songs', 'Needs support during transitions', 'Visual cues and repeated prompts', TRUE, 'A', 'Term 1', 'Good early adjustment'),
(2, 2, 2, 2, '2026-04-12', 'Achieved', 'Myra sorted objects independently', 'Strong concept clarity', 'Needs patience in turn-taking', 'Peer-pair activity', TRUE, 'G', 'Term 1', NULL),
(3, 3, 7, 3, '2026-04-12', 'Developing', 'Vihaan counts to 7 confidently', 'Enjoys manipulatives', 'Needs reinforcement for 8-10', 'Number tray work', FALSE, 'A', 'Term 1', NULL),
(4, 4, 8, 4, '2026-04-12', 'Emerging', 'Anaya identifies some beginning sounds', 'Good listening skill', 'Needs sound-symbol reinforcement', 'Flashcard and rhyme support', FALSE, 'R', 'Term 1', 'Follow-up needed'),
(5, 5, 3, 5, '2026-04-12', 'Developing', 'Kabir settles better after routine explanation', 'Responsive to caregiver', 'Still cries at drop-off', 'Gradual transition support', TRUE, 'A', 'Term 1', NULL);



-- Dashboard totals
SELECT COUNT(*) AS total_leads FROM blumebee.lead;

SELECT COUNT(*) AS total_admissions
FROM blumebee.admission
WHERE admission_date IS NOT NULL;

SELECT COUNT(*) AS active_students
FROM blumebee.student s
JOIN blumebee.master_student_status ss ON ss.id = s.student_status_id
WHERE ss.code = 'ACTIVE';

-- Class-wise student count
SELECT mc.name AS class_name, COUNT(a.student_id) AS student_count
FROM blumebee.admission a
JOIN blumebee.master_class mc ON mc.id = a.class_id
GROUP BY mc.name
ORDER BY mc.name;

-- Monthly leads vs admissions
SELECT DATE_TRUNC('month', l.inquiry_date)::date AS month,
       COUNT(DISTINCT l.id) AS total_leads,
       COUNT(DISTINCT a.id) AS total_admissions
FROM blumebee.lead l
LEFT JOIN blumebee.admission a ON a.lead_id = l.id
GROUP BY 1
ORDER BY 1;

-- Fee collection trend
SELECT DATE_TRUNC('month', fee_month)::date AS month,
       SUM(amount_paid) AS total_collected
FROM blumebee.student_bill
GROUP BY 1
ORDER BY 1;

-- Pending fees
SELECT SUM(balance_pending) AS pending_fees
FROM blumebee.student_bill
WHERE balance_pending > 0;

-- Attendance percent
SELECT ROUND(
         100.0 * SUM(CASE WHEN mac.code = 'P' THEN 1 ELSE 0 END)
         / NULLIF(COUNT(*),0), 2
       ) AS attendance_percent
FROM blumebee.student_attendance sa
JOIN blumebee.master_attendance_code mac ON mac.id = sa.attendance_code_id;

-- Open incidents
SELECT COUNT(*) AS open_incidents
FROM blumebee.incident_report
WHERE closure_status IS NULL OR closure_status <> 'Closed';

-- Parent follow-ups pending
SELECT COUNT(*) AS parent_followups_pending
FROM blumebee.parent_communication
WHERE follow_up_date IS NOT NULL
  AND closure_date IS NULL;

-- Counsellor conversion KPI
SELECT st.full_name AS counsellor_name,
       COUNT(DISTINCT l.id) AS total_leads,
       COUNT(DISTINCT v.id) AS total_visits,
       COUNT(DISTINCT CASE WHEN a.registration_date IS NOT NULL THEN a.id END) AS registrations,
       COUNT(DISTINCT CASE WHEN a.admission_date IS NOT NULL THEN a.id END) AS admissions,
       ROUND(100.0 * COUNT(DISTINCT v.id) / NULLIF(COUNT(DISTINCT l.id),0),2) AS lead_to_visit_pct,
       ROUND(100.0 * COUNT(DISTINCT CASE WHEN a.registration_date IS NOT NULL THEN a.id END) / NULLIF(COUNT(DISTINCT v.id),0),2) AS visit_to_registration_pct,
       ROUND(100.0 * COUNT(DISTINCT CASE WHEN a.admission_date IS NOT NULL THEN a.id END) / NULLIF(COUNT(DISTINCT CASE WHEN a.registration_date IS NOT NULL THEN a.id END),0),2) AS registration_to_admission_pct
FROM blumebee.lead l
LEFT JOIN blumebee.staff st ON st.id = l.counselor_staff_id
LEFT JOIN blumebee.visit v ON v.lead_id = l.id
LEFT JOIN blumebee.admission a ON a.lead_id = l.id
GROUP BY st.full_name
ORDER BY admissions DESC NULLS LAST;

-- Lost reason analysis
SELECT lost_reason, COUNT(*) AS count_leads
FROM blumebee.lead
WHERE pipeline_stage = 'Admission Lost'
GROUP BY lost_reason
ORDER BY count_leads DESC;

-- Source ROI proxy
SELECT mls.name AS lead_source,
       COUNT(DISTINCT l.id) AS total_leads,
       COUNT(DISTINCT a.id) AS total_admissions,
       ROUND(100.0 * COUNT(DISTINCT a.id) / NULLIF(COUNT(DISTINCT l.id),0),2) AS conversion_pct
FROM blumebee.lead l
LEFT JOIN blumebee.master_lead_source mls ON mls.id = l.lead_source_id
LEFT JOIN blumebee.admission a ON a.lead_id = l.id
GROUP BY mls.name
ORDER BY conversion_pct DESC NULLS LAST;

-- SLA breaches
SELECT pc.id,
       s.full_name AS student_name,
       p.full_name AS parent_name,
       pc.concern_subject,
       pc.promised_resolution_date,
       CURRENT_DATE - pc.promised_resolution_date AS overdue_days
FROM blumebee.parent_concern pc
LEFT JOIN blumebee.student s ON s.id = pc.student_id
LEFT JOIN blumebee.parent p ON p.id = pc.parent_id
WHERE pc.closure_date IS NULL
  AND pc.promised_resolution_date < CURRENT_DATE
ORDER BY overdue_days DESC;

-- Low attendance students this month
SELECT s.student_code,
       s.full_name,
       mc.name AS class_name,
       ROUND(
         100.0 * SUM(CASE WHEN mac.code = 'P' THEN 1 ELSE 0 END)
         / NULLIF(COUNT(*),0), 2
       ) AS attendance_pct
FROM blumebee.student_attendance sa
JOIN blumebee.student s ON s.id = sa.student_id
LEFT JOIN blumebee.master_class mc ON mc.id = sa.class_id
JOIN blumebee.master_attendance_code mac ON mac.id = sa.attendance_code_id
WHERE DATE_TRUNC('month', sa.attendance_date) = DATE_TRUNC('month', CURRENT_DATE)
GROUP BY s.student_code, s.full_name, mc.name
HAVING ROUND(
         100.0 * SUM(CASE WHEN mac.code = 'P' THEN 1 ELSE 0 END)
         / NULLIF(COUNT(*),0), 2
       ) < 75
ORDER BY attendance_pct;

-- Capacity utilization
SELECT mc.name AS class_name,
       mc.capacity,
       COUNT(a.student_id) AS occupied_seats,
       mc.capacity - COUNT(a.student_id) AS available_seats,
       ROUND(100.0 * COUNT(a.student_id) / NULLIF(mc.capacity,0), 2) AS utilization_pct
FROM blumebee.master_class mc
LEFT JOIN blumebee.admission a ON a.class_id = mc.id
GROUP BY mc.name, mc.capacity
ORDER BY mc.name;
